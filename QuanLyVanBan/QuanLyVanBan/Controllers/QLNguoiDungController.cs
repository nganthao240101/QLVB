using QuanLyVanBan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Controllers
{
    public class QLNguoiDungController : Controller
    {
        // GET: QLNguoiDung
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getUser()
        {
            using (var db = new Model1())
            {
                var ob = db.CaNhans.ToList();
                ViewBag.listUser = ob;
                return View(ob);
            }
               
        }
        public ActionResult ChiTietQuyen(int maNhomQ)
        {
            using (var db = new Model1())
            {
                var o = maNhomQ;
                //var ob = (from s in db.NhomQuyens 
                //          join sc in db.ChiTietQuyens on s.MaNhomQuyen equals sc.MaNhomQuyen
                //          where s.MaNhomQuyen==maNhomQ
                //          select new
                //          {
                //              s.MaNhomQuyen,s.TenNhomQuyen,sc.ChucNang,sc.CheckQuyen_ChucNang

                //          }).ToList();
                //ViewBag.objects = ob;
                ViewBag.maNhomQ = maNhomQ;
                return View(o);
            }
        }
        [HttpPost]
        public ActionResult changeRole (int ma, bool check)
        {
            using (var db = new Model1())
            {
                var Role = db.ChiTietQuyens.Find(ma);
                if(Role != null)
                {
                    Role.CheckQuyen_ChucNang = check;
                    db.SaveChanges();
                }
                return Json("Ok");
            }
            
        }
        [HttpPost]
        public ActionResult DeleteUser (int ma)
        {
            using (var db = new Model1()) 
            {
                CaNhan User = db.CaNhans.Find(ma);
                if (User != null)
                {
                    db.CaNhans.Remove(User);
                    db.SaveChanges();
                }
                return Json("Ok");
            }
        }
    }

}