using YiHe.CommandProcessor.Command;


namespace YiHe.Domain.Commands.Library
{
    public class CreateOrUpdateTagCommand : ICommand
    {
        public CreateOrUpdateTagCommand(int tagId, string name, int used)
        {
            TagId = tagId;
            Name = name;
            Used = used;
        }

        public int TagId { get; set; }
        public string Name { get; set; }
        public int Used { get; set; }
    }
}