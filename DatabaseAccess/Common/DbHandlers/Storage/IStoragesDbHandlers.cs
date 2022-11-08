using DatabaseAccess.Core.Handlers.GenericHandler;
using DatabaseAccess.Entities;

namespace DatabaseAccess.Core.Handlers.Storage
{
    public interface IStoragesDbHandlers : IGenericDbHandler<StorageModel> 
    {
        public new StorageModel[] GetAll();
    }
}