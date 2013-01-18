using YiHe.CommandProcessor.Command;


namespace YiHe.Domain.Commands.Library
{
    public class DeleteTagCommand : ICommand
    {
        public int TagId { get; set; }
    }
}