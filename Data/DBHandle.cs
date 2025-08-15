using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloc3_Caviste.Data
{
    class DBHandle : DBConnect
    {
        //Attributes
        private readonly DBConnect dbConnect;

        //Db set to handle wine stocks and clients data
        public DbSet<WineData> WineDataSets { get; set; }
        public DbSet<ClientData> ClientDataSets { get; set; }
        public DbSet<SupplierData> SupplierDataSets { get; set; }

        //Configure data model when database is initialized
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mode for wine data
            modelBuilder.Entity<WineData>().HasKey(w => w.Id);
            modelBuilder.Entity<WineData>().Property(w => w.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<WineData>().Property(w => w.BottlingYear).IsRequired();
            modelBuilder.Entity<WineData>().Property(w => w.StocksAvailable).IsRequired();
            modelBuilder.Entity<WineData>().Property(w => w.StocksArriving);
            modelBuilder.Entity<WineData>().Property(w => w.DateOrder);
            modelBuilder.Entity<WineData>().Property(w => w.DateRestock);
            modelBuilder.Entity<WineData>().Property(w => w.Supplier).IsRequired();
            modelBuilder.Entity<WineData>().Property(w => w.PricePublic).IsRequired();
            modelBuilder.Entity<WineData>().Property(w => w.PriceSupplier).IsRequired();

            //Mode for client data
            modelBuilder.Entity<ClientData>().HasKey(c => c.Id);
            modelBuilder.Entity<ClientData>().Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<ClientData>().Property(c => c.SurName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<ClientData>().Property(c => c.Email).HasConversion<string>().HasMaxLength(25).IsRequired();
            modelBuilder.Entity<ClientData>().Property(c => c.Telephone).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<ClientData>().Property(c => c.Address).IsRequired();
            modelBuilder.Entity<ClientData>().Property(c => c.PostalCode).IsRequired();
            modelBuilder.Entity<ClientData>().Property(c => c.City).IsRequired();

            //Mode for supplier data
            modelBuilder.Entity<SupplierData>().HasKey(s => s.Id);

            //Builds database model
            base.OnModelCreating(modelBuilder);
        }

        //Get all stored wine
        public ObservableCollection<WineData> GetWineStocks()
        {
            using var context = new DBHandle();
            var stocks = context.WineDataSets.OrderBy(t => t.Id).ToList();
            return new ObservableCollection<WineData>(stocks);
        }

        //Save all wine to database to update the stored list
        public void SaveAllWine(ObservableCollection<WineData> stocks)
        {
            using var context = new DBHandle();

        }

        //Add a new task in the list
        public void AddWine(ObservableCollection<WineData> stocks)
        {
            stocks.Add(new [WineStocks] { });
        }
    }
}
