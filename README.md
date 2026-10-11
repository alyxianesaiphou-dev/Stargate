# 🌌 Projet Stargate : Gestion de Missions Spatiales
 
Application développée pour le département informatique de l'IUT Robert Schuman afin de gérer des missions d'investigation galactique. Elle permet d'administrer les échanges avec les espèces extraterrestres et de coordonner la négociation de *DataBaz* (un minerai rare et convoité).
 
> Projet réalisé dans le cadre de la **SAÉ 24** du BUT Informatique (IUT Robert Schuman, Illkirch).
 
![C#](https://img.shields.io/badge/C%23-WinForms-9B59B6?style=for-the-badge)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-BA55D3?style=for-the-badge)
![SQLite](https://img.shields.io/badge/SQLite-Stargate.db-FF69B4?style=for-the-badge&logo=sqlite&logoColor=white)
 
## ⚙️ Fonctionnalités Principales
 
* **Tableau de bord central :** Vue synthétique des missions en cours, à venir et passées.
* **Administration sécurisée :** Création de nouvelles missions réservée aux administrateurs, protégée par un système d'authentification avec mot de passe haché.
* **Planification d'équipage :** Affectation d'un chef de mission (obligatoirement militaire), sélection des membres de l'équipage et définition de la feuille de route.
* **Suivi de mission (Journal) :** Visualisation en mode 1 à 1 des événements chronologiques, suivi de l'état du budget, des dépenses effectuées et des contacts avec les informateurs extraterrestres.
* **Base de données galactique :** Affichage des informations connues sur les planètes (température, gravité) et les races répertoriées (alliées ou ennemies, type d'arme, instrument de musique favori).
* **Reporting et Statistiques :** Génération de données statistiques croisées et édition automatique de bilans de mission au format PDF.
## 🛠️ Architecture & Technologies
 
* **Interface & Logique :** C# (Windows Forms)
* **Base de données :** SQLite (exploitation d'une base relationnelle locale `Stargate.db`).
* **Gestion des accès :** Isolation de l'ouverture et de la fermeture de la base de données dans une classe dédiée `Connexion.cs`.
* **Mode Déconnecté :** Utilisation d'un `DataSet` local pour le stockage et le partage des données entre les différents formulaires de l'application.
* **Intégrité des données :** Validation des objectifs de capture d'extraterrestres via des transactions SQL strictes.
* **Navigation UI :** Programmation de la chronologie du journal de bord utilisant le concept de liaison de données (Data Binding).
* **Bibliothèques utilisées :** `System.Data.SQLite` (accès à la base), `BCrypt.Net-Core` (hachage des mots de passe), `iTextSharp` (génération des PDF).
## 🚀 Lancer le projet
 
### Prérequis
 
* **Windows** (Windows Forms ne fonctionne que sous Windows).
* **Visual Studio 2022** (version 17.13 ou plus récente, pour ouvrir les fichiers `.slnx`) avec la charge de travail *Développement .NET Desktop*.
* Le **.NET Framework 4.7.2** (installé avec Visual Studio).
### Étapes
 
1. Cloner le dépôt (ou cliquer sur **Code ▸ Download ZIP** sur GitHub puis décompresser l'archive) :
   ```bash
   git clone https://github.com/alyxianesaiphou-dev/Stargate.git
   ```
2. Ouvrir la solution `Form_Sae24_Stargate/Form_Sae24_Stargate.slnx` dans Visual Studio.
3. Appuyer sur **F5** (ou cliquer sur **▶ Démarrer**) pour compiler et lancer l'application.
Les bibliothèques NuGet (dossier `packages`) et les contrôles utilisateur déjà compilés (`.dll`) sont inclus dans le dépôt : aucune installation supplémentaire n'est nécessaire.
 
> ℹ️ L'application lit la base `Stargate.db` dans son dossier d'exécution (`bin/Debug`). Si elle n'y est pas, copier `Form_Sae24_Stargate/Form_Sae24_Stargate/bin/Debug/Stargate.db` à côté de l'exécutable.

 ### Se connecter
 
La création de missions est réservée aux administrateurs. Pour se connecter, utiliser :
 
| Identifiant | Mot de passe |
|-------------|--------------|
| `Alexia`    | `Alexia`     |
 
⚠️ Attention à la majuscule : `alexia` en minuscules ne fonctionne pas.
 
> ℹ️ L'application lit la base `Stargate.db` dans son dossier d'exécution (`bin/Debug`). Si elle n'y est pas, copier `Form_Sae24_Stargate/Form_Sae24_Stargate/bin/Debug/Stargate.db` à côté de l'exécutable.

## 📂 Organisation du dépôt
 
```
Stargate/
├── Form_Sae24_Stargate/              # Application principale
│   ├── Form_Sae24_Stargate.slnx      # Solution à ouvrir dans Visual Studio
│   ├── packages/                     # Bibliothèques NuGet
│   └── Form_Sae24_Stargate/
│       ├── FormAccueil.cs            # Écran d'accueil (tableau de bord des missions)
│       ├── FormAuthentification.cs   # Connexion administrateur (BCrypt)
│       ├── FormSaisieNouvelleMission.cs  # Création d'une mission
│       ├── UCJournalBord.cs          # Journal de bord d'une mission
│       ├── Connexion.cs              # Ouverture / fermeture de la base SQLite
│       ├── mesDatas.cs               # DataSet partagé (mode déconnecté)
│       ├── Statistiques.cs           # Statistiques croisées
│       ├── Pdf.cs                    # Bilan de mission en PDF
│       ├── Images/                   # Images des planètes, extraterrestres et icônes
│       └── bin/Debug/Stargate.db     # Base de données
├── UCTrombinoPlanete/                # Contrôles utilisateur réutilisables,
├── UserControl…/                     # chacun dans sa propre solution
├── Schéma relationnel Stargate.png   # Schéma de la base
└── BCRYPT-Connexion-DataSet.pdf      # Notes sur BCrypt, la connexion et le DataSet
```
 
Chaque contrôle utilisateur (`UserControl…`, `UCTrombinoPlanete`) est un projet séparé. Pour en modifier un, ouvrir sa propre solution `.slnx`, le recompiler, puis relancer l'application principale qui utilise sa `.dll` dans `bin/Debug`.
 
## 🗄️ Base de données
 
La base SQLite `Stargate.db` contient les missions, l'équipage (militaires et civils), les planètes, les espèces extraterrestres (alliées ou ennemies), les informateurs, les dépenses, les objectifs de capture, le journal de bord et les comptes administrateurs (mots de passe hachés avec BCrypt).
 
![Schéma relationnel](Schéma%20relationnel%20Stargate.png)
