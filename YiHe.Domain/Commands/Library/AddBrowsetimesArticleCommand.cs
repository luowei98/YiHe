using System;
using YiHe.CommandProcessor.Command;


namespace YiHe.Domain.Commands.Library
{
    public class AddBrowsetimesArticleCommand : ICommand
    {
        public int ArticleId { get; set; }
    }
}