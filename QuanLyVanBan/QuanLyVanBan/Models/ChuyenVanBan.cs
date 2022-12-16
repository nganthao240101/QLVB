namespace QuanLyVanBan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChuyenVanBan")]
    public partial class ChuyenVanBan
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string MaDonVi { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaVanBanDen { get; set; }

        [StringLength(200)]
        public string NoiNhan { get; set; }

        public int? SoPhat { get; set; }

        public virtual DonVi DonVi { get; set; }
    }
}
