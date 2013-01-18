using System.Collections.Generic;
using YiHe.CommandProcessor.Command;
using YiHe.Core.Common;
using YiHe.Data.Repositories.Security;
using YiHe.Domain.Commands.Security;
using YiHe.Domain.Properties;
using YiHe.Model.Security;


namespace YiHe.Domain.Handlers.Security
{
    public class CanChangePassword : IValidationHandler<ChangePasswordCommand>
    {
        private readonly IUserRepository userRepository;

        public CanChangePassword(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        #region IValidationHandler<ChangePasswordCommand> Members

        public IEnumerable<ValidationResult> Validate(ChangePasswordCommand command)
        {
            User user = userRepository.GetById(command.UserId);
            string encoded = Md5Encrypt.Md5EncryptPassword(command.OldPassword);

            if (!user.PasswordHash.Equals(encoded))
            {
                yield return new ValidationResult("OldPassword", Resources.Password);
            }
        }

        #endregion
    }
}