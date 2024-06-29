using Forums.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forums.Web.Models
{
    public class UserData
    {
        public string? Username { get; set; }

        [Display(Name = "Fullname")]
        [StringLength(30, ErrorMessage = "Fullname MAXIM 30")]
        public string? Fullname { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(30, ErrorMessage = "Email MAXIM 30")]
        public string Email { get; set; }

        [Display(Name = "Photo")]
        public string? Photo { get; set; }

        [Display(Name = "InfoBlog")]
        [StringLength(150, ErrorMessage = "InfoBlog MAXIM 150")]
        public string? InfoBlog { get; set; }

        [Display(Name = "Profession")]
        [StringLength(50, ErrorMessage = "Profession MAXIM 50")]
        public string? Profession { get; set; }

        [Display(Name = "PhoneNumber")]
        [StringLength(20, ErrorMessage = "PhoneNumber MAXIM 20")]
        public string? PhoneNumber { get; set; }

    }
}