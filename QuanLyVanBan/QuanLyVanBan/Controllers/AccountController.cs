
using QuanLyVanBan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyVanBan.Support;

namespace QuanLyVanBan.Controllers
{
    public class AccountController : Controller
    {
        QuanLyVanBan.Support.Support sp = new QuanLyVanBan.Support.Support();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult confirmRegister(string TenDangNhap, string TenCaNhan, string MaDonVi, int MaChucVu, string Email, int SDT, string MatKhau, string RepeatMK)
        {
            using (Model1 db = new Model1())
            {
               
                
                if (MatKhau != RepeatMK)

                {
                    TempData["Error"] = "Mật khẩu nhập lại không khớp";
                }
                else if (!checkEmail(Email))
                {
                    TempData["Error"] = "Địa chỉ Email đã được sử dụng";
                }
                else 
                {
                    //var tenDN = db.CaNhans.Where(m => m.TenDangNhap == TenDangNhap).FirstOrDefault();
                    //if (tenDN.TenDangNhap==TenDangNhap)
                    //{
                      
                    //        TempData["Error"] = "Tên đăng ký đã tồn tại";

                    //}
                    //else {
                        CaNhan cn = new CaNhan();
                        cn.TenCaNhan = TenCaNhan;
                        cn.email = Email;
                        cn.SDT = SDT;
                        cn.MaDonVi = MaDonVi;
                        cn.MaChucVu = MaChucVu;
                        cn.TenDangNhap = TenDangNhap;
                        cn.MatKhau = sp.EncodePassword(MatKhau); 
                        db.CaNhans.Add(cn);
                        db.SaveChanges();
                        return Json("Đăng kí thành công");
                    //}
                    
                }
                return Json("Đăng kí thất bại ");



            }
        }

        public bool checkEmail(string Email)
        {
            using (var db = new Model1())
            {
                CaNhan em = db.CaNhans.Where(e => e.email == Email).FirstOrDefault();
                if (em != null)
                {
                    return false;
                }
                return true;
            }
        }
        public bool insertTK(CaNhan cn)
        {
            using (var db = new Model1())
            {
                db.CaNhans.Add(cn);
                db.SaveChanges();
                return true;
            }

        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult confirmLogin(string TenDangNhap, string MatKhau)
        {
            using (var db = new Model1())
            {
                MatKhau = sp.EncodePassword(MatKhau);
                CaNhan taiKhoan = db.CaNhans.Where(s => s.TenDangNhap == TenDangNhap).FirstOrDefault();
                if (taiKhoan != null && taiKhoan.MatKhau == MatKhau)
                {
                    var ob = db.NguoiDung_ChiTietQuyen.Where(s => s.MaCaNhan == taiKhoan.MaCaNhan).FirstOrDefault();

                    if (ob != null)
                    {
                        CaNhan canhan = db.CaNhans.Where(s => s.MaCaNhan == ob.MaCaNhan).FirstOrDefault();
                        Session["user"] = ob;
                        Session["nhomQ"] = ob.MaNhomQuyen;
                        Session["fullName"] = taiKhoan.TenCaNhan.ToString();
                        Session["canhan"] = canhan; 

                        return RedirectToAction("Index", "Home");


                    }

                }
                else
                {
                    TempData["Error"] = "Tài khoản hoặc mật khẩu không đúng. Vui lòng đăng nhập lại !";
                    return RedirectToAction("Login");
                }
                //CaNhan taiKhoan = db.CaNhans.Where(s => s.TenDangNhap == TenDangNhap).FirstOrDefault();
                //if (taiKhoan != null && taiKhoan.MatKhau == MatKhau)
                //{
                //    NguoiDung_ChiTietQuyen ob = db.NguoiDung_ChiTietQuyen.Where(s => s.MaCaNhan == taiKhoan.MaCaNhan && s.MaNhomQuyen == groupID).FirstOrDefault();
                //    Session["user"] = ob;
                //    Session["fullName"] = taiKhoan.TenCaNhan.ToString();
                //    return RedirectToAction("Bieudo", "ThongKe");

                //}
                //else
                //{
                //    TempData["Error"] = "Tài khoản không đúng. Vui lòng đăng nhập lại !";
                //    return RedirectToAction("Login");
                //}
               
            }
           return Redirect("/VanBanDen/GetList");
        }
        public ActionResult Dashborad()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Home", "Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {

            Session.Clear();
            return Redirect("~/");
        }
    }
}