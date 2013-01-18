using System.Collections.Generic;
using YiHe.CommandProcessor.Command;
using YiHe.Core.Common;
using YiHe.Data.Repositories.Library;
using YiHe.Domain.Commands.Library;
using YiHe.Domain.Properties;
using YiHe.Model.Library;


namespace YiHe.Domain.Handlers.Library
{
    public class CanAddArticle : IValidationHandler<CreateOrUpdateArticleCommand>
    {
        private readonly IArticleRepository articleRepository;

        public CanAddArticle(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        #region IValidationHandler<CreateOrUpdateArticleCommand> Members

        public IEnumerable<ValidationResult> Validate(CreateOrUpdateArticleCommand command)
        {
            Article isArticleExists = 
                command.ArticleId == 0 ? 
                articleRepository.Get(c => c.Title == command.Title) : 
                articleRepository.Get(c => c.Title == command.Title && c.CategoryId != command.CategoryId);

            if (isArticleExists != null)
            {
                // todo
                yield return new ValidationResult("Name", Resources.CategoryExists);
            }
        }

        #endregion
    }
}