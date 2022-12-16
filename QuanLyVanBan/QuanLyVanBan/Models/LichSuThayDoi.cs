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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaThayDoi { get; set; }

        [Required]
        [StringLength(256)]
        public string SuKien { get; set; }

        [Required]
        [StringLength(256)]
        public string TenDoiTuong { get; set; }

        [Required]
        [StringLength(256)]
        public string LoaiDoiTuong { get; set; }

        [Required]
        public string CauLenhSQL { get; set; }

        public DateTime ThoiGianThucHien { get; set; }

        public int? MaCaNhan { get; set; }

        public virtual CaNhan CaNhan { get; set; }
    }
}
