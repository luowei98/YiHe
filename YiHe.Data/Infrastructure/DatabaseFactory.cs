namespace YiHe.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private YiHeDataContex dataContext;

        #region IDatabaseFactory Members

        public YiHeDataContex Get()
        {
            return dataContext ?? (dataContext = new YiHeDataContex());
        }

        #endregion

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}