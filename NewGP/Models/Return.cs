
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewGP.Models
{
    public class Return
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "name is required"), MinLength(3), Column(TypeName = "VARCHAR"), Display(Name = "First name")]

        public string Fname { get; set; }
        [Required(ErrorMessage = "name is required"), MinLength(3), Column(TypeName = "VARCHAR"), Display(Name = "Last name")]
        public string Lname { get; set; }
        [Display(Name = "Name is required")]
        public string Image { get; set; }
        [Required]
        public DateTime DateofmissOrfound { get; set; }
        [Required(ErrorMessage = "Date is required")]



        public DateTime ReturnDate { get; set; }

        public string Returnstory { get; set; }



        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User user { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? Creaton { get; set; }
    }
}

