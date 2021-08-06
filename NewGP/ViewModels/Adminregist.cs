using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewGP.ViewModels
{
    public class Adminregist
    {
        [Required] public string Username { get; set; }
        [Required] public string Email { get; set; }
       
        [Required] public string adress { get; set; }
        [Required] public int phone { get; set; }
        public int Role { get; set; }
        [Required, DataType(DataType.Password)] public string Password { get; set; }
        [Compare("Password"), DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string confirmPassword { get; set; }
    }
}