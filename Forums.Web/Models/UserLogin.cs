using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forums.Web.Models
{
    public class UserLogin
    {
        [Required]
        [Display(Name = "Username")]
        public string Credential { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}