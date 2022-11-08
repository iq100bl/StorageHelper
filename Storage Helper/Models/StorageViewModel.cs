using DatabaseAccess.Entities;

namespace Storage_Helper.Models
{
    public class StorageViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ItemViewModel[] Items { get; set; }
    }
}
