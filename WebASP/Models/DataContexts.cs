namespace WebASP.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContexts : DbContext
    {
        public DataContexts()
            : base("name=DataContexts2")
        {
        }

        public virtual DbSet<BaoHanh> BaoHanh { get; set; }
        public virtual DbSet<ChiTietBH> ChiTietBH { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<ChiTietKH> ChiTietKH { get; set; }
        public virtual DbSet<ChiTietNhap> ChiTietNhap { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<GiaSP> GiaSP { get; set; }
        public virtual DbSet<HinhAnhSP> HinhAnhSP { get; set; }
        public virtual DbSet<HinhThucThanhToan> HinhThucThanhToan { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMai { get; set; }
        public virtual DbSet<LoaiNV> LoaiNV { get; set; }
        public virtual DbSet<LoaiSP> LoaiSP { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuat { get; set; }
        public virtual DbSet<NhomSanPham> NhomSanPham { get; set; }
        public virtual DbSet<PhieuNhapSP> PhieuNhapSP { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TrangThaiDonHang> TrangThaiDonHang { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
