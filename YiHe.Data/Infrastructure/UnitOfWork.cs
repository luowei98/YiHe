namespace YiHe.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private YiHeDataContex dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected YiHeDataContex DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        #region IUnitOfWork Members

        public void Commit()
        {
            DataContext.Commit();
        }

        #endregion
    }
}