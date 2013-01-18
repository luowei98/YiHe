using YiHe.CommandProcessor.Command;


namespace YiHe.Domain.Commands.Library
{
    public class DeleteArticleCommand : ICommand
    {
        public int ArticleId { get; set; }
    }
}