using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLNHANSU.Models
{
    [Table("BANGLUONGs")]
    public class BANGLUONG
    {
        [Key]
        [StringLength(50)]
        public string MaLuong { get; set; }



        public string MaNV { get; set; }
        public float HeSoLuong { get; set; }
        public float BacLuong { get; set; }
        public float TongNgayCong { get; set; }



        public virtual NHANVIEN NHANVIENs { get; set; }
    }
}