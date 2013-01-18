using System;
using YiHe.CommandProcessor.Command;


namespace YiHe.Domain.Commands.Library
{
    public class CreateOrUpdateArticleCommand : ICommand
    {
        public CreateOrUpdateArticleCommand(
            int articleId,
            int categoryId,
            string title,
            string author,
            string extractFrom,
            string picture,
            string content,
            DateTime createTime,
            int browseTimes)
        {
            ArticleId = articleId;
            CategoryId = categoryId;
            Title = title;
            Author = author;
            ExtractFrom = extractFrom;
            Picture = picture;
            Content = content;
            CreateTime = createTime;
            BrowseTimes = browseTimes;
        }

        public int ArticleId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ExtractFrom { get; set; }
        public string Picture { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public int BrowseTimes { get; set; }
    }
}