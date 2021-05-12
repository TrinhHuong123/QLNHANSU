using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLNHANSU.Models
{
    [Table("KHENTHUONG-KYLUATs")]
    public class KHENTHUONG_KYLUAT
    {
        [Key]
        public int SoQD { get; set; }
        public string TenNV { get; set; }
        public string MaNV { get; set; }
        public string LyDo { get; set; }
        public string HinhThuc { get; set; }
        public int SoTien { get; set; }
        public virtual NHANVIEN NHANVIENs { get; set; }
    }
}