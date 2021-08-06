using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewGP.Models
{
    public class Volanteer
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public int PhoneNum { get; set; }

        public string WorkPlace { get; set; }

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