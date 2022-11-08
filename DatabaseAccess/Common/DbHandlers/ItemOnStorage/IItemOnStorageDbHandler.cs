using DatabaseAccess.Core.Handlers.GenericHandler;
using DatabaseAccess.Entities;

namespace DatabaseAccess.Core.Handlers.ItemOnStorageHandler
{
    public interface IItemOnStorageDbHandler : IGenericDbHandler<ItemOnStorageModel>
    {
        public ItemOnStorageModel GetItemFromStorage(Guid ItemId);
    }
}