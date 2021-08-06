using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewGP.ViewModels
{
    public class PictcurVM
    {
        [Required]
        public HttpPostedFileWrapper Picture { get; set; }

    }
}