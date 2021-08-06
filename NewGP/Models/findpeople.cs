using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewGP.Models
{
    public class findpeople
    {
        private const string V = "Last name";

        [Key] public int id { get; set; }
        [Required(ErrorMessage = "name is required"), MinLength(3), Column(TypeName = "VARCHAR"), Display(Name = "First name")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "name is required"), MinLength(3), Column(TypeName = "VARCHAR"), Display(Name ="Last Name")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Birth day is required"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "When you found this person ?")]
        public DateTime Dateoffound { get; set; }
        [ Display(Name = "Put image for this person")]
        public string Image { get; set; }
        [Required]
        public int Age { get; set; }
        [Required(ErrorMessage = "gender is required"), Display(Name = "Gender")]
        public string Ismale { get; set; }
        [Required(ErrorMessage = "Place where you found in is required")]
        [Display(Name = "Where you found this person ?")]
        public string placefound { get; set; }
        [Required(ErrorMessage = "Palce that you  in is required")]
        [Display(Name = "Current Address")]
        public string current { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }
        [Display(Name = "Was there surveillance cameras?")]
        public bool tvcc { get; set; }
        [Required(ErrorMessage = "Feateres is required")]
        [Display(Name = "Add some of his features")]
        public string PersonFeature { get; set; }
        [Required(ErrorMessage = " Required")]
        [Display(Name = "What he was wearing?")]
        public string DescripClothes { get; set; }
        [Required(ErrorMessage = " Required")]
        [Display(Name = "How you found this person?")]
        public string story { get; set; }
        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User user { get; set; }
        [ScaffoldColumn(false)]
        public int? adminId { get; set; }
        [ForeignKey("adminId")]
        public virtual Admin admin { get; set; }
        public DateTime? Creaton { get; set; }
}}