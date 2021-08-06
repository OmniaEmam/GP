using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewGP.Models
{
    public class Crimesvidio
    {
        [Key] public int id { get; set; }
        [Required] [Display(Name ="Vedio Title ")] public string Vname { get; set; }
        [Required] [Display(Name = "Choose file ")] public string Vfile { get; set; }
        [Display(Name = "Put your comment or story")] public string comment { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User user { get; set; }
    }
}