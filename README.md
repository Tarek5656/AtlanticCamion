# Atlantic Camion

Application Windows Forms en VB.NET pour la gestion d’un parc de camions (fiches camions, parcours, consommation de gasoil et réparations).

## Fonctionnalités

- Gestion des fiches camions
- Suivi de la consommation de gasoil
- Gestion des parcours
- Suivi des réparations
- Stockage local des données via SQLite (`ProjetAtlantic.db`)

## Stack technique

- .NET 8 (`net8.0-windows`)
- Windows Forms
- SQLite (`System.Data.SQLite`)
- MySQL driver disponible (`MySql.Data`)

## Prérequis

- Windows
- [.NET SDK 8.0](https://dotnet.microsoft.com/download)

## Lancer le projet

Depuis la racine du dépôt :

```bash
dotnet restore
dotnet run --project AtlanticCamion.vbproj
```

## Build

```bash
dotnet build AtlanticCamion.vbproj
```

## Structure principale

- `Principal.vb` : formulaire principal
- `FicheCamion*.vb` : gestion des camions
- `Parcours*.vb` : gestion des parcours
- `ConsommationGasoil*.vb` : suivi carburant
- `Réparations*.vb` : gestion des réparations
- `Connexion.vb` : connexion SQLite

