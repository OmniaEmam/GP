using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewGP.Models
{
    public class Admin
    {
      [Key]  public int adminId { get; set; }
      [Required]  public string Username { get; set; }
        [Required]  public string Email { get; set; }
        [Required , DataType(DataType.Password)]  public string Password { get; set; }
        [Required]  public string adress { get; set; }
        [Required] public int phone { get; set; }
        public int Role { get; set; }
    }
}