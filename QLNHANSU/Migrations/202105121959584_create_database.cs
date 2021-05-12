namespace QLNHANSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BANGCHAMCONGs",
                c => new
                    {
                        MaCC = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaNV = c.String(maxLength: 128, unicode: false),
                        TenNV = c.String(),
                        SoNgayNghi = c.Single(nullable: false),
                        SoNgayDiLam = c.Single(nullable: false),
                        TongNgayCong = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MaCC)
                .ForeignKey("dbo.NHANVIENs", t => t.MaNV)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.NHANVIENs",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 128, unicode: false),
                        TenNV = c.String(),
                        SĐT = c.String(),
                        DiaChi = c.String(),
                        ChucVu = c.String(),
                        MaCV = c.String(maxLength: 128, unicode: false),
                        GioiTinh = c.String(),
                        PhongBan = c.String(),
                        NgaykiHD = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaNV)
                .ForeignKey("dbo.CHUCVUs", t => t.MaCV)
                .Index(t => t.MaCV);
            
            CreateTable(
                "dbo.BANGLUONGs",
                c => new
                    {
                        MaLuong = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaNV = c.String(maxLength: 128, unicode: false),
                        HeSoLuong = c.Single(nullable: false),
                        BacLuong = c.Single(nullable: false),
                        TongNgayCong = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MaLuong)
                .ForeignKey("dbo.NHANVIENs", t => t.MaNV)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.CHUCVUs",
                c => new
                    {
                        MaCV = c.String(nullable: false, maxLength: 128, unicode: false),
                        TenCV = c.String(),
                        MaPB = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.MaCV)
                .ForeignKey("dbo.PHONGBANs", t => t.MaPB)
                .Index(t => t.MaPB);
            
            CreateTable(
                "dbo.PHONGBANs",
                c => new
                    {
                        MaPB = c.String(nullable: false, maxLength: 128, unicode: false),
                        TenPB = c.String(),
                    })
                .PrimaryKey(t => t.MaPB);
            
            CreateTable(
                "dbo.DUANs",
                c => new
                    {
                        MaDuAn = c.String(nullable: false, maxLength: 50, unicode: false),
                        TenDuAn = c.String(),
                        MaNhanVien = c.String(),
                        Ngaybatdau = c.DateTime(nullable: false),
                        Ngaygiahan = c.DateTime(nullable: false),
                        Ngayketthuc = c.DateTime(nullable: false),
                        SoLuong = c.String(),
                        DonGia = c.String(),
                        ChietKhau = c.String(),
                        NHANVIENs_MaNV = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.MaDuAn)
                .ForeignKey("dbo.NHANVIENs", t => t.NHANVIENs_MaNV)
                .Index(t => t.NHANVIENs_MaNV);
            
            CreateTable(
                "dbo.KHENTHUONG-KYLUATs",
                c => new
                    {
                        SoQD = c.Int(nullable: false, identity: true),
                        TenNV = c.String(),
                        MaNV = c.String(maxLength: 128, unicode: false),
                        LyDo = c.String(),
                        HinhThuc = c.String(),
                        SoTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SoQD)
                .ForeignKey("dbo.NHANVIENs", t => t.MaNV)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.TRINHDO-CMs",
                c => new
                    {
                        STT = c.Int(nullable: false, identity: true),
                        TenNV = c.String(),
                        MaNV = c.String(maxLength: 128, unicode: false),
                        TDCM = c.String(),
                        TDNN = c.String(),
                    })
                .PrimaryKey(t => t.STT)
                .ForeignKey("dbo.NHANVIENs", t => t.MaNV)
                .Index(t => t.MaNV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TRINHDO-CMs", "MaNV", "dbo.NHANVIENs");
            DropForeignKey("dbo.KHENTHUONG-KYLUATs", "MaNV", "dbo.NHANVIENs");
            DropForeignKey("dbo.DUANs", "NHANVIENs_MaNV", "dbo.NHANVIENs");
            DropForeignKey("dbo.CHUCVUs", "MaPB", "dbo.PHONGBANs");
            DropForeignKey("dbo.NHANVIENs", "MaCV", "dbo.CHUCVUs");
            DropForeignKey("dbo.BANGLUONGs", "MaNV", "dbo.NHANVIENs");
            DropForeignKey("dbo.BANGCHAMCONGs", "MaNV", "dbo.NHANVIENs");
            DropIndex("dbo.TRINHDO-CMs", new[] { "MaNV" });
            DropIndex("dbo.KHENTHUONG-KYLUATs", new[] { "MaNV" });
            DropIndex("dbo.DUANs", new[] { "NHANVIENs_MaNV" });
            DropIndex("dbo.CHUCVUs", new[] { "MaPB" });
            DropIndex("dbo.BANGLUONGs", new[] { "MaNV" });
            DropIndex("dbo.NHANVIENs", new[] { "MaCV" });
            DropIndex("dbo.BANGCHAMCONGs", new[] { "MaNV" });
            DropTable("dbo.TRINHDO-CMs");
            DropTable("dbo.KHENTHUONG-KYLUATs");
            DropTable("dbo.DUANs");
            DropTable("dbo.PHONGBANs");
            DropTable("dbo.CHUCVUs");
            DropTable("dbo.BANGLUONGs");
            DropTable("dbo.NHANVIENs");
            DropTable("dbo.BANGCHAMCONGs");
        }
    }
}
