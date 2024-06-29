using Microsoft.EntityFrameworkCore;
using Forums.Domain.Entities.User;

namespace Forums.BusinessLogic.DBModel
{
    public class SessionContext : DbContext
    {
        public SessionContext(DbContextOptions<SessionContext> options) : base(options)
        {
        }

        public DbSet<Session> Sessions { get; set; }
    }
}
