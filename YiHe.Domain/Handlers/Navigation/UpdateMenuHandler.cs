using YiHe.CommandProcessor.Command;
using YiHe.Data.Infrastructure;
using YiHe.Data.Repositories.Navigation;
using YiHe.Domain.Commands.Navigation;
using YiHe.Model.Navigation;


namespace YiHe.Domain.Handlers.Navigation
{
    public class UpdateMenuHandler : ICommandHandler<UpdateMenuCommand>
    {
        private readonly IMenuRepository menuRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateMenuHandler(IMenuRepository menuRepository, IUnitOfWork unitOfWork)
        {
            this.menuRepository = menuRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICommandHandler<UpdateMenuCommand> Members

        public ICommandResult Execute(UpdateMenuCommand command)
        {
            Menu menu = menuRepository.GetById(command.MenuId);
            menu.MenuText = command.MenuText;
            menu.Position = command.Position;
            if (command.ParentId.HasValue)
            {
                Menu parent = menuRepository.GetById(command.ParentId.Value);
                if (parent == null) return new CommandResult(false);
                menu.Parent = parent;
            }

            menuRepository.Update(menu);
            unitOfWork.Commit();

            return new CommandResult(true);
        }

        #endregion
    }
}