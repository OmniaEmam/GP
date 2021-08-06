using System;
using System.ComponentModel.DataAnnotations;

namespace NewGP.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "name is required"), MinLength(5)]
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
        [Required(ErrorMessage = "e-mail is required"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "password is required"), MinLength(5), DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password"), DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string confirmPassword { get; set; }
    }
}