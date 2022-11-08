using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class NomenclatureModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public ICollection<ItemOnStorageModel> ItemOnStorages { get; set; }

        public ICollection<TransactionModel> Transactions { get; set; }
    }
}
