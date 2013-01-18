using YiHe.CommandProcessor.Command;
using YiHe.Data.Infrastructure;
using YiHe.Data.Repositories.Security;
using YiHe.Domain.Commands.Security;
using YiHe.Model.Security;


namespace YiHe.Domain.Handlers.Security
{
    public class ChangePasswordHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;

        public ChangePasswordHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICommandHandler<ChangePasswordCommand> Members

        public ICommandResult Execute(ChangePasswordCommand command)
        {
            var user = userRepository.GetById(command.UserId);
            user.Password = command.NewPassword;
            userRepository.Update(user);
            unitOfWork.Commit();
            return new CommandResult(true);
        }

        #endregion
    }
}