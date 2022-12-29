namespace QuanLyVanBan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VanBanDi")]
    public partial class VanBanDi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VanBanDi()
        {
            LichSuThayDois = new HashSet<LichSuThayDoi>();
        }

        [Key]
        public int MaVanBanDi { get; set; }

        [StringLength(11)]
        public string SoVanBan { get; set; }

        [StringLength(30)]
        public string KyHieuVanBan { get; set; }

        [StringLength(30)]
        public string NgonNgu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayVanBan { get; set; }

        public int? SoBan { get; set; }

        public int? SoTo { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        [StringLength(500)]
        public string DonViNhan { get; set; }

        [StringLength(50)]
        public string HoTenNguoiKy { get; set; }

        [StringLength(50)]
        public string ChucVuNguoiKy { get; set; }

        public int? SoHoSo { get; set; }

        public int TrangThai { get; set; }

        [StringLength(500)]
        public string TrichYeu { get; set; }

        [Column("_file")]
        [StringLength(200)]
        public string C_file { get; set; }

        [StringLength(15)]
        public string MaDonVi { get; set; }

        public int? MaLinhVuc { get; set; }

        [StringLength(100)]
        public string MaLoaiVanBan { get; set; }

        public int? MaDoMat { get; set; }

        public int? MaDoKhan { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public virtual DoKhan DoKhan { get; set; }

        public virtual DoMat DoMat { get; set; }

        public virtual DonVi DonVi { get; set; }

        public virtual LinhVucVanBan LinhVucVanBan { get; set; }

        public virtual LoaiVanBan LoaiVanBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuThayDoi> LichSuThayDois { get; set; }
    }
}
