using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLNHANSU.Models
{
    [Table("NHANVIENs")]
    public class NHANVIEN
    {
        [Key]
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string SĐT { get; set; }
        public string DiaChi { get; set; }
        public string ChucVu { get; set; }
        public string MaCV { get; set; }
        public string GioiTinh { get; set; }
        public string PhongBan { get; set; }
        public DateTime NgaykiHD { get; set; }
        public virtual ICollection<DUAN> DUANs { get; set; }
        public virtual ICollection<TRINHDO_CM> TRINHDO_CMs { get; set; }
        public virtual ICollection<BANGLUONG> BANGLUONGs { get; set; }
        public virtual ICollection<BANGCHAMCONG> BANGCHAMCONGs { get; set; }
        public virtual ICollection<KHENTHUONG_KYLUAT> KHENTHUONG_KYLUATs { get; set; }
        public virtual CHUCVU CHUCVUs { get; set; }
    }
}