using QuanLyVanBan.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpPost]
        public ActionResult addVBdi(VanBanDi vb, HttpPostedFileBase file)
        {
            using (Model1 db = new Model1())
            {
                string _FileName="";
                if (file.ContentLength > 0)
                {
                    _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Public"), _FileName);
                    file.SaveAs(_path);
                }
                vb.C_file = _FileName;
                db.VanBanDis.Add(vb);
                db.SaveChanges();
            }
            return RedirectToAction("listVBdiDK");
        }
        [HttpPost]
        public ActionResult DeleteVBDi(int mavb)
        {
            using (Model1 db = new Model1())
            {
                VanBanDi vb = db.VanBanDis.Find(mavb);
                db.VanBanDis.Remove(vb);
                db.SaveChanges();
            }
           return RedirectToAction("listVBdiDK"); 
        }
        public ActionResult Detail(int mavb)
        {
            using(Model1 db = new Model1())
            {
                VanBanDi vb = db.VanBanDis.Find(mavb);
                return View(vb);
            }
        }
        public ActionResult UpdateVBDI(int mavb)
        {
            using (Model1 db = new Model1())
            {
                VanBanDi vb = db.VanBanDis.Find(mavb);
                return View(vb);
            }
        }
        [HttpPost]
        public ActionResult Update(VanBanDi model,int mavb, HttpPostedFileBase file)
        {
            using (Model1 db = new Model1())
            {
                VanBanDi vb = db.VanBanDis.Where(s => s.MaVanBanDi == mavb).FirstOrDefault();
                if (vb != null)
                {
                    string _FileName = "";
                    if (file != null && file.ContentLength > 0)
                    {
                        _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Public"), _FileName);
                        file.SaveAs(_path);
                    }
                    vb.NgayVanBan = model.NgayVanBan;
                    vb.SoVanBan = model.SoVanBan;
                    vb.MaLinhVuc = model.MaLinhVuc;
                    vb.NgayVanBan = model.NgayVanBan;
                    vb.KyHieuVanBan = model.KyHieuVanBan;
                    vb.MaDoKhan = model.MaDoKhan;
                    vb.MaDoMat = model.MaDoMat;
                    vb.MaDonVi = model.MaDonVi;
                    vb.NgonNgu = model.NgonNgu;
                    vb.GhiChu = model.GhiChu;
                    vb.C_file = _FileName;
                    vb.SoHoSo = model.SoHoSo;
                    vb.HoTenNguoiKy = model.HoTenNguoiKy;
                    vb.ChucVuNguoiKy = model.ChucVuNguoiKy;
                    vb.SoTo = model.SoTo;
                    vb.TrichYeu = model.TrichYeu;
                    vb.TrangThai = model.TrangThai;
                    vb.MaLoaiVanBan = model.MaLoaiVanBan;
                    vb.DonViNhan = model.DonViNhan;
                    db.SaveChanges();
                }

            }
            return RedirectToAction("listVBdiDK");
        }

    }
}