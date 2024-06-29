using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Forums.Domain.Entities.Posts
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int AuthorId { get; set; }
    }
}
