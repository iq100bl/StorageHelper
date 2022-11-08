using DatabaseAccess.Core.Handlers.GenericHandler;
using DatabaseAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Core.DbHandlers.Transaction
{
    public class TransactionDbHandler : GenericDbHandler<TransactionModel>, ITransactionDbHandler
    {
        private readonly DbSet<TransactionModel> _dbSet;
        public TransactionDbHandler(ApplicationContext context) : base(context)
        {
            _dbSet = context.Set<TransactionModel>();
        }
    }
}
