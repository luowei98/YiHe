using System.Collections.Generic;
using YiHe.CommandProcessor.Command;
using YiHe.Core.Common;
using YiHe.Data.Repositories.Material;
using YiHe.Domain.Commands.Material;
using YiHe.Domain.Properties;
using YiHe.Model.Material;


namespace YiHe.Domain.Handlers.Material
{
    public class CanAddNews : IValidationHandler<CreateOrUpdateNewsCommand>
    {
        private readonly INewsRepository newsRepository;

        public CanAddNews(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        #region IValidationHandler<CreateOrUpdateNewsCommand> Members

        public IEnumerable<ValidationResult> Validate(CreateOrUpdateNewsCommand command)
        {
            News isNewsExists = command.NewsId == 0 ? 
                newsRepository.Get(c => c.Title == command.Title) : 
                newsRepository.Get(c => c.Title == command.Title && c.NewsId != command.NewsId);

            if (isNewsExists != null)
            {
                yield return new ValidationResult("Name", Resources.NewsExists);
            }
        }

        #endregion
    }
}