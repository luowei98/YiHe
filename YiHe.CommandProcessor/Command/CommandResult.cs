namespace YiHe.CommandProcessor.Command
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success)
        {
            Success = success;
        }

        #region ICommandResult Members

        public bool Success { get; protected set; }

        #endregion
    }
}