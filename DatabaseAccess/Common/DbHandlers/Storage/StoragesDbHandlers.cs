using DatabaseAccess.Core.Handlers.GenericHandler;
using DatabaseAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Core.Handlers.Storage
{
    public class StoragesDbHandlers : GenericDbHandler<StorageModel>, IStoragesDbHandlers
    {
        private readonly DbSet<StorageModel> _dbSet;
        public StoragesDbHandlers(ApplicationContext context) : base(context)
        {
            _dbSet = context.Set<StorageModel>();
        }

        public override StorageModel[] GetAll()
        {
            return _dbSet.AsNoTracking().Include("ItemOnStorages.Nomenclature").ToArray();
        }
    }
}
