using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Windows;

namespace QuanLyVanBan.Models
{
    public class QuyenTruyCap : AuthorizeAttribute
    {
        public int idMaQuyen { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            NguoiDung_ChiTietQuyen cnSession = (NguoiDung_ChiTietQuyen)HttpContext.Current.Session["user"];
            if (cnSession != null)
            {
                Model1 db = new Model1();
                var count = db.ChiTietQuyens.Where(s => s.MaNhomQuyen == cnSession.MaNhomQuyen && s.MaQuyen == idMaQuyen).Count();
                if (count != 0)
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền thực hiện chức năng này ");
                    //MessageBox.Show("Không có quyền");
                    //var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                    //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    //    new
                    //    {
                    //        controller = "VanBanDen",
                    //        action = "Create",
                    //        returnUrl = returnUrl.ToString()
                    //    }));
                }
            }
            else
            {
                var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new
                    {
                        controller = "Account",
                        action = "Login",
                        returnUrl = returnUrl.ToString()
                    }));
            }

        }
    }
}