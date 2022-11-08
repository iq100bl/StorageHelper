using DatabaseAccess.Core.Handlers.GenericHandler;
using DatabaseAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Core.DbHandlers.Nomenclature
{
    public class NomenclatureDbHandler : GenericDbHandler<NomenclatureModel>, INomenclatureDbHandler
    {
        private readonly DbSet<NomenclatureModel> _dbSet;

        public NomenclatureDbHandler(ApplicationContext context) : base(context)
        {
            _dbSet = context.Set<NomenclatureModel>();
        }
    }
}
