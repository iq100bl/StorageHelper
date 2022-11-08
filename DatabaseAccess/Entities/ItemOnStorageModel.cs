namespace DatabaseAccess.Entities
{
    public class ItemOnStorageModel
    {
        public Guid Id { get; set; }
        public int Count { get; set; }

        public Guid NomenclatureId { get; set; }
        public NomenclatureModel Nomenclature { get; set; }

        public Guid StorageId { get; set; }
        public StorageModel Storage { get; set; }
    }
}
