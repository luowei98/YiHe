﻿namespace YiHe.CommandProcessor.Command
{
    public interface ICommandResults
    {
        ICommandResult[] Results { get; }

        bool Success { get; }
    }
}