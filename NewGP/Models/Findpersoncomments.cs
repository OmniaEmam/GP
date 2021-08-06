using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewGP.Models
{
    public class Findpersoncomments
    {
        public int Id { get; set; }
        public string text { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? Creaton { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User user { get; set; }
        public int findpeopleId { get; set; }
        [ForeignKey("findpeopleId")]
        public virtual findpeople Findpeople { get; set; }



    }
}