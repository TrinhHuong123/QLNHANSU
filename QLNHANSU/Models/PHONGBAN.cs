using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLNHANSU.Models
{
    [Table("PHONGBANs")]
    public class PHONGBAN
    {
        [Key]
        public string MaPB { get; set; }



        public string TenPB { get; set; }
        public virtual ICollection<CHUCVU> CHUCVUs { get; set; }
    }
}