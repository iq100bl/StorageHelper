using DatabaseAccess.Core.Handlers.GenericHandler;
using DatabaseAccess.Entities;

namespace DatabaseAccess.Core.DbHandlers.Transaction
{
    public interface ITransactionDbHandler : IGenericDbHandler<TransactionModel>
    {
    }
}