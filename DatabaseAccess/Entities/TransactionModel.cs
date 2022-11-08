namespace DatabaseAccess.Entities
{
    public class TransactionModel
    {
        public Guid Id { get; set; }
        public int Count { get; set; }
        public DateTime Transactiontime { get; set; }

        public Guid NomenclatureId { get; set; }
        public NomenclatureModel Nomenclature { get; set; }

        public Guid? StorageFromId { get; set; }

        public Guid? StorageToId { get; set; }    
    }
}
