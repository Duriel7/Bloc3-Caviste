using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloc3_Caviste.Data
{
    class DBHandle
    {
                            //All the get all functions are below => needed to show all items into the display grid

        //Get all stored wine stocks
        public ObservableCollection<WineData> GetAllWineStocks()
        {
            using var context = new DBConnect();
            var wineStocks = context.WineDataSets.OrderBy(w => w.Id_Wine).ToList();
            return new ObservableCollection<WineData>(wineStocks);
        }
        //Get all stored clients
        public ObservableCollection<ClientData> GetAllClients()
        {
            using var context = new DBConnect();
            var clients = context.ClientDataSets.OrderBy(c => c.Id_Client).ToList();
            return new ObservableCollection<ClientData>(clients);
        }
        //Get all stroed suppliers
        public ObservableCollection<SupplierData> GetAllSuppliers()
        {
            using var context = new DBConnect();
            var suppliers = context.SupplierDataSets.OrderBy(s => s.Id_Supplier).ToList();
            return new ObservableCollection<SupplierData>(suppliers);
        }
        //Get all stored receipts
        public ObservableCollection<ReceiptData> GetAllReceipts()
        {
            using var context = new DBConnect();
            var receipts = context.ReceiptDataSets.OrderBy(r => r.Id_Receipt).ToList();
            return new ObservableCollection<ReceiptData>(receipts);
        }
        }

                            //All the get functions are below => needed to show all found items in the tables into the search grid
        
        //Get a wine by name and year
        public WineData GetWineByNameAndYear(string name, int year)
        {
            using (var context = new DBConnect())
            {
                var wine = context.WineDataSets.FirstOrDefault(w.Name == name && w.BottlingYear == year);
                return wine;
            }
        }
        //Get a client by fullname and email => still needs thoughts
        public ClientData GetClientByNameAndEmail(string firstname, string surname, string email)
        {
            using (var context = new DBConnect())
            {
                var client = context.ClientDataSets.FirstOrDefault(c.Firstname == firstname && c.Surname == surname && c.Email == email);
                return client;
            }
        }
        //Get a supplier by name
        public SupplierData GetSupplierByName(string name)
        {
            using (var context = new DBConnect())
            {
                var supplier = context.ClientDataSets.FirstOrDefault(s.Name == name);
                return supplier;
            }
        }

                            //All the save all functions are below => needed for when creating data from scratch

        //Save all wine to thelist
        public void SaveAllWineInStock(ObservableCollection<WineData> wineStocks)
        {
            using var context = new DBConnect();
            context.SaveChanges();
        }
        //Save all clients to the list
        public void SaveAllCients(ObservableCollection<ClientData> clients)
        {
            using var context = new DBConnect();
            context.SaveChanges();
        }
        //Save all suppliers to the list
        public void SaveAllSuppliers(ObservableCollection<SupplierData> suppliers)
        {
            using var context = new DBConnect();
            context.SaveChanges();
        }
        //Save all recepits to the list
        public void SaveAllReceipts(ObservableCollection<ReceiptData> receipts)
        {
            using var context = new DBConnect();
            context.SaveChanges();
        }

                            //All the add + save functions are below => needed when adding items one by one

        //Add and save a new wine in the list
        public void AddWineToStock(WineData wine)
        {
            using var context = new DBConnect();
            context.WineDataSets.Add(wine);
            context.SaveChanges();
        }
        //Add and save a new client in the list
        public void AddClientToList(ClientData client)
        {
            using var context = new DBConnect();
            context.ClientDataSets.Add(client);
            context.SaveChanges();
        }
        //Add and save a new supplier in the list
        public void AddSupplierToList(SupplierData supplier)
        {
            using var context = new DBConnect();
            context.SupplierDataSets.Add(supplier);
            context.SaveChanges();
        }
        //Add and save a new receipt in the list => will be called after each successful purchase
        public void AddReceiptToList(ReceiptData receipt)
        {
            using var context = new DBConnect();
            context.ReceiptDataSets.Add(receipt);
            context.SaveChanges();
        }
        //Add and save a new receipt line to the receipt => will be called after passing each item
        public void AddReceiptLineToReceipt(ReceiptLineData receiptLine)
        {
            using var context = new DBConnect();
            context.ReceiptLineDataSets.Add(receiptLine);
            context.SaveChanges();
        }

                            //All the update functions are below => needed to update individual items

        //Update a wine type data
        public void UpdateWineFromList(WineData wine)
        {
            using var context = new DBConnect();
            context.WineDataSets.Update(wine);
            context.SaveChanges();
        }

        //Update a client data
        public void UpdateClientFromList(ClientData client)
        {
            using var context = new DBConnect();
            context.ClientDataSets.Update(client);
            context.SaveChanges();
        }

        //Update a supplier data
        public void UpdateSupplierFromList(SupplierData supplier)
        {
            using var context = new DBConnect();
            context.SupplierDataSets.Update(supplier);
            context.SaveChanges();
        }

                            //All the delete functions are below => needed to delete individual items

        //Delete a wine type
        public void DeleteWineFromList(WineData wine)
        {
            using var context = new DBConnect();
            context.WineDataSets.Remove(wine);
            context.SaveChanges();
        }

        //Delete a client
        public void DeleteClientFromList(ClientData client)
        {
            using var context = new DBConnect();
            context.ClientDataSets.Remove(client);
            context.SaveChanges();
        }

        //Delete a supplier
        public void DeleteSupplierFromList(SupplierData supplier)
        {
            using var context = new DBConnect();
            context.SupplierDataSets.Remove(supplier);
            context.SaveChanges();
        }
    }
}
