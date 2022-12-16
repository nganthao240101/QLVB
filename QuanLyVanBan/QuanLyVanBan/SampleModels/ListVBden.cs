using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyVanBan.SampleModels
{
    public class ListVBden
    {
        public int MaVanBanDen { get; set; }



        [StringLength(11)]
        public string SoVanBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayVanBan { get; set; }

        [StringLength(200)]
        public string CoQuanBanHanh { get; set; }

        [StringLength(500)]
        public string TrichYeu { get; set; }
        public int? SoBan { get; set; }

        public int? SoTo { get; set; }

        [StringLength(50)]
        public string TenLoaiVanBan { get; set; }

        [StringLength(50)]
        public string TenDoMat { get; set; }
        [StringLength(50)]
        public string TenDoKhan { get; set; }
        public bool? TinhTrang { get; set; }

    }
}