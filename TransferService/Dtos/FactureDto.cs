using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class FactureDto
    {
        public Guid NomenclatureId { get; set; }

        public int Count { get; set; }

        public Guid ItemFromStrorage { get; set; }

        public Guid ItemToStorage { get; set; }
    }
}
