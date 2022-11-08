using DatabaseAccess.Core.Handlers.GenericHandler;
using DatabaseAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Core.Handlers.ItemOnStorageHandler
{
    public class ItemOnStorageDbHandler : GenericDbHandler<ItemOnStorageModel>, IItemOnStorageDbHandler
    {
        private readonly DbSet<ItemOnStorageModel> _dbSet;
        public ItemOnStorageDbHandler(ApplicationContext context) : base(context)
        {
            _dbSet = context.Set<ItemOnStorageModel>();
        }

        public ItemOnStorageModel GetItemFromStorage(Guid ItemId)
        {
            return _dbSet.First(x => x.Id == ItemId);
        }
    }
}
