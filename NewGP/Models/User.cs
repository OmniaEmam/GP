using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewGP.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "name is required"), MinLength(5), Index(IsUnique = true), Column(TypeName = "VARCHAR")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Birth day is required"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Brithdate { get; set; }
        [Required(ErrorMessage = "gender is required")]
        public string Ismale { get; set; }
        [Required(ErrorMessage = "country is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "city is required")]
        public string city { get; set; }
        [Required(ErrorMessage = "e-mail is required"), EmailAddress, Index(IsUnique = true), Column(TypeName = "VARCHAR")]
        public string Email { get; set; }
        [Required(ErrorMessage = "password is required"), MinLength(5), DataType(DataType.Password)]
        public string Password { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Picture")]
        public string ImageUrl { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? Creaton { get; set; }

        public string token { get; set; }
        [Required(ErrorMessage = "Token is required")]

        public bool verified { get; set; }
        [Required(ErrorMessage = "False/True")]

        public int Role { get; set; }
    }
}