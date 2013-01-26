using YiHe.CommandProcessor.Command;
using YiHe.Data.Infrastructure;
using YiHe.Data.Repositories.Library;
using YiHe.Domain.Commands.Library;
using YiHe.Model.Library;


namespace YiHe.Domain.Handlers.Library
{
    public class AddBrowsetimesArticleHandler : ICommandHandler<AddBrowsetimesArticleCommand>
    {
        private readonly IArticleRepository articleRepository;
        private readonly IUnitOfWork unitOfWork;

        public AddBrowsetimesArticleHandler(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            this.articleRepository = articleRepository;
            this.unitOfWork = unitOfWork;
        }

        public ICommandResult Execute(AddBrowsetimesArticleCommand command)
        {
            var article = articleRepository.GetById(command.ArticleId);
            article.BrowseTimes++;
            articleRepository.Update(article);
            unitOfWork.Commit();
            return new CommandResult(true);
        }
    }
}
