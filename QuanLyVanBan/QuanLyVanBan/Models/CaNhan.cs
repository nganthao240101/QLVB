namespace QuanLyVanBan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CaNhan")]
    public partial class CaNhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CaNhan()
        {
            LichSuThayDois = new HashSet<LichSuThayDoi>();
            NguoiDung_ChiTietQuyen = new HashSet<NguoiDung_ChiTietQuyen>();
        }

        [Key]
        public int MaCaNhan { get; set; }

        [StringLength(50)]
        public string TenCaNhan { get; set; }

        public int? SDT { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        [StringLength(15)]
        public string MaDonVi { get; set; }

        public int? MaChucVu { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        public virtual DonVi DonVi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuThayDoi> LichSuThayDois { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguoiDung_ChiTietQuyen> NguoiDung_ChiTietQuyen { get; set; }
    }
}
