using System.IO;
using System.Linq;
using YiHe.Model.Library;


namespace YiHe.Web.Helpers
{
    public static class PathHelper
    {
        public static string ArticlePicture(Article article)
        {
            string path = article
                .Category
                .Chain
                .Aggregate("", (curr, category) => curr + "/" + category.Name);

            return string.Format(
                "article{0}/{1}",
                path,
                article.Picture);
        }

        public static string ArticleSmallPicture(Article article)
        {
            string path = article
                .Category
                .Chain
                .Aggregate("", (curr, category) =>
                               curr + Path.DirectorySeparatorChar.ToString() + category.Name);

            return string.Format(
                "article/{0}/{1}s{2}",
                path,
                Path.GetFileNameWithoutExtension(article.Picture),
                Path.GetExtension(article.Picture));
        }
    }
}