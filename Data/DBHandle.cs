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
        public DbSet<ReceiptData> ReceiptDataSets { get; set; }
        public DbSet<ReceiptLineData> ReceiptLineDataSets { get; set; }

        //Configure data model when database is initialized
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Model for wine data
            modelBuilder.Entity<WineData>().HasKey(w => w.Id_Wine);
            modelBuilder.Entity<WineData>().Property(w => w.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<WineData>().Property(w => w.BottlingYear).IsRequired();
            modelBuilder.Entity<WineData>().Property(w => w.StocksAvailable).IsRequired();
            modelBuilder.Entity<WineData>().Property(w => w.StocksArriving);
            modelBuilder.Entity<WineData>().Property(w => w.DateOrder);
            modelBuilder.Entity<WineData>().Property(w => w.DateRestock);
            modelBuilder.Entity<WineData>().HasOne(w => w.SupplierData).WithMany(s => s.WineData).HasForeignKey(w => w.Id_Supplier).IsRequired();
            modelBuilder.Entity<WineData>().Property(w => w.PricePublic).IsRequired();
            modelBuilder.Entity<WineData>().Property(w => w.PriceSupplier).IsRequired();

            //Model for client data
            modelBuilder.Entity<ClientData>().HasKey(c => c.Id_Client);
            modelBuilder.Entity<ClientData>().Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<ClientData>().Property(c => c.SurName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<ClientData>().Property(c => c.Email).HasConversion<string>().HasMaxLength(50).IsRequired();
            modelBuilder.Entity<ClientData>().Property(c => c.Telephone).HasConversion<string>().HasMaxLength(10).IsRequired();
            modelBuilder.Entity<ClientData>().Property(c => c.Address).IsRequired();
            modelBuilder.Entity<ClientData>().Property(c => c.PostalCode).IsRequired();
            modelBuilder.Entity<ClientData>().Property(c => c.City).IsRequired();

            //Model for supplier data
            modelBuilder.Entity<SupplierData>().HasKey(s => s.Id_Supplier);
            modelBuilder.Entity<SupplierData>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<SupplierData>().Property(s => s.Email).HasConversion<string>().HasMaxLength(50).IsRequired();
            modelBuilder.Entity<SupplierData>().Property(s => s.Telephone).HasConversion<string>().HasMaxLength(10).IsRequired();
            modelBuilder.Entity<SupplierData>().Property(s => s.City).IsRequired();

            //Model for receipt data
            modelBuilder.Entity<ReceiptData>().HasKey(r => r.Id_Receipt);
            modelBuilder.Entity<ReceiptData>().HasOne(r => r.ClientData).WithMany(c => c.ReceiptData).HasForeignKey(r => r.Id_Client).IsRequired();
            modelBuilder.Entity<ReceiptData>().Property(r => r.DateSold).IsRequired();
            modelBuilder.Entity<ReceiptData>().Property(r => r.PriceTotal).IsRequired();
            modelBuilder.Entity<ReceiptData>().Property(r => r.Discount);        //booléen pour décider si oui ou non pas la fonction externe
            modelBuilder.Entity<ReceiptData>().Property(r => r.PriceDiscounted); //faire le calcul à part et inclure le résultat ici

            //Model for receipt line data
            modelBuilder.Entity<ReceiptLineData>().HasKey(l => l.Id_ReceiptLine);
            modelBuilder.Entity<ReceiptLineData>().HasOne(l => l.ReceiptData).WithMany(r => r.ReceiptLineData).HasForeignKey(l => l.Id_Receipt).IsRequired();
            modelBuilder.Entity<ReceiptLineData>().HasOne(l => l.WineData).WithMany(w => w.ReceiptLineData).HasForeignKey(l => l.Id_Wine).IsRequired();
            modelBuilder.Entity<ReceiptLineData>().Property(l => l.Quantity).IsRequired();
            modelBuilder.Entity<ReceiptLineData>().Property(l => l.PricePerUnit).IsRequired();

            //Builds database model
            base.OnModelCreating(modelBuilder);
        }

                            //All the get all functions are below

        //Get all stored wine stocks
        public ObservableCollection<WineData> GetAllWineStocks()
        {
            using var context = new DBHandle();
            var wineStocks = context.WineDataSets.OrderBy(w => w.Id_Wine).ToList();
            return new ObservableCollection<WineData>(wineStocks);
        }
        //Get all stored clients
        public ObservableCollection<WineData> GetAllClients()
        {
            using var context = new DBHandle();
            var clients = context.ClientDataSets.OrderBy(c => c.Id_Client).ToList();
            return new ObservableCollection<WineData>(clients);
        }
        //Get all stroed suppliers
        public ObservableCollection<SupplierData> GetAllSuppliers()
        {
            using var context = new DBHandle();
            var suppliers = context.SupplierDataSets.OrderBy(s => s.Id_Supplier).ToList();
            return new ObservableCollection<SupplierData>(suppliers);
        }
        //Get all stored receipts
        public ObservableCollection<ReceiptData> GetAllReceipts()
        {
            using var context = new DBHandle();
            var receipts = context.ReceiptDataSets.OrderBy(r => r.Id_Receipt).ToList();
            return new ObservableCollection<ReceiptData>(receipts);
        }

                            //All the save all functions are below

        //Save all wine to database to update the stored list
        public void SaveAllWineInStock(ObservableCollection<WineData> wineStocks)
        {
            using var context = new DBHandle();

        }

                            //All the add + save functions are below

        //Add and save a new wine in the list
        public void AddWineToStock(ObservableCollection<WineData> wine)
        {
            wine.Add(new [WineStocks] { });
        }
    }
}
