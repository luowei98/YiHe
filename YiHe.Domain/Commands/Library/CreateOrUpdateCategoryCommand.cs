using YiHe.CommandProcessor.Command;


namespace YiHe.Domain.Commands.Library
{
    public class CreateOrUpdateCategoryCommand : ICommand
    {
        public CreateOrUpdateCategoryCommand(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}