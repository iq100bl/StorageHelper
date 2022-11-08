using Core.Dtos;
using DatabaseAccess.Entities;

namespace Core
{
    public interface ITransferService
    {
        public StorageModel[] GetStorages();

        public NomenclatureModel[] GetNomenclatures();

        public StorageModel[] Transactions(FactureDto[] factures);
    }
}