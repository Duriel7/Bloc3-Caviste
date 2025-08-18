    modelBuilder.Entity<Fournisseur>().HasData(
        new Fournisseur { Id = 1, Nom = "Château Truc", Email = "exemple@mail.fr", Telephone = "0102030405", Ville = "Machin" }
    );

    modelBuilder.Entity<Vin>().HasData(
        new Vin { Id = 1, Nom = "Grand Cru", Millesime = 2018, StocksDispo = 50, PrixPublic = 120, Cout = 80, Id_Fournisseur = 1 }
    );

if (!context.WineDataSets.Any())
{
    context.WineDataSets.Add(new WineData { Name = "Château Margaux", BottlingYear = 2018, StocksAvailable = 50 });
    context.SaveChanges();
}

Notes :

On peut faire un DateTime(date).Now pour mettre une commande à la date du jour
On peut faire un DateTime(date).Now.AddDays(X) pour ajouter des jours avant l'arrivée de la commande dans la colonne
=> permet de faire les calcul en attrapant la bonne valeur avec la fonction d'update des données