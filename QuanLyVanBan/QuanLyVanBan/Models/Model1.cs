using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyVanBan.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CaNhan> CaNhans { get; set; }
        public virtual DbSet<ChiTietQuyen> ChiTietQuyens { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<ChuyenVanBan> ChuyenVanBans { get; set; }
        public virtual DbSet<DoKhan> DoKhans { get; set; }
        public virtual DbSet<DoMat> DoMats { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<LichSuThayDoi> LichSuThayDois { get; set; }
        public virtual DbSet<LinhVucVanBan> LinhVucVanBans { get; set; }
        public virtual DbSet<LoaiVanBan> LoaiVanBans { get; set; }
        public virtual DbSet<NguoiDung_ChiTietQuyen> NguoiDung_ChiTietQuyen { get; set; }
        public virtual DbSet<NhomQuyen> NhomQuyens { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<VanBanDen> VanBanDens { get; set; }
        public virtual DbSet<VanBanDi> VanBanDis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaNhan>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<CaNhan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<CaNhan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<CaNhan>()
                .Property(e => e.MaDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<ChuyenVanBan>()
                .Property(e => e.MaDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<DonVi>()
                .Property(e => e.MaDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<DonVi>()
                .HasMany(e => e.ChuyenVanBans)
                .WithRequired(e => e.DonVi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LichSuThayDoi>()
                .Property(e => e.SuKien)
                .IsUnicode(false);

            modelBuilder.Entity<LichSuThayDoi>()
                .Property(e => e.TenDoiTuong)
                .IsUnicode(false);

            modelBuilder.Entity<LichSuThayDoi>()
                .Property(e => e.LoaiDoiTuong)
                .IsUnicode(false);

            modelBuilder.Entity<LichSuThayDoi>()
                .Property(e => e.CauLenhSQL)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiVanBan>()
                .Property(e => e.MaLoaiVanBan)
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDen>()
                .Property(e => e.SoVanBan)
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDen>()
                .Property(e => e.KyHieuVanBan)
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDen>()
                .Property(e => e.SoHoSo)
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDen>()
                .Property(e => e.C_file)
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDen>()
                .Property(e => e.MaDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDen>()
                .Property(e => e.MaLoaiVanBan)
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDi>()
                .Property(e => e.SoVanBan)
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDi>()
                .Property(e => e.KyHieuVanBan)
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDi>()
                .Property(e => e.C_file)
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDi>()
                .Property(e => e.MaDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDi>()
                .Property(e => e.MaLoaiVanBan)
                .IsUnicode(false);
        }
    }
}
