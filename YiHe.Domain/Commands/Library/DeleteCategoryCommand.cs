using YiHe.CommandProcessor.Command;


namespace YiHe.Domain.Commands.Library
{
    public class DeleteCategoryCommand : ICommand
    {
        public int CategoryId { get; set; }
    }
}