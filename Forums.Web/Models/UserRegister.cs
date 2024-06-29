using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forums.Web.Models
{
    public class UserRegister
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 5, ErrorMessage ="Username MINIM 5 - MAXIM 30")]
        public string Credential { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password MINIM 8 - MAXIM 50")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "ConfirmPassword")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password MINIM 8 - MAXIM 50")]
        [Compare("Password", ErrorMessage = "Passwords are not the same.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(30, ErrorMessage = "Email is incorect")]
        public string Email { get; set; }

        [Display(Name = "InfoBlog")]
        [StringLength(150, ErrorMessage = "InfoBlog MAXIM 30")]
        public string InfoBlog { get; set; }

        [Required]
        public int VerificationCode { get; set; }
    }
}