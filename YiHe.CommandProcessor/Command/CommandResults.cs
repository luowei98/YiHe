using System.Collections.Generic;
using System.Linq;


namespace YiHe.CommandProcessor.Command
{
    public class CommandResults : ICommandResults
    {
        private readonly List<ICommandResult> results = new List<ICommandResult>();

        #region ICommandResults Members

        public ICommandResult[] Results
        {
            get { return results.ToArray(); }
        }

        public bool Success
        {
            get { return results.All(result => result.Success); }
        }

        #endregion

        public void AddResult(ICommandResult result)
        {
            results.Add(result);
        }
    }
}