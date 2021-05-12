using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLNHANSU.Models
{
    [Table(" BANGCHAMCONGs")]
    public class BANGCHAMCONG
    {
        [Key]
        [StringLength(50)]
        public string MaCC { get; set; }



        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public float SoNgayNghi { get; set; }
        public float SoNgayDiLam { get; set; }
        public float TongNgayCong { get; set; }
        public virtual NHANVIEN NHANVIENs { get; set; }
    }
}