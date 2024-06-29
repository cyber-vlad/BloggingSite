using Microsoft.EntityFrameworkCore;
using Forums.Domain.Entities.Posts;
using Forums.BusinessLogic.Interfaces;
using Forums.Domain.Entities.User;

namespace Forums.BusinessLogic.DBModel
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> options) : base(options)
        {
        }
        //public DbSet<UDbTable> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
       // public DbSet<Like> Likes { get; set; }
        //public DbSet<SavedPost> SavedPosts { get; set; }
       // public DbSet<Comment> Comments { get; set; }

    }
}
