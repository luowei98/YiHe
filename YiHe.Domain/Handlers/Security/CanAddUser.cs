using System.Collections.Generic;
using YiHe.CommandProcessor.Command;
using YiHe.Core.Common;
using YiHe.Data.Repositories.Security;
using YiHe.Domain.Commands.Security;
using YiHe.Domain.Properties;
using YiHe.Model.Security;


namespace YiHe.Domain.Handlers.Security
{
    public class CanAddUser : IValidationHandler<UserRegisterCommand>
    {
        private readonly IUserRepository userRepository;

        public CanAddUser(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        #region IValidationHandler<UserRegisterCommand> Members

        public IEnumerable<ValidationResult> Validate(UserRegisterCommand command)
        {
            User isUserExists = userRepository.Get(c => c.Email == command.Email);

            if (isUserExists != null)
            {
                yield return new ValidationResult("EMail", Resources.UserExists);
            }
        }

        #endregion
    }
}