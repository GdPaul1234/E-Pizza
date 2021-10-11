# Projet Pizzeria

## Intégration de systèmes _ applications
Utilise C#, WPF, Entity Framework Core, SQLite

Paul GODIN, Kevin GOV, Bienvenu KADIEBWE

## Installation du projet

Avant le lancer le projet, installer les dépendances du projet.

Créer les dossiers nécessaires au bon fonctionnement de l'application
```cmd
mkdir %localappdata%\Pizzeria
```

Appliquer ensuite la migration des bases de données depuis la
console du Gestionnaire de Package.

Vous devez voir `PM>` dans l'invité de commande.

### Application des migrations

```ps
 Add-Migration ReleaseDB -Context PizzeriaContext
 Add-Migration ReleaseExportDB -Context ClientContext
 Add-Migration ReleaseExportDB -Context CommisContext
 Add-Migration ReleaseExportDB -Context LivreurContext
```

### Création des bases de données SQLite

```ps
 Update-Database -Context PizzeriaContext
 Update-Database -Context ClientContext
 Update-DatabaseB -Context CommisContext
 Update-Database -Context LivreurContext
```

### Compiler et lancer le projet