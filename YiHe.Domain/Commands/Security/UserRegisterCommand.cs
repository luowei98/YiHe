using YiHe.CommandProcessor.Command;


namespace YiHe.Domain.Commands.Security
{
    public class UserRegisterCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool Activated { get; set; }
    }
}