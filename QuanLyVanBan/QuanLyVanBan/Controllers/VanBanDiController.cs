using QuanLyVanBan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Controllers
{
    public class VanBanDiController : Controller
    {
        // GET: VanBanDi
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult listVBdiDK()
        {
            using (Model1 db = new Model1())
            {
                var list = db.VanBanDis.ToList();

                return View(list);
            }
        }
        public ActionResult createVBdi()
        {
            return View();
        }
        public ActionResult addVBdi(VanBanDi vb)
        {
            using (Model1 db = new Model1())
            {
                db.VanBanDis.Add(vb);
                db.SaveChanges();
            }
            return Json(new { url = Url.Action("listVBdiDK", "VanBanDi") });
        }

    }
}