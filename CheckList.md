## Checklist CRUD à valider avant la soutenance

### 1. **Client**

* [ ] Ajouter un client (nom, prénom, email, etc.) → vérifier qu’il apparaît dans la grille.
* [ ] Modifier un client (changer l’email, la ville) → vérifier que la grille se met à jour.
* [ ] Supprimer un client → vérifier qu’il disparaît et que ses tickets associés gèrent bien la suppression (soit interdite, soit cascade).
* [ ] Rechercher un client par nom/email (filtre).

### 2. **Vin**

* [ ] Ajouter un vin (nom, millésime, prix, stock) → visible dans la liste.
* [ ] Modifier un vin (prix, stock dispo) → vérifier la mise à jour immédiate.
* [ ] Supprimer un vin → vérifier impact sur les tickets (contrainte clé étrangère).
* [ ] Rechercher un vin par nom + année.

### 3. **Ticket (et lignes de ticket)**

* [ ] Créer un ticket pour un client → avec au moins 1 vin.
* [ ] Ajouter plusieurs vins dans le ticket (ligne de ticket).
* [ ] Vérifier que le total se calcule correctement (quantité × prix).
* [ ] Appliquer une remise si conditions atteintes (bonus).
* [ ] Générer un PDF → vérifier que les infos client + articles + total apparaissent.

### 4. **Validation ORM / Base**

* [ ] Vérifier que toutes les données ajoutées/modifiées/supprimées persistent après redémarrage de l’appli.
* [ ] Vérifier qu’aucun doublon ne se crée si on recharge la BDD.
