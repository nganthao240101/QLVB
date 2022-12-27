using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using QuanLyVanBan.Models;
using QuanLyVanBan.SampleModels;

namespace QuanLyVanBan.Controllers
{
    public class VanBanDenController : Controller
    {
        // GET: VanBanDen
        public ActionResult Index()
        {
            return View();
        }
        //[QuyenTruyCap(idMaQuyen = 1)]
        public ActionResult GetList(int? thuhoi)
        {
            
            using (Model1 db = new Model1())
            {
                List<VanBanDen> a;
                if (thuhoi != null)
                {
                     a = db.VanBanDens.Where(s=>s.ThuHoi==false).ToList();
                }
                else
                {
                     a = db.VanBanDens.ToList();
                }
                ViewBag.vbden = a;
                return View();
            }

        }
        //[QuyenTruyCap(idMaQuyen = 1)]
        public ActionResult Details(int id)
        {
            using (Model1 db = new Model1())
            {

                VanBanDen obj = db.VanBanDens.Find(id);
                return View(obj);


            }
        }
        //[QuyenTruyCap(idMaQuyen = 1)]

        public ActionResult Create()
        {
            return View();
        }

        //[QuyenTruyCap(idMaQuyen = 1)]
        [HttpPost]
        public ActionResult Create(VanBanDen vb)
        {
            using (Model1 db = new Model1())
            {
                db.VanBanDens.Add(vb);
                db.SaveChanges();
            }
            return Json("");
        }

        //[QuyenTruyCap(idMaQuyen = 3)]
        [HttpPost]
        public ActionResult DeleteVB(int? id)
        {
            using (Model1 db = new Model1())
            {
                VanBanDen vb = db.VanBanDens.Find(id);
                db.VanBanDens.Remove(vb);
                db.SaveChanges();
                return Json(new { url = Url.Action("GetList", "VanBanDen") });
            }
        }
        //[QuyenTruyCap(idMaQuyen = 1)]
        public ActionResult Edit(int? id)
        {
            using (Model1 db = new Model1())
            {
                VanBanDen obj = db.VanBanDens.Find(id);
                return View(obj);
            }
        }
        //[QuyenTruyCap(idMaQuyen = 2)]
        [HttpPost]
        public ActionResult EditVanBan(VanBanDen model)
        {
            using (Model1 db = new Model1())
            {
                VanBanDen vb = db.VanBanDens.Where(s => s.MaVanBanDen == model.MaVanBanDen).FirstOrDefault();
                if (vb != null)
                {
                    vb.SoVanBan = model.SoVanBan;
                    vb.NgayVanBan = model.NgayVanBan;
                    vb.KyHieuVanBan = model.KyHieuVanBan;
                    vb.TinhTrang = model.TinhTrang;
                    vb.CoQuanBanHanh = model.CoQuanBanHanh;
                    vb.NgonNgu = model.NgonNgu;
                    vb.DoMat = model.DoMat;
                    vb.TrangThaiVanBan = model.TrangThaiVanBan;
                    vb.NgayDen = model.NgayDen;
                    vb.SoBan = model.SoBan;
                    vb.ThuTruongDuyet = model.ThuTruongDuyet;
                    vb.LinhVucVanBan = model.LinhVucVanBan;
                    vb.DoKhan = model.DoKhan;
                    vb.TrangThaiXuLy = model.TrangThaiXuLy;
                    vb.HanGiaiQuyet = model.HanGiaiQuyet;
                    vb.SoTo = model.SoTo;
                    vb.ChucVuNguoiKy = model.ChucVuNguoiKy;
                    vb.SoHoSo = model.SoHoSo;
                    vb.LoaiVanBan = model.LoaiVanBan;
                    vb.NgayTraBaoMat = model.NgayTraBaoMat;
                    vb.GhiChu = model.GhiChu;
                    vb.TrichYeu = model.TrichYeu;
                    db.SaveChanges();

                }
                return Json(new { url = Url.Action("GetList", "VanBanDen") });
            }

        }
        [HttpPost]
        public ActionResult VBCanXuLy(int? id)
        {
            using (Model1 db = new Model1())
            {
                //var list = db.VanBanDens.ToList();
                var da = db.VanBanDens.Where(m => m.MaVanBanDen == id).ToList();

                return View(da);
            }
        }
        public ActionResult ListVBCanXuLy()
        {
            using (Model1 db = new Model1())
            {
                //var list = db.VanBanDens.ToList();
                var da = db.VanBanDens.Where(m => m.TinhTrang == true).ToList();

                return View(da);
            }
        }
        public ActionResult VBCanThuHoi(int? id)
        {
            using (Model1 db = new Model1())
            {
                //var list = db.VanBanDens.ToList();
                var da = db.VanBanDens.Where(m => m.MaVanBanDen == id).ToList();

                return View(da);
            }
        }
        public ActionResult searchVB(string ghiChu)
        {
            using (Model1 db = new Model1())
            {
                var data = db.VanBanDens.Where(m => m.GhiChu.ToLower().Contains(ghiChu.ToLower())).ToList();
                return View();
            }
        }
    }
}