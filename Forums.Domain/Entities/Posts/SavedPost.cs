using Forums.Domain.Entities.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Forums.Domain.Entities.Posts
{
    public class SavedPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public UDbTable User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }

}
