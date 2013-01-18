using System.Collections.Generic;
using System.Web.Mvc;
using YiHe.CommandProcessor.Command;
using YiHe.Core.Common;


namespace YiHe.CommandProcessor.Dispatcher
{
    public class DefaultCommandBus : ICommandBus
    {
        #region ICommandBus Members

        public ICommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = DependencyResolver.Current.GetService<ICommandHandler<TCommand>>();
            if (handler == null)
            {
                throw new CommandHandlerNotFoundException(typeof (TCommand));
            }
            return handler.Execute(command);
        }

        public IEnumerable<ValidationResult> Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = DependencyResolver.Current.GetService<IValidationHandler<TCommand>>();
            if (handler == null)
            {
                throw new ValidationHandlerNotFoundException(typeof (TCommand));
            }
            return handler.Validate(command);
        }

        #endregion
    }
}