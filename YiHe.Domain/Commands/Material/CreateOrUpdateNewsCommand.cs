using System;
using YiHe.CommandProcessor.Command;


namespace YiHe.Domain.Commands.Material
{
    public class CreateOrUpdateNewsCommand : ICommand
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
    }
}