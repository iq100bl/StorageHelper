namespace DatabaseAccess.Core.Handlers.GenericHandler
{
    public interface IGenericDbHandler<TEntity> where TEntity : class
    {
        public Task Create(TEntity entity);

        public Task Update(TEntity entity);

        public Task Delite(TEntity entity);

        public TEntity[] GetAll();
    }
}