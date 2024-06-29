using Microsoft.EntityFrameworkCore;
using Forums.Domain.Entities.User;

namespace Forums.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<UDbTable> Users { get; set; }
    }
}
