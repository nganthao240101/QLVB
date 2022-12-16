using QuanLyVanBan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace QuanLyVanBan.Query
{
    public class Query

    {
        public  static async Task<List<VanBanDen>> getList()
        {
            using (Model1 db = new Model1())
            {
                List<VanBanDen> list = db.VanBanDens.ToList();
                return list;
            }
        }
    }
}