using DatabaseAccess.Core.Handlers.Storage;
using DatabaseAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DatabaseAccess
{
    public class ApplicationContext : DbContext
    {
        private readonly NomenclatureModel[] nomeclatures = new NomenclatureModel[7];

        private readonly StorageModel[] storageModels = new StorageModel[3];
        private readonly Random random = new Random();

        public DbSet<StorageModel> Storages { get; set; }
        public DbSet<ItemOnStorageModel> Items { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<NomenclatureModel> Nomenclaturies { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            storageModels = new StorageModel[]
            {
                new StorageModel{
                    Id = Guid.NewGuid(),
                    Name = "Тут"
                },
                new StorageModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Там"
                },
                new StorageModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Где-то"
                }
            };

            nomeclatures = new NomenclatureModel[] {
            new NomenclatureModel { Id = Guid.NewGuid(), Description = "Еда" },
            new NomenclatureModel { Id = Guid.NewGuid(), Description = "Обувь" },
            new NomenclatureModel { Id = Guid.NewGuid(), Description = "Химия" },
            new NomenclatureModel { Id = Guid.NewGuid(), Description = "Одежда" },
            new NomenclatureModel { Id = Guid.NewGuid(), Description = "Техника" },
            new NomenclatureModel { Id = Guid.NewGuid(), Description = "Посуда" },
            new NomenclatureModel { Id = Guid.NewGuid(), Description = "Воздух" }
            };
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StorageModel>()
                .HasMany(x => x.ItemOnStorages)
                .WithOne(x => x.Storage)
                .HasForeignKey(x => x.StorageId);

            modelBuilder.Entity<NomenclatureModel>()
                .HasMany(x => x.Transactions)
                .WithOne(x => x.Nomenclature)
                .HasForeignKey(x => x.NomenclatureId);

            modelBuilder.Entity<ItemOnStorageModel>()
                .HasOne(x => x.Nomenclature)
                .WithMany(x => x.ItemOnStorages)
                .HasForeignKey(x => x.NomenclatureId);

            modelBuilder.Entity<NomenclatureModel>().HasData(nomeclatures);
            

            for (int i = 0; i < 10; i++)
            {
                modelBuilder.Entity<ItemOnStorageModel>().HasData(
                    new ItemOnStorageModel { 
                        Id = Guid.NewGuid(),
                        Count = 100 * (i + 1), 
                        NomenclatureId = nomeclatures[random.Next(0, 6)].Id, 
                        StorageId = storageModels[random.Next(0,2)].Id
                    });
            }

            modelBuilder.Entity<StorageModel>().HasData(storageModels);
        }
    }
}