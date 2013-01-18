using System.Collections.Generic;
using YiHe.CommandProcessor.Command;
using YiHe.Core.Common;


namespace YiHe.CommandProcessor.Dispatcher
{
    public interface ICommandBus
    {
        ICommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand;
        IEnumerable<ValidationResult> Validate<TCommand>(TCommand command) where TCommand : ICommand;
    }
}