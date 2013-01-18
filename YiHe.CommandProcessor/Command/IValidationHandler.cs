using System.Collections.Generic;
using YiHe.Core.Common;


namespace YiHe.CommandProcessor.Command
{
    public interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        IEnumerable<ValidationResult> Validate(TCommand command);
    }
}