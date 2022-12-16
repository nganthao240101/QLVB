namespace QuanLyVanBan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VanBanDen")]
    public partial class VanBanDen
    {
        [Key]
        public int MaVanBanDen { get; set; }

        [StringLength(100)]
        public string ThuTruongDuyet { get; set; }

        [StringLength(11)]
        public string SoVanBan { get; set; }

        [StringLength(30)]
        public string KyHieuVanBan { get; set; }

        [StringLength(30)]
        public string NgonNgu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayVanBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanGiaiQuyet { get; set; }

        public int? SoBan { get; set; }

        public int? SoTo { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDen { get; set; }

        [StringLength(50)]
        public string HoTenNguoiKy { get; set; }

        [StringLength(100)]
        public string ChucVuNguoiKy { get; set; }

        [StringLength(20)]
        public string SoHoSo { get; set; }

        public bool? TinhTrang { get; set; }

        [StringLength(200)]
        public string CoQuanBanHanh { get; set; }

        [StringLength(500)]
        public string TrichYeu { get; set; }

        [Column("_file")]
        [StringLength(200)]
        public string C_file { get; set; }

        public int? TrangThaiXuLy { get; set; }

        public bool? TrangThaiVanBan { get; set; }

        public bool? ThuHoi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTraBaoMat { get; set; }

        [StringLength(15)]
        public string MaDonVi { get; set; }

        public int? MaLinhVuc { get; set; }

        [StringLength(100)]
        public string MaLoaiVanBan { get; set; }

        public int? MaDoMat { get; set; }

        public int? MaDoKhan { get; set; }

        public virtual DoKhan DoKhan { get; set; }

        public virtual DoMat DoMat { get; set; }

        public virtual DonVi DonVi { get; set; }

        public virtual LinhVucVanBan LinhVucVanBan { get; set; }

        public virtual LoaiVanBan LoaiVanBan { get; set; }
    }
}
