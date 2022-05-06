using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CodeSampleAPI.DAL
{
    public partial class CodeSampleContext : DbContext
    {
        public CodeSampleContext()
        {
        }

        public CodeSampleContext(DbContextOptions<CodeSampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BaiLamKiemTra> BaiLamKiemTras { get; set; }
        public virtual DbSet<BaiTapCode> BaiTapCodes { get; set; }
        public virtual DbSet<BaiTapTracNghiem> BaiTapTracNghiems { get; set; }
        public virtual DbSet<CtBaiLamCode> CtBaiLamCodes { get; set; }
        public virtual DbSet<CtBaiLamTracNghiem> CtBaiLamTracNghiems { get; set; }
        public virtual DbSet<CtDeKiemTraCode> CtDeKiemTraCodes { get; set; }
        public virtual DbSet<CtDeKiemTraTracNghiem> CtDeKiemTraTracNghiems { get; set; }
        public virtual DbSet<CtLuyenTap> CtLuyenTaps { get; set; }
        public virtual DbSet<CtPhongHoc> CtPhongHocs { get; set; }
        public virtual DbSet<DaHoc> DaHocs { get; set; }
        public virtual DbSet<DeKiemTra> DeKiemTras { get; set; }
        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<LyThuyet> LyThuyets { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<PhongHoc> PhongHocs { get; set; }
        public virtual DbSet<TestCase> TestCases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CT0V15K\\SQLEXPRESS;Database=CodeSample;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.TaiKhoan);

                entity.ToTable("Admin");

                entity.Property(e => e.TaiKhoan).HasMaxLength(50);

                entity.Property(e => e.IdGiangVien)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ID_GiangVien");

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdGiangVienNavigation)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.IdGiangVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admin_GiangVien");
            });

            modelBuilder.Entity<BaiLamKiemTra>(entity =>
            {
                entity.ToTable("BaiLamKiemTra");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdDeKiemTra).HasColumnName("ID_DeKiemTra");

                entity.Property(e => e.NgayNopBai).HasColumnType("datetime");

                entity.Property(e => e.UIdNguoiDung)
                    .HasMaxLength(50)
                    .HasColumnName("uID_NguoiDung");

                entity.HasOne(d => d.IdDeKiemTraNavigation)
                    .WithMany(p => p.BaiLamKiemTras)
                    .HasForeignKey(d => d.IdDeKiemTra)
                    .HasConstraintName("FK_BaiLamKiemTra_DeKiemTra");

                entity.HasOne(d => d.UIdNguoiDungNavigation)
                    .WithMany(p => p.BaiLamKiemTras)
                    .HasForeignKey(d => d.UIdNguoiDung)
                    .HasConstraintName("FK_BaiLamKiemTra_NguoiDung");
            });

            modelBuilder.Entity<BaiTapCode>(entity =>
            {
                entity.ToTable("BaiTapCode");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DeBai)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.DoKho)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.TieuDe).HasMaxLength(100);

                entity.Property(e => e.UIdNguoiTao)
                    .HasMaxLength(50)
                    .HasColumnName("uID_NguoiTao");

                entity.HasOne(d => d.UIdNguoiTaoNavigation)
                    .WithMany(p => p.BaiTapCodes)
                    .HasForeignKey(d => d.UIdNguoiTao)
                    .HasConstraintName("FK_BaiTapCode_GiangVien");
            });

            modelBuilder.Entity<BaiTapTracNghiem>(entity =>
            {
                entity.ToTable("BaiTapTracNghiem");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CauHoi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CauTraLoi1).HasMaxLength(50);

                entity.Property(e => e.CauTraLoi2).HasMaxLength(50);

                entity.Property(e => e.CauTraLoi3).HasMaxLength(50);

                entity.Property(e => e.CauTraLoi4).HasMaxLength(50);

                entity.Property(e => e.UIdNguoiTao)
                    .HasMaxLength(50)
                    .HasColumnName("uID_NguoiTao");

                entity.HasOne(d => d.UIdNguoiTaoNavigation)
                    .WithMany(p => p.BaiTapTracNghiems)
                    .HasForeignKey(d => d.UIdNguoiTao)
                    .HasConstraintName("FK_BaiTapTracNghiem_GiangVien");
            });

            modelBuilder.Entity<CtBaiLamCode>(entity =>
            {
                entity.HasKey(e => new { e.IdBaiLamKt, e.IdDeKiemTra, e.IdBaiTapCode })
                    .HasName("PK_CT_BaiLamKTCode");

                entity.ToTable("CT_BaiLamCode");

                entity.Property(e => e.IdBaiLamKt).HasColumnName("ID_BaiLamKT");

                entity.Property(e => e.IdDeKiemTra).HasColumnName("ID_DeKiemTra");

                entity.Property(e => e.IdBaiTapCode).HasColumnName("ID_BaiTapCode");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IdBaiLamKtNavigation)
                    .WithMany(p => p.CtBaiLamCodes)
                    .HasForeignKey(d => d.IdBaiLamKt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_BaiLamCode_BaiLamKiemTra");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.CtBaiLamCodes)
                    .HasForeignKey(d => new { d.IdDeKiemTra, d.IdBaiTapCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_BaiLamCode_CT_DeKiemTraCode");
            });

            modelBuilder.Entity<CtBaiLamTracNghiem>(entity =>
            {
                entity.HasKey(e => new { e.IdBaiLamKt, e.IdDeKiemTra, e.IdBaiTapTracNghiem });

                entity.ToTable("CT_BaiLamTracNghiem");

                entity.Property(e => e.IdBaiLamKt).HasColumnName("ID_BaiLamKT");

                entity.Property(e => e.IdDeKiemTra).HasColumnName("ID_DeKiemTra");

                entity.Property(e => e.IdBaiTapTracNghiem).HasColumnName("ID_BaiTapTracNghiem");

                entity.HasOne(d => d.IdBaiLamKtNavigation)
                    .WithMany(p => p.CtBaiLamTracNghiems)
                    .HasForeignKey(d => d.IdBaiLamKt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_BaiLamTracNghiem_BaiLamKiemTra");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.CtBaiLamTracNghiems)
                    .HasForeignKey(d => new { d.IdDeKiemTra, d.IdBaiTapTracNghiem })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_BaiLamTracNghiem_CT_DeKiemTraTracNghiem");
            });

            modelBuilder.Entity<CtDeKiemTraCode>(entity =>
            {
                entity.HasKey(e => new { e.IdDeKiemTra, e.IdBaiTapCode });

                entity.ToTable("CT_DeKiemTraCode");

                entity.Property(e => e.IdDeKiemTra).HasColumnName("ID_DeKiemTra");

                entity.Property(e => e.IdBaiTapCode).HasColumnName("ID_BaiTapCode");

                entity.Property(e => e.SttCauHoi).HasColumnName("STT_CauHoi");

                entity.HasOne(d => d.IdBaiTapCodeNavigation)
                    .WithMany(p => p.CtDeKiemTraCodes)
                    .HasForeignKey(d => d.IdBaiTapCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_DeKiemTraCode_BaiTapCode");

                entity.HasOne(d => d.IdDeKiemTraNavigation)
                    .WithMany(p => p.CtDeKiemTraCodes)
                    .HasForeignKey(d => d.IdDeKiemTra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_DeKiemTraCode_DeKiemTra");
            });

            modelBuilder.Entity<CtDeKiemTraTracNghiem>(entity =>
            {
                entity.HasKey(e => new { e.IdDeKiemTra, e.IdBaiTapTracNghiem });

                entity.ToTable("CT_DeKiemTraTracNghiem");

                entity.Property(e => e.IdDeKiemTra).HasColumnName("ID_DeKiemTra");

                entity.Property(e => e.IdBaiTapTracNghiem).HasColumnName("ID_BaiTapTracNghiem");

                entity.Property(e => e.SttCauHoi).HasColumnName("STT_CauHoi");

                entity.HasOne(d => d.IdBaiTapTracNghiemNavigation)
                    .WithMany(p => p.CtDeKiemTraTracNghiems)
                    .HasForeignKey(d => d.IdBaiTapTracNghiem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_DeKiemTraTracNghiem_BaiTapTracNghiem");

                entity.HasOne(d => d.IdDeKiemTraNavigation)
                    .WithMany(p => p.CtDeKiemTraTracNghiems)
                    .HasForeignKey(d => d.IdDeKiemTra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_DeKiemTraTracNghiem_DeKiemTra");
            });

            modelBuilder.Entity<CtLuyenTap>(entity =>
            {
                entity.HasKey(e => new { e.UIdNguoiDung, e.IdBaiTap });

                entity.ToTable("CT_LuyenTap");

                entity.Property(e => e.UIdNguoiDung)
                    .HasMaxLength(50)
                    .HasColumnName("uID_NguoiDung");

                entity.Property(e => e.IdBaiTap).HasColumnName("ID_BaiTap");

                entity.Property(e => e.Code).HasMaxLength(1000);

                entity.HasOne(d => d.IdBaiTapNavigation)
                    .WithMany(p => p.CtLuyenTaps)
                    .HasForeignKey(d => d.IdBaiTap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_LuyenTap_BaiTapCode");

                entity.HasOne(d => d.UIdNguoiDungNavigation)
                    .WithMany(p => p.CtLuyenTaps)
                    .HasForeignKey(d => d.UIdNguoiDung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_LuyenTap_NguoiDung");
            });

            modelBuilder.Entity<CtPhongHoc>(entity =>
            {
                entity.HasKey(e => new { e.UIdNguoiDung, e.IdPhongHoc });

                entity.ToTable("CT_PhongHoc");

                entity.Property(e => e.UIdNguoiDung)
                    .HasMaxLength(50)
                    .HasColumnName("uID_NguoiDung");

                entity.Property(e => e.IdPhongHoc).HasColumnName("ID_PhongHoc");

                entity.Property(e => e.NgayThamGia).HasColumnType("date");

                entity.HasOne(d => d.IdPhongHocNavigation)
                    .WithMany(p => p.CtPhongHocs)
                    .HasForeignKey(d => d.IdPhongHoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_PhongHoc_PhongHoc");

                entity.HasOne(d => d.UIdNguoiDungNavigation)
                    .WithMany(p => p.CtPhongHocs)
                    .HasForeignKey(d => d.UIdNguoiDung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_PhongHoc_NguoiDung");
            });

            modelBuilder.Entity<DaHoc>(entity =>
            {
                entity.HasKey(e => new { e.IdLyThuyet, e.UIdNguoiDung });

                entity.ToTable("DaHoc");

                entity.Property(e => e.IdLyThuyet).HasColumnName("ID_LyThuyet");

                entity.Property(e => e.UIdNguoiDung)
                    .HasMaxLength(50)
                    .HasColumnName("uID_NguoiDung");

                entity.HasOne(d => d.IdLyThuyetNavigation)
                    .WithMany(p => p.DaHocs)
                    .HasForeignKey(d => d.IdLyThuyet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DaHoc_LyThuyet");

                entity.HasOne(d => d.UIdNguoiDungNavigation)
                    .WithMany(p => p.DaHocs)
                    .HasForeignKey(d => d.UIdNguoiDung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DaHoc_NguoiDung");
            });

            modelBuilder.Entity<DeKiemTra>(entity =>
            {
                entity.ToTable("DeKiemTra");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdPhong).HasColumnName("ID_Phong");

                entity.Property(e => e.MoTa).HasMaxLength(50);

                entity.Property(e => e.NgayHetHan).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.HasOne(d => d.IdPhongNavigation)
                    .WithMany(p => p.DeKiemTras)
                    .HasForeignKey(d => d.IdPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeKiemTra_PhongHoc");
            });

            modelBuilder.Entity<GiangVien>(entity =>
            {
                entity.HasKey(e => e.UId);

                entity.ToTable("GiangVien");

                entity.Property(e => e.UId)
                    .HasMaxLength(50)
                    .HasColumnName("uID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NamSinh).HasColumnType("date");

                entity.Property(e => e.Truong).HasMaxLength(50);
            });

            modelBuilder.Entity<LyThuyet>(entity =>
            {
                entity.ToTable("LyThuyet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdMonHoc).HasColumnName("ID_MonHoc");

                entity.Property(e => e.NoiDung)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.TieuDe)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdMonHocNavigation)
                    .WithMany(p => p.LyThuyets)
                    .HasForeignKey(d => d.IdMonHoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LyThuyet_MonHoc");
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.ToTable("MonHoc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HinhAnh).HasMaxLength(50);

                entity.Property(e => e.MoTa)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TenMonHoc)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.UId);

                entity.ToTable("NguoiDung");

                entity.Property(e => e.UId)
                    .HasMaxLength(50)
                    .HasColumnName("uID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NamSinh).HasColumnType("date");

                entity.Property(e => e.Truong).HasMaxLength(50);
            });

            modelBuilder.Entity<PhongHoc>(entity =>
            {
                entity.ToTable("PhongHoc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdChuPhong)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ID_ChuPhong");

                entity.Property(e => e.TenPhong)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdChuPhongNavigation)
                    .WithMany(p => p.PhongHocs)
                    .HasForeignKey(d => d.IdChuPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhongHoc_GiangVien");
            });

            modelBuilder.Entity<TestCase>(entity =>
            {
                entity.ToTable("TestCase");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdBaiTap).HasColumnName("ID_BaiTap");

                entity.Property(e => e.Intput)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("intput");

                entity.Property(e => e.Output)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("output");

                entity.HasOne(d => d.IdBaiTapNavigation)
                    .WithMany(p => p.TestCases)
                    .HasForeignKey(d => d.IdBaiTap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestCase_BaiTapCode");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
