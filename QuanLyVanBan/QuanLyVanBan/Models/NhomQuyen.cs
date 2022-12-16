namespace QuanLyVanBan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomQuyen")]
    public partial class NhomQuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhomQuyen()
        {
            ChiTietQuyens = new HashSet<ChiTietQuyen>();
            NguoiDung_ChiTietQuyen = new HashSet<NguoiDung_ChiTietQuyen>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNhomQuyen { get; set; }

        [StringLength(50)]
        public string TenNhomQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietQuyen> ChiTietQuyens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguoiDung_ChiTietQuyen> NguoiDung_ChiTietQuyen { get; set; }
    }
}
