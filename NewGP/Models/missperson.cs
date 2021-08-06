using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewGP.Models
{
    public class missperson
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "name is required"), MinLength(3), Column(TypeName = "VARCHAR"), Display(Name = "First name")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "name is required"), MinLength(3), Column(TypeName = "VARCHAR"), Display(Name = "Last name")]
        public string Lname { get; set; }
        [Display(Name = "Put imge for this person")]
        public string Image { get; set; }
        [Required]
        public int Age { get; set; }
        [Required(ErrorMessage = "Birth day is required"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "When you lost him?")]
        public DateTime Dateofmiss { get; set; }
        [Required(ErrorMessage = "gender is required"), Display(Name = "Gender")]
        public string Ismale { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }
        [Required(ErrorMessage = "Place that you miss in is required")]
        [Display(Name = "Where was the last time met?")]
        public string placemiss { get; set; }
        [Display(Name = "Was there surveillance cameras?")]
        public bool cctv { get; set; }
        [Required(ErrorMessage = "Feateres is required")]
        [Display(Name = "Add some of his features")]
        public string PersonFeature { get; set; }
        [Required(ErrorMessage = " Required")]
        [Display(Name = "What he was wearing?")]
        public string DescripClothes { get; set; }
        [Required(ErrorMessage = " Required")]
        [Display(Name = "How did the accident happen?")]
        public string story { get; set; }
        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User user { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? Creaton { get; set; }
        public int? adminId { get; set; }
        [ForeignKey("adminId")]
        public virtual Admin admin { get; set; }

    }
}