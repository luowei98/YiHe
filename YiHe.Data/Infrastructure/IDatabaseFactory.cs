using System;


namespace YiHe.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        YiHeDataContex Get();
    }
}