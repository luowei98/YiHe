using YiHe.CommandProcessor.Command;


namespace YiHe.Domain.Commands.Material
{
    public class DeleteNewsCommand : ICommand
    {
        public int NewsId { get; set; }
    }
}