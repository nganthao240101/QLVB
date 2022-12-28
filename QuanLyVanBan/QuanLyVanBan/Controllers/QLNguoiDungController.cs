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
                return View();
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
                
                return View(o);
            }
        }
    }
}