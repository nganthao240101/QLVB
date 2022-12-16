namespace QuanLyVanBan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NguoiDung_ChiTietQuyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNguoiDung_ChiTietQuyen { get; set; }

        public int? MaNhomQuyen { get; set; }

        public int? MaCaNhan { get; set; }

        public virtual CaNhan CaNhan { get; set; }

        public virtual NhomQuyen NhomQuyen { get; set; }
    }
}
