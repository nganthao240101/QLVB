using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                return RedirectToAction("Login");
            }
            else return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string password) 
        {
            if(username.ToLower()=="hanh" && password == "hanh")
            {
                Session["username"] = "hanh";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}