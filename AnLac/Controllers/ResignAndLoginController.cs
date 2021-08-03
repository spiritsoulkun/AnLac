using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using AnLac.Models;

namespace AnLac.Controllers
{
    public class ResignAndLoginController : Controller
    {
        DataClassesDoAnDataContext db = new DataClassesDoAnDataContext();
        CustomerAction CS = new CustomerAction();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //GET: Register

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(QLDatabaseKH n)
        {
            if (ModelState.IsValid)
            {
                var check = db.Customers.FirstOrDefault(s => s.customerEmail == n.customerEmail);
                if (check == null)
                {
                    CS.AddCustomer(n);
                    ViewBag.Confirm = "DOne";
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            DataClassesDoAnDataContext db = new DataClassesDoAnDataContext();
            var tendn = collection["email"];
            var matkhau = collection["password"];
            if (string.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phai nhap mat khau";
            }
            else
            {
                Customer kh = db.Customers.SingleOrDefault(n => n.customerEmail.Equals(tendn) && n.customerPassword.Equals(matkhau));
                if (kh != null)
                {
                    Session["TaiKhoan"] = kh;
                    return RedirectToAction("Shop", "QLSPs");
                }
                else
                {
                    Admin ad = db.Admins.SingleOrDefault(n => n.AdminEmail.Equals(tendn) && n.AdminPassword.Equals(matkhau));
                    if(ad != null )
                    {
                        Session["Admin"] = ad;
                        return RedirectToAction("Index","QLSPs");
                    }
                }
                    ViewBag.Thongbao = "Ten dang nhap hoac mat khau khong dung";
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }



       

    }
}