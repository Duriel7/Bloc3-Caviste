using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloc3_Caviste.Data
{
    class SeedFunctions
    {
        //The Open Wine API will seed wine into DB
        public void seedWine(DBConnect context)
        {
            //TBA
        }

        //Seed fake clients into DB
        public void seedClients(DBConnect context)
        {
            context.ClientDataSets.AddRange(
                new ClientData { Firstname = "Jean", Surname = "Dupont", Email = "jean@dupont.com", Telephone = "0102030405", Address = "130 Rue du Pinard", PostalCode = "31122", City = "Saint-Péta-Ouch-Nok sur Rivière" },
                new ClientData { Firstname = "Micheline", Surname = "Durand", Email = "micheline@durand.fr", Telephone = "0605040302", Address = "120 rue du Fromage", PostalCode = "47155", City = "Bourg-Pas-en-Bresse" },
                new ClientData { Firstname = "", Surname = "", Email = "", Telephone = "0102030405", Address = "", PostalCode = "", City = "" },
                new ClientData { Firstname = "", Surname = "", Email = "", Telephone = "0102030405", Address = "", PostalCode = "", City = "" },
                new ClientData { Firstname = "", Surname = "", Email = "", Telephone = "0102030405", Address = "", PostalCode = "", City = "" }
            );
            context.SaveChanges();
        }

        //Seed fake suppliers into DB
        public void seedSuppliers(DBConnect context)
        {
            context.SupplierDataSets.AddRange(
                new SupplierData { Name = "Château Duplomb", Email = "chateau@duplomb.fr", Telephone = "0546586545", City = "Bordeaux" },
                new SupplierData { Name = "Château Duvent", Email = "chateau@duvent.fr", Telephone = "0467446856", City = "Montpellier" },
                new SupplierData { Name = "Château Gaz-Gogne", Email = "gaz.cogne@vin.org", Telephone = "0515765359", City = "Auch" }
            );
            context.SaveChanges();
        }
    }
}
