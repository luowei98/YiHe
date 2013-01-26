namespace YiHe.Web.Core.Models
{
    public class Roles
    {
        public const string USER = "User";
        public const string MANAGER = "Manager";
        public const string ADMIN = "Admin";
    }

    public enum UserRoles
    {
        User = 5,
        Manager = 10,
        Admin = 15,
    }
}