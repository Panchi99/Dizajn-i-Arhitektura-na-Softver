using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dizajn_i_Arhitektura_na_Softver.Models
{
    public class SendMail
    {
        [Required, Display(Name = "Your name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        [Required, Display(Name ="Your Password"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}