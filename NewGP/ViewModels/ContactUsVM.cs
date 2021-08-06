using System;
using System.ComponentModel.DataAnnotations;

namespace NewGP.ViewModels
{
    public class ContactUsVM
    {
        [Required(ErrorMessage = "Fullname is required"), MinLength(5)]
         public string Fullname { get; set; }
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Message is required"), MinLength(10)]
        public string Message { get; set; }
    }
}