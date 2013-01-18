using YiHe.CommandProcessor.Command;


namespace YiHe.Domain.Commands.Navigation
{
    public class UpdateMenuCommand : ICommand
    {
        public UpdateMenuCommand(int menuId, string menuText, int position, int? parent)
        {
            MenuId = menuId;
            MenuText = menuText;
            Position = position;
            ParentId = parent;
        }

        public int MenuId { get; set; }
        public string MenuText { get; set; }
        public int Position { get; set; }
        public int? ParentId { get; set; }
    }
}