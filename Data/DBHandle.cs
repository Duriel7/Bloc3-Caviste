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
        public DbSet<stocks> WineStocks { get; set; }
        public DbSet<client> Clients { get; set; }

        //Configure data model when database is initialized
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WineStocks>().HasKey(t => t.Id);
            modelBuilder.Entity<WineStocks>().Property(t => t.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<WineStocks>().Property(t => t.BottlingYear).IsRequired();
            base.OnModelCreating(modelBuilder);
        }

        //Get all stored wine
        public ObservableCollection<WineStocks> GetWineStocks()
        {
            using var context = new DBHandle();
            var stocks = context.WineStocks.OrderBy(t => t.Id).ToList();
            return new ObservableCollection<WineStocks>(stocks);
        }

        //Save all wine to database to update the stored list
        public void SaveAllWine(ObservableCollection<WineStocks> stocks)
        {
            using var context = new DBHandle();

        }

        //Add a new task in the list
        public void AddWine(ObservableCollection<WineStocks> stocks)
        {
            stocks.Add(new [WineStocks] { });
        }
    }
}
