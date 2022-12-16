namespace QuanLyVanBan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietQuyen")]
    public partial class ChiTietQuyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaChiTietQuyen { get; set; }

        [Required]
        [StringLength(100)]
        public string ChucNang { get; set; }

        public bool? CheckQuyen_ChucNang { get; set; }

        public int? MaNhomQuyen { get; set; }

        public int? MaQuyen { get; set; }

        public virtual NhomQuyen NhomQuyen { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
