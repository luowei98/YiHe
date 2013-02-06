using YiHe.CommandProcessor.Command;
using YiHe.Data.Infrastructure;
using YiHe.Data.Repositories.Material;
using YiHe.Domain.Commands.Material;
using YiHe.Model.Material;


namespace YiHe.Domain.Handlers.Material
{
    public class CreateOrUpdateNewsHandler : ICommandHandler<CreateOrUpdateNewsCommand>
    {
        private readonly INewsRepository newsRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateOrUpdateNewsHandler(INewsRepository newsRepository, IUnitOfWork unitOfWork)
        {
            this.newsRepository = newsRepository;
            this.unitOfWork = unitOfWork;
        }

        public ICommandResult Execute(CreateOrUpdateNewsCommand command)
        {
            var news = new News
            {
                NewsId = command.NewsId,
                Title = command.Title,
                Picture = command.Picture,
                Content = command.Content,
                CreateTime = command.CreateTime,
            };

            if (news.NewsId == 0)
            {
                newsRepository.Add(news);
            }
            else
            {
                newsRepository.Update(news);
            }

            unitOfWork.Commit();

            return new CommandResult(true);
        }
    }
}