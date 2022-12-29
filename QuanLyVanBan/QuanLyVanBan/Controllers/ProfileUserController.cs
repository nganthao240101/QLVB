using QuanLyVanBan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Controllers
{
    public class ProfileUserController : Controller
    {
        // GET: ProfileUser
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult formUser()
        {
            return View();
            
        }
    }
}