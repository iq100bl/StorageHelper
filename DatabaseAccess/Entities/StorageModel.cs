namespace DatabaseAccess.Entities
{
    public class StorageModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<ItemOnStorageModel> ItemOnStorages { get; set; }
    }
}
