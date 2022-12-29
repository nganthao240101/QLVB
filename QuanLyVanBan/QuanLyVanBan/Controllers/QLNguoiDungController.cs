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
        public ActionResult createUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(CaNhan model,int MaNhomQuyen)
        {
            using (var db=new Model1())
            {
                db.CaNhans.Add(model);
                db.SaveChanges();

                var newUser = db.CaNhans.Where(m => m.email == model.email).FirstOrDefault();
                NguoiDung_ChiTietQuyen user = new NguoiDung_ChiTietQuyen();
                user.MaCaNhan = newUser.MaCaNhan;
                user.MaNhomQuyen = MaNhomQuyen;
                db.NguoiDung_ChiTietQuyen.Add(user);
                db.SaveChanges();
                return RedirectToAction("getUser");
            }

        }
        public ActionResult editUser(int? id)
        {
            using (var db = new Model1())
            {
                CaNhan ob = db.CaNhans.Where(m => m.MaCaNhan == id).FirstOrDefault();
                return View(ob);
            }

        }
        public ActionResult edit(CaNhan model)
        {
            using (var db = new Model1())
            {
                CaNhan ob = db.CaNhans.Where(m => m.MaCaNhan == model.MaCaNhan).FirstOrDefault();
                if (ob != null)
                {

                    ob.TenCaNhan = model.TenCaNhan;
                    ob.SDT = model.SDT;
                    ob.email = model.email;
                    ob.TenDangNhap = model.TenDangNhap;
                    ob.MatKhau = model.MatKhau;
                    ob.CapBac = model.CapBac;
                    ob.MaChucVu = model.MaChucVu;
                    ob.MaDonVi = model.MaDonVi;
                    db.SaveChanges();
                }

            }
            return RedirectToAction("getUser");
        }
    }

}