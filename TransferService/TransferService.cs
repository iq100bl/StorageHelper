using Core.Dtos;
using DatabaseAccess.Core;
using DatabaseAccess.Entities;

namespace Core
{
    public class TransferService : ITransferService
    {
        private readonly IDbWorker _dbWorker;

        public TransferService(IDbWorker dbWorker)
        {
            _dbWorker = dbWorker;
        }

        public StorageModel[] GetStorages()
        {
            try
            {
                return _dbWorker.Storages.GetAll();
            }
            catch
            {
                throw new InvalidOperationException("GetStoreges problems");
            }
        }

        public NomenclatureModel[] GetNomenclatures()
        {
            try
            {
                return _dbWorker.Nomenclatures.GetAll();
            }
            catch
            {
                throw new InvalidOperationException("GetNomenclatures problems");
            }
        }

        public StorageModel[] Transactions(FactureDto[] factures)
        {
            foreach (FactureDto facture in factures)
            {
                if (facture.ItemFromStrorage == Guid.Empty)
                {
                    Admission(facture);
                }
                else if (facture.ItemToStorage == Guid.Empty)
                {
                    Consumption(facture);
                }
                else
                {
                    Admission(facture);
                    Consumption(facture);
                }

                _dbWorker.Transactions.Create(new TransactionModel
                {
                    Count = facture.Count,
                    Id = Guid.NewGuid(),
                    NomenclatureId = facture.NomenclatureId,
                    Transactiontime = DateTime.Now,
                    StorageFromId = facture.ItemFromStrorage == Guid.Empty ? Guid.Empty : facture.ItemFromStrorage,
                    StorageToId = facture.ItemToStorage == Guid.Empty ? Guid.Empty : facture.ItemToStorage
                });
            }
            

            _dbWorker.Save();

            return GetStorages();
        }

        private void Consumption(FactureDto facture)
        {
            var consumption = _dbWorker.ItemOnStorages.GetItemFromStorage(facture.ItemFromStrorage);
            consumption.Count -= facture.Count;
            _dbWorker.ItemOnStorages.Update(consumption);
        }

        private void Admission(FactureDto facture)
        {
            var admission = _dbWorker.ItemOnStorages.GetItemFromStorage(facture.ItemToStorage);
            admission.Count += facture.Count;
            _dbWorker.ItemOnStorages.Update(admission);
        }
    }
}