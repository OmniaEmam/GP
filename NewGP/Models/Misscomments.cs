using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewGP.Models
{
    public class Misscomments
    {
        public int Id { get; set; }
        public string text { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? Creaton { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User user { get; set; }
        public int misspersonId { get; set; }
        [ForeignKey("misspersonId")]
        public virtual missperson missperson { get; set; }


    }
}