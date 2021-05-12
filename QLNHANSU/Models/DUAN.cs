using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLNHANSU.Models
{
    [Table(" DUANs")]
    public class DUAN
    {
        [Key]
        [StringLength(50)]
        public string MaDuAn { get; set; }
        public string TenDuAn { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime Ngaybatdau { get; set; }
        public DateTime Ngaygiahan { get; set; }
        public DateTime Ngayketthuc { get; set; }
        public string SoLuong { get; set; }
        public string DonGia { get; set; }
        public string ChietKhau { get; set; }



        public virtual NHANVIEN NHANVIENs { get; set; }
    }
}