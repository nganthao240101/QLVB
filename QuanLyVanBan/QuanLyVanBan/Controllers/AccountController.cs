
using QuanLyVanBan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Controllers
{
    public class AccountController : Controller
    {
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
                CaNhan tenDN = db.CaNhans.Where(s => s.TenDangNhap == TenDangNhap).FirstOrDefault();
                if (MatKhau != RepeatMK)

                {
                    TempData["Error"] = "Mật khẩu nhập lại không khớp";
                }
                else if (!checkEmail(Email))
                {
                    TempData["Error"] = "Địa chỉ Email đã được sử dụng";
                }
                else if (tenDN == null)
                {
                    CaNhan obj = new CaNhan();

                    obj.TenCaNhan = TenCaNhan;
                    obj.email = Email;
                    obj.SDT = SDT;
                    obj.MaDonVi = MaDonVi;
                    obj.MaChucVu = MaChucVu;
                    obj.TenDangNhap = TenDangNhap;
                    obj.MatKhau = MatKhau;
                    //db.CaNhans.Add(obj);
                    //db.SaveChanges();
                    if (insertTK(obj) == true)
                    {
                        TempData["Success"] = "Đăng ký thành công";
                    }
                    else
                    {
                        TempData["Error"] = "Thất Bại";
                    }
                }

                return RedirectToAction("Register");

            }
        }
        //false: tồn tại, 
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
                CaNhan taiKhoan = db.CaNhans.Where(s => s.TenDangNhap == TenDangNhap).FirstOrDefault();
                if (taiKhoan != null && taiKhoan.MatKhau == MatKhau)
                {
                    var ob = db.NguoiDung_ChiTietQuyen.Where(s => s.MaCaNhan == taiKhoan.MaCaNhan).FirstOrDefault();
                    if (ob != null)
                    {
                        Session["user"] = ob;
                        Session["nhomQ"] = ob.MaNhomQuyen;
                        Session["fullName"] = taiKhoan.TenCaNhan.ToString();

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
            return View();
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