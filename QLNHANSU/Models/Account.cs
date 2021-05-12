using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNHANSU.Models
{
    public class Account
    {
        [Key]
        //validation with model
        //username không được để trống
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        //password khong duoc de trong
        [Required(ErrorMessage = "Password is required.")]
        //dinh nghia DataType
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string RoleID { get; set; }
    }
}