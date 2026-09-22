# 🌌 Projet Stargate : Gestion de Missions Spatiales

Application développée pour le département informatique de l'IUT Robert Schuman afin de gérer des missions d'investigation galactique. Elle permet d'administrer les échanges avec les espèces extraterrestres et de coordonner la négociation de *DataBaz* (un minerai rare et convoité).

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
