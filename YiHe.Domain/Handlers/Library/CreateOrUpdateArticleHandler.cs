using YiHe.CommandProcessor.Command;
using YiHe.Data.Infrastructure;
using YiHe.Data.Repositories.Library;
using YiHe.Domain.Commands.Library;
using YiHe.Model.Library;


namespace YiHe.Domain.Handlers.Library
{
    public class CreateOrUpdateArticleHandler : ICommandHandler<CreateOrUpdateArticleCommand>
    {
        private readonly IArticleRepository articleRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateOrUpdateArticleHandler(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            this.articleRepository = articleRepository;
            this.unitOfWork = unitOfWork;
        }

        public ICommandResult Execute(CreateOrUpdateArticleCommand command)
        {
            var article = new Article
                          {
                              ArticleId = command.ArticleId,
                              CategoryId = command.CategoryId,
                              Title = command.Title,
                              Author = command.Author,
                              ExtractFrom = command.ExtractFrom,
                              Picture = command.Picture,
                              Content = command.Content,
                              CreateTime = command.CreateTime,
                              BrowseTimes = command.BrowseTimes,
                          };

            if (article.ArticleId == 0)
            {
                articleRepository.Add(article);
            }
            else
            {
                articleRepository.Update(article);
            }

            unitOfWork.Commit();

            return new CommandResult(true);
        }
    }
}
