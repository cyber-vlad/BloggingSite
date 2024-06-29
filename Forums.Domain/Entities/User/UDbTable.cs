using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Forums.Domain.Entities.Posts;
using Forums.Domain.Enum;

namespace Forums.Domain.Entities.User
{
    public class UDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 5)]
        public string Username { get; set; }

        
        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(30)]
        public string Email { get; set; }
     
        [Display(Name = "InfoBlog")]
        [StringLength(150)]
        public string InfoBlog { get; set; }

        [Display(Name = "Profession")]
        [StringLength(50)]
        public string Profession { get; set; }

        [Display(Name = "PhoneNumber")]
        [StringLength(20)]
        public string PhoneNumber {  get; set; }
        public string Photo { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastLogin { get; set; }

        [StringLength(30)]
        public string LasIP { get; set; }

        public UserRole Level { get; set; }

        [Display(Name = "Fullname")]
        [StringLength(30)]
        public string Fullname { get; set; }

        public ICollection<Like> Likes { get; set; }
        public ICollection<SavedPost> SavedPosts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
