using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
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
        [QuyenTruyCap(idMaQuyen = 1)]
        public ActionResult GetList(int? trangThaiXL)
        {
            
            using (Model1 db = new Model1())
            {
                List<VanBanDen> a;
                if (trangThaiXL != null)
                {
                     a = db.VanBanDens.Where(s=>s.TrangThaiXuLy==trangThaiXL).ToList();
                }
                else
                {
                     a = db.VanBanDens.ToList();
                }
                ViewBag.vbden = a;
                return View();
            }

        }
        [QuyenTruyCap(idMaQuyen = 1)]
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
        public ActionResult Create(VanBanDen vb, HttpPostedFileBase file)
        {
            using (Model1 db = new Model1())
            {
                string _FileName = "";
                if (file.ContentLength > 0)
                {
                    _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Public"), _FileName);
                    file.SaveAs(_path);
                }
                vb.C_file = _FileName;
                db.VanBanDens.Add(vb);
                db.SaveChanges();
            }
            return RedirectToAction("GetList");
        }

        [QuyenTruyCap(idMaQuyen = 3)]
        [HttpPost]
        public ActionResult DeleteVB(int? id)
        {
            using (Model1 db = new Model1())
            {
                VanBanDen vb = db.VanBanDens.Find(id);
                db.VanBanDens.Remove(vb);
                db.SaveChanges();
               
            }
            return RedirectToAction("GetList");
        }
        [QuyenTruyCap(idMaQuyen = 1)]
        public ActionResult Edit(int? id)
        {
            using (Model1 db = new Model1())
            {
                VanBanDen obj = db.VanBanDens.Find(id);
                return View(obj);
            }
        }
        [QuyenTruyCap(idMaQuyen = 2)]
        [HttpPost]
        public ActionResult EditVanBan(VanBanDen model)
        {
            using (Model1 db = new Model1())
            {
                NguoiDung_ChiTietQuyen cn = (NguoiDung_ChiTietQuyen)Session["user"];
                VanBanDen vb = db.VanBanDens.Where(s => s.MaVanBanDen == model.MaVanBanDen).FirstOrDefault();
                LichSuThayDoi ls = new LichSuThayDoi();
                ls.MaVanBanDen = model.MaVanBanDen;
                ls.NoiDung = "Đã chỉnh sửa nội dung văn bản";
                ls.MaCaNhan = cn.MaCaNhan;
                ls.ThoiGianThucHien = DateTime.Now;
                db.LichSuThayDois.Add(ls);
                db.SaveChanges();
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
               
            }
            return RedirectToAction("getList");

        }

      
        public FileResult ExportExel(int? trangthai)
        {
            Model1 db = new Model1();
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("Mã văn bản đến"),
                                            new DataColumn("Số văn bản đến"),
                                            new DataColumn("Ngày văn bản"),
                                            new DataColumn("Tên loại văn bản"),
                                            new DataColumn("Trích Yếu"),
                                            new DataColumn("Số bản"),
                                            new DataColumn("Số tờ"),
                                            new DataColumn("Độ Mật"),
                                              new DataColumn("Độ Khẩn"),
                                            new DataColumn("Tình trạng") });

       
            var ob = (from s in db.VanBanDens
                      join sa in db.DoKhans on s.MaDoKhan equals sa.MaDoKhan
                      join sb in db.DoMats on s.MaDoMat equals sb.MaDoMat
                      join sc in db.LoaiVanBans on s.MaLoaiVanBan equals sc.MaLoaiVanBan
                      select new
                      {
                          s,
                          sa,
                          sb,
                          sc

                      }).ToList();
            if (trangthai != null)
            {
                ob = (from s in db.VanBanDens
                      join sa in db.DoKhans on s.MaDoKhan equals sa.MaDoKhan
                      join sb in db.DoMats on s.MaDoMat equals sb.MaDoMat
                      join sc in db.LoaiVanBans on s.MaLoaiVanBan equals sc.MaLoaiVanBan
                      where s.TrangThaiXuLy == trangthai
                      select new
                      {
                          s,
                          sa,
                          sb,
                          sc

                      }).ToList();
            }
            foreach (var item in ob)
            {
                dt.Rows.Add(item.s.MaVanBanDen, item.s.NgayVanBan, item.s.CoQuanBanHanh, item.sc.TenLoaiVanBan, item.s.TrichYeu, item.s.SoBan, item.s.SoTo, item.sb.TenDoMat, item.sa.TenDoKhan, item.s.TinhTrang);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DanhSachVanBanDen.xlsx");
                }
            }

        }
        [HttpPost]
        [ValidateInput(false)]
        public FileResult ExportPDF(string GridHtml)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    StringReader sr = new StringReader(GridHtml);
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();
                    return File(stream.ToArray(), "application/pdf", "DanhSachVanBanDen.pdf");
                }

            }
            catch
            {
                return null;
            }

        }
    }
}