using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyVanBan.Models;

namespace QuanLyVanBan.Controllers
{
    public class HistoryController : Controller
    {
        // GET: History
        public ActionResult Index()
        {
            using(Model1 db = new Model1())
            {
                List<LichSuThayDoi> history = db.LichSuThayDois.ToList();
                return View(history);
            }
        }
    }
}