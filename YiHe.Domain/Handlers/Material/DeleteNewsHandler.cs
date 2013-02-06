using YiHe.CommandProcessor.Command;
using YiHe.Data.Infrastructure;
using YiHe.Data.Repositories.Material;
using YiHe.Domain.Commands.Material;
using YiHe.Model.Material;


namespace YiHe.Domain.Handlers.Material
{
    public class DeleteNewsHandler : ICommandHandler<DeleteNewsCommand>
    {
        private readonly INewsRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteNewsHandler(INewsRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICommandHandler<DeleteNewsCommand> Members

        public ICommandResult Execute(DeleteNewsCommand command)
        {
            News news = categoryRepository.GetById(command.NewsId);

            categoryRepository.Delete(news);
            unitOfWork.Commit();

            return new CommandResult(true);
        }

        #endregion
    }
}