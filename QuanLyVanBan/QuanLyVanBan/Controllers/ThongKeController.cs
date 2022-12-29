using QuanLyVanBan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Web.Razor.Parser.SyntaxConstants;

namespace QuanLyVanBan.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: ThongKe
        public ActionResult Bieudo()
        {
            using (Model1 db = new Model1())
            {
                int Total_vanbanden = db.VanBanDens.Count();
                int Total_vanbandi = db.VanBanDis.Count();
               /* int Total_chuyenvanban = db.ChuyenVanBans.Count();*/
                int Total_vanbanden_dxl = db.VanBanDens.Where(c => c.TrangThaiXuLy == 1).Count();
                int Total_vanbanden_cxl = db.VanBanDens.Where(c => c.TrangThaiXuLy == 0).Count();
                Dictionary<string, int> data = new Dictionary<string, int>();
                data.Add("Văn bản đến", Total_vanbanden);
                data.Add("Văn bản đi", Total_vanbandi);
              /*  data.Add("Văn bản đã chuyển", Total_chuyenvanban);*/
                data.Add("Văn bản đã xử lí", Total_vanbanden_dxl);
                data.Add("Văn bản chưa xử lí", Total_vanbanden_cxl);
                //Donut Chart
                int domat_1 = db.VanBanDens.Where(c => c.MaDoMat == 1).Count();
                int domat_2 = db.VanBanDens.Where(c => c.MaDoMat == 2).Count();
                int domat_3 = db.VanBanDens.Where(c => c.MaDoMat == 3).Count();
                int domat_4 = db.VanBanDens.Where(c => c.MaDoMat == 4).Count();
                int domat_5 = db.VanBanDens.Where(c => c.MaDoMat == 5).Count();
                List<int> domat = new List<int>();
                domat.Add(domat_1);
                domat.Add(domat_2);
                domat.Add(domat_3);
                domat.Add(domat_4);
                domat.Add(domat_5);

                ViewBag.lichsu = db.LichSuThayDois.Count();
                ViewBag.loaivb = db.LoaiVanBans.Count();
                ViewBag.linhvuc = db.LinhVucVanBans.Count();
                ViewBag.dict = data;
                ViewBag.domat = domat;
                return View();

            }
        }

        public ActionResult BangThongKe()
        {
            using (Model1 db = new Model1())
            {
                List<VanBanDi> act = new List<VanBanDi>();
                act = db.VanBanDis.ToList();
                return View(act);
            }
        }
       
    }
}