using DatabaseAccess.Core.DbHandlers.Nomenclature;
using DatabaseAccess.Core.DbHandlers.Transaction;
using DatabaseAccess.Core.Handlers.ItemOnStorageHandler;
using DatabaseAccess.Core.Handlers.Storage;

namespace DatabaseAccess.Core
{
    public class DbWorker : IDbWorker
    {
        private readonly ApplicationContext _context;
        public IStoragesDbHandlers Storages { get; }
        public IItemOnStorageDbHandler ItemOnStorages { get; }
        public INomenclatureDbHandler Nomenclatures { get; }
        public ITransactionDbHandler Transactions { get; }
        public DbWorker(IStoragesDbHandlers storages, IItemOnStorageDbHandler itemOnStorages, INomenclatureDbHandler nomenclatures, ITransactionDbHandler transactions, ApplicationContext context)
        {
            Storages = storages;
            ItemOnStorages = itemOnStorages;
            Nomenclatures = nomenclatures;
            Transactions = transactions;
            _context = context;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
