using Forums.Domain.Enum;

namespace Forums.Domain.Entities.User
{
    public class UserMinimal
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime LastLogin { get; set; }
        public string LasIp { get; set; }
        public UserRole Level { get; set; }
        public string Photo { get; set; }
        public string InfoBlog { get; set; }
        public string Profession { get; set; }
        public string PhoneNumber { get; set; }
        public string Fullname { get; set; }
    }
}
