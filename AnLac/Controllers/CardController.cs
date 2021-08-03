using AnLac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnLac.Controllers
{
    public class CardController : Controller
    {
        DataClassesDoAnDataContext db = new DataClassesDoAnDataContext();
        // GET: Card
        public List<QLDatabaseCard> GetCard()
        {
            List<QLDatabaseCard> lstCard = Session["QLDatabaseCard"] as List<QLDatabaseCard>;
            if(lstCard == null)
            {
                lstCard = new List<QLDatabaseCard>();
                Session["QLDatabaseCard"] = lstCard;
            }
            return lstCard;
        }

        public ActionResult AddCard(int iproductCode, string strURL)
        {
            List<QLDatabaseCard> lstCard = GetCard();
            QLDatabaseCard product = lstCard.Find(n => n.iproductCode == iproductCode);
            if(product==null)
            {
                product = new QLDatabaseCard(iproductCode);
                lstCard.Add(product);
                return Redirect(strURL);
            }
            else
            {
                product.iorderDetailsQuantity++;
                return Redirect(strURL);
            }
        }
        private int TotalSL()
        {
            int iTotalSL = 0;
            List<QLDatabaseCard> lstCard = Session["QLDatabaseCard"] as List<QLDatabaseCard>;
            if(lstCard != null)
            {
                iTotalSL = lstCard.Sum(n => n.iorderDetailsQuantity);
            }
            return iTotalSL;
        }

        private double TotalMoney()
        {
            double iTotalMoney = 0;
            List<QLDatabaseCard> lstCard = Session["QLDatabaseCard"] as List<QLDatabaseCard>;
            if (lstCard != null)
            {
                iTotalMoney = lstCard.Sum(n => n.dTotal);
            }
            return iTotalMoney;
        }

        public ActionResult Card()
        {
            List<QLDatabaseCard> lstCard = GetCard();
            ViewBag.TotalSL = TotalSL();
            ViewBag.TotalMoney = TotalMoney();
            return View(lstCard);
        }

        public ActionResult CardPartial()
        {
            ViewBag.TotalSL = TotalSL();
            ViewBag.TotalMoney = TotalMoney();
            return PartialView();
        }

        public ActionResult DeleteCard(int iCode)
        {
            List<QLDatabaseCard> lstCard = GetCard();
            QLDatabaseCard sanpham = lstCard.SingleOrDefault(n=>n.iproductCode == iCode);
            if (sanpham != null)
            {
                lstCard.RemoveAll(n => n.iproductCode == iCode);
                return RedirectToAction("Card");
            }
            return RedirectToAction("Card");
        }

        public ActionResult DeleteAllCard()
        {
            List<QLDatabaseCard> lstCard = GetCard();
            lstCard.Clear();    
            return RedirectToAction("Card");
        }

        public ActionResult UpdataCard(int iCode,FormCollection f)
        {
            List<QLDatabaseCard> lstCard = GetCard();
            QLDatabaseCard sanpham = lstCard.SingleOrDefault(n => n.iproductCode == iCode);
            if(sanpham!=null)
            {
                sanpham.iorderDetailsQuantity = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("Card");
        }
        

        //Đặt hàng
        [HttpGet]
        public ActionResult ThanhToan()
        {
            //Kiem tra dang nhap
            if (Session["Taikhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "ResignAndLogin");
            }
            if (Session["QLDatabaseCard"] == null)
            {
                return RedirectToAction("Index","QLSPs");
            }

            //lay gio hang tu Session
            List<QLDatabaseCard> lstCard = GetCard();
            ViewBag.TotalSL = TotalSL();
            ViewBag.TotalMoney = TotalMoney();

            return View(lstCard);
        }

        //Xác nhận đơn hàng
        public ActionResult ThanhToan(FormCollection collection)
        {
            //Them Don hang
            
            Order od = new Order();
            Customer kh = (Customer)Session["TaiKhoan"];
            List<QLDatabaseCard> gh = GetCard();
            od.customerCode = kh.customerCode;
            od.orderDate = DateTime.Now;
            var orderShippedDate = String.Format("{0:MM/dd/yyyy}", collection["orderShippedDate"]);
            od.orderShippedDate = DateTime.Parse(orderShippedDate);
            od.orderStatus = false;
            db.Orders.InsertOnSubmit(od);
            db.SubmitChanges();

            foreach (var item in gh)
            {
                OrderDetail odt = new OrderDetail();
                odt.orderNumber = od.orderNumber;
                odt.productCode = item.iproductCode;
                odt.orderDetailsQuantity = item.iorderDetailsQuantity;
                odt.orderDetailsPriceEach = (decimal)item.dorderDetailsPriceEach;
                db.OrderDetails.InsertOnSubmit(odt);
            }
            db.SubmitChanges();
            Session["QLDatabaseCard"] = null;
            return RedirectToAction("XacNhanDonHang", "Card");
        }

        public ActionResult XacNhanDonHang()
        {
            return View();
        }
    }
}