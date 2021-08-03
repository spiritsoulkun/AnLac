using AnLac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace AnLac.Controllers
{
    public class QLSPsController : Controller
    {
        ProductlistSP strSP = new ProductlistSP();


        DataClassesDoAnDataContext db = new DataClassesDoAnDataContext();

        private List<Product> GetNewTree(int count)
        {
            //Sắp xếp cây theo ngày cập nhật, sau đó lấy top @count
            return db.Products.OrderByDescending(a => a.productCreateOn).Take(count).ToList();
        }



        // GET: QLSPs
        public ActionResult Index(int ? page)
        {
            //int pageSize = 4;
            //int pageNum = (page ?? 1);
            //var caymoi = GetNewTree(15);
            //return View(caymoi.ToPagedList(pageNum, pageSize));

            List<QLDatabaseSP> obj = strSP.GetSanpham(string.Empty);
            return View(obj);
        }

        public ActionResult Shop(int ? page)
        {


            int pageSize = 4;
            int pageNum = (page ?? 1);
            var caymoi = GetNewTree(15);
            return View(caymoi.ToPagedList(pageNum, pageSize));
            //List<QLDatabaseSP> obj = strSP.GetSanpham(string.Empty);
            //return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(QLDatabaseSP qLDatabaseSP)
        {
            if(ModelState.IsValid)
            {
                strSP.insertProduct(qLDatabaseSP);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(string productCode)
        {
            ProductlistSP sp = new ProductlistSP();
            List<QLDatabaseSP> obj = strSP.GetSanpham(productCode);
            return View(obj.FirstOrDefault());    
        }

        [HttpPost]
        public ActionResult Edit(QLDatabaseSP qLDatabaseSP)
        {
            ProductlistSP sp = new ProductlistSP();
            sp.updataProduct(qLDatabaseSP);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(string productCode)
        {
            List<QLDatabaseSP> obj = strSP.GetSanpham(productCode);
            return View(obj.FirstOrDefault());
        }

        public ActionResult Delete(string productCode)
        {
            // SachList BH = new SachList();
            List<QLDatabaseSP> obj = strSP.GetSanpham(productCode);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Delete(QLDatabaseSP qlDatabaseSp)
        {
            // SachList BH = new SachList();
            strSP.deleteProduct(qlDatabaseSp);
            return RedirectToAction("Index");
        }
    }
}