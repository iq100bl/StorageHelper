using DatabaseAccess.Core.DbHandlers.Nomenclature;
using DatabaseAccess.Core.DbHandlers.Transaction;
using DatabaseAccess.Core.Handlers.ItemOnStorageHandler;
using DatabaseAccess.Core.Handlers.Storage;

namespace DatabaseAccess.Core
{
    public interface IDbWorker
    {
        IStoragesDbHandlers Storages { get; }
        IItemOnStorageDbHandler ItemOnStorages { get; }
        INomenclatureDbHandler Nomenclatures { get; }
        ITransactionDbHandler Transactions { get; }

        public Task Save();
    }
}