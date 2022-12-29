namespace QuanLyVanBan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichSuThayDoi")]
    public partial class LichSuThayDoi
    {
        [Key]
        public int MaThayDoi { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianThucHien { get; set; }

        public int? MaCaNhan { get; set; }

        public int? MaVanBanDen { get; set; }

        public int? MaVanBanDi { get; set; }

        public virtual CaNhan CaNhan { get; set; }

        public virtual VanBanDen VanBanDen { get; set; }

        public virtual VanBanDi VanBanDi { get; set; }
    }
}
