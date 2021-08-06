using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewGP.Models
{
    public class Kidnap
    {
      [Key]  public int id { get; set; }
        [Required,Display(Name= "What is the name of the criminal?")]
        public string Name { get; set; }
        [Required, Display(Name = "What is his type?")]
        public string ismale {get;set;}
        [Required, Display(Name = "Write about an accedient..")]
        public string Aboutacciedance { get; set; }
        [Required, Display(Name = "What is the address of this accedient?")]
        public string placehappend { get; set; }
        [ Display(Name = "Put his image")]
        public string image { get; set; }
        [Display(Name = "Was there surveillance cameras?")]
        public bool cctv { get; set; }
        [ScaffoldColumn(false)]
        public DateTime creaton { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User user { get; set; }



    }
}