# MediatekDocuments
Cette application permet de gérer les documents (livres, DVD, revues) d'une médiathèque. Elle a été codée en C# sous Visual Studio 2019. C'est une application de bureau, prévue d'être installée sur plusieurs postes accédant à la même base de données.<br>
L'application exploite une API REST pour accéder à la BDD MySQL. Des explications sont données plus loin, ainsi que le lien de récupération.
## Présentation
![image](https://github.com/user-attachments/assets/6fa4c93c-024e-4b96-978c-ea2a4b662112)
## Installation
Pour utiliser l’application, téléchargez le fichier d’installation 'MediaTekDocuments/publish/setup.exe' disponible dans ce dépôt. Exécutez-le, puis suivez les étapes indiquées par l’assistant. Une fois l’installation terminée, vous pouvez accéder à l’application.
## Les différents onglets
### Connexion  
Lors du lancement, l’application affiche une fenêtre de connexion. Il est nécessaire de s’authentifier avec un identifiant et un mot de passe. L’accès aux fonctionnalités est déterminé selon le service de l’utilisateur :  
- L’administrateur et les utilisateurs du service administratif disposent de tous les droits (accès complet au catalogue et aux commandes)
- Les utilisateurs du service prêts ont un accès restreint au catalogue uniquement  
- Les utilisateurs du service culture ne peuvent pas accéder à l’application ; un message d’erreur est affiché et l'application se ferme automatiquement
Après authentification, si l’utilisateur appartient au service administratif, une fenêtre s’affiche listant les abonnements arrivant prochainement à expiration. Une fois cette alerte validée, l’application affiche le catalogue. Les autres utilisateurs accèdent directement au catalogue, sans accès à la gestion des commandes.
### Onglet 1 : Livres
Cet onglet présente la liste des livres, triée par défaut sur le titre.<br>
La liste comporte les informations suivantes : titre, auteur, collection, genre, public, rayon.
![img2](https://github.com/CNED-SLAM/MediaTekDocuments/assets/100127886/e3f31979-cf24-416d-afb1-a588356e8966)
#### Recherches
<strong>Par le titre :</strong> Il est possible de rechercher un ou plusieurs livres par le titre. La saisie dans la zone de recherche se fait en autocomplétions sans tenir compte de la casse. Seuls les livres concernés apparaissent dans la liste.<br>
<strong>Par le numéro :</strong> il est possible de saisir un numéro et, en cliquant sur "Rechercher", seul le livre concerné apparait dans la liste (ou un message d'erreur si le livre n'est pas trouvé, avec la liste remplie à nouveau).
#### Filtres
Il est possible d'appliquer un filtre (un seul à la fois) sur une de ces 3 catégories : genre, public, rayon.<br>
Un combo par catégorie permet de sélectionner un item. Seuls les livres correspondant à l'item sélectionné, apparaissent dans la liste (par exemple, en choisissant le genre "Policier", seuls les livres de genre "Policier" apparaissent).<br>
Le fait de sélectionner un autre filtre ou de faire une recherche, annule le filtre actuel.<br>
Il est possible aussi d'annuler le filtre en cliquant sur une des croix.
#### Tris
Le fait de cliquer sur le titre d'une des colonnes de la liste des livres, permet de trier la liste par rapport à la colonne choisie.
#### Affichage des informations détaillées
Si la liste des livres contient des éléments, par défaut il y en a toujours un de sélectionné. Il est aussi possible de sélectionner une ligne (donc un livre) en cliquant n'importe où sur la ligne.<br>
La partie basse de la fenêtre affiche les informations détaillées du livre sélectionné (numéro de document, code ISBN, titre, auteur(e), collection, genre, public, rayon, chemin de l'image) ainsi que l'image.
### Onglet 2 : DVD
Cet onglet présente la liste des DVD, triée par titre.<br>
La liste comporte les informations suivantes : titre, durée, réalisateur, genre, public, rayon.<br>
Le fonctionnement est identique à l'onglet des livres.<br>
La seule différence réside dans certaines informations détaillées, spécifiques aux DVD : durée (à la place de ISBN), réalisateur (à la place de l'auteur), synopsis (à la place de collection).
### Onglet 3 : Revues
Cet onglet présente la liste des revues, triées par titre.<br>
La liste comporte les informations suivantes : titre, périodicité, délai mise à dispo, genre, public, rayon.<br>
Le fonctionnement est identique à l'onglet des livres.<br>
La seule différence réside dans certaines informations détaillées, spécifiques aux revues : périodicité (à la place de l'auteur), délai mise à dispo (à la place de collection).
### Onglet 4 : Parutions des revues
Cet onglet permet d'enregistrer la réception de nouvelles parutions d'une revue.<br>
Il se décompose en 2 parties (groupbox).
#### Partie "Recherche revue"
Cette partie permet, à partir de la saisie d'un numéro de revue (puis en cliquant sur le bouton "Rechercher"), d'afficher toutes les informations de la revue (comme dans l'onglet précédent), ainsi que son image principale en petit, avec en plus la liste des parutions déjà reçues (numéro, date achat, chemin photo). Sur la sélection d'une ligne dans la liste des parutions, la photo de la parution correspondante s'affiche à droite.<br>
Dès qu'un numéro de revue est reconnu et ses informations affichées, la seconde partie ("Nouvelle parution réceptionnée pour cette revue") devient accessible.<br>
Si une modification est apportée au numéro de la revue, toutes les zones sont réinitialisées et la seconde partie est rendue inaccessible, tant que le bouton "Rechercher" n'est pas utilisé.
#### Partie "Nouvelle parution réceptionnée pour cette revue"
Cette partie n'est accessible que si une revue a bien été trouvée dans la première partie.<br>
Il est possible alors de réceptionner une nouvelle parution en saisissant son numéro, en sélectionnant une date (date du jour proposée par défaut) et en cherchant l'image correspondante (optionnel) qui doit alors s'afficher à droite.<br>
Le clic sur "Valider la réception" va permettre d'ajouter un tuple dans la table Exemplaire de la BDD. La parution correspondante apparaitra alors automatiquement dans la liste des parutions et les zones de la partie "Nouvelle parution réceptionnée pour cette revue" seront réinitialisées.<br>
Si le numéro de la parution existe déjà, il n’est pas ajouté et un message est affiché.
![img3](https://github.com/CNED-SLAM/MediaTekDocuments/assets/100127886/225e10f2-406a-4b5e-bfa9-368d45456056)
## Gestion des commandes
Dans chaque onglet du catalogue (livres, DVD, revues), un bouton « Gérer les commandes » est situé en haut à droite. Un clic sur ce bouton ouvre une nouvelle fenêtre dédiée à la gestion des commandes. L’onglet affiché par défaut dépend de la section d’origine. Par exemple, si vous étiez sur l’onglet DVD, l’onglet de commande correspondant s’ouvrira automatiquement. Il est ensuite possible de naviguer entre les types de commandes via les onglets disponibles. Cette fenêtre comporte 3 onglets distinct, Livre, DVD et revues qui permet de gérer les commandes de chacuns des types de produit.
### Accès à la gestion des commandes  
Dans chaque onglet du catalogue (livres, DVD, revues), un bouton « Gérer les commandes » est situé en haut à droite. Un clic sur ce bouton ouvre une nouvelle fenêtre dédiée à la gestion des commandes. L’onglet affiché par défaut dépend de la section d’origine. Par exemple, si vous étiez sur l’onglet DVD, l’onglet de commande correspondant s’ouvrira automatiquement. Il est ensuite possible de naviguer entre les types de commandes via les onglets disponibles.<br>
La fenêtre de gestion des commandes comporte trois onglets distincts :  
- Livres  
- DVD  
- Revues
### Commandes de livres ou de DVD  
Le fonctionnement des commandes pour les livres et les DVD étant similaire, seule la gestion des livres est présentée ici à titre d’exemple. <br>
L’interface de commande se divise en quatre zones :  
- Saisie du numéro de document  
- Affichage des informations détaillées du document  
- Liste des commandes existantes pour ce document  
- Zone d’édition pour la création ou la modification d’une commande
### Rechercher un document  
Renseignez le numéro du document dans la zone prévue, puis cliquez sur « Rechercher ». Si le document est trouvé, ses informations sont affichées, ainsi que les commandes qui lui sont associées.
### Ajouter une commande 
Cliquez sur « Créer une commande » après avoir sélectionné un document. La zone d’édition devient alors active. Saisissez la date, le montant, et le nombre d’exemplaires. Par défaut, une nouvelle commande est au statut « En cours ». Cliquez sur « Valider la modification » pour enregistrer la commande. Il est possible d’annuler l’opération à tout moment via le bouton « Annuler la modification ».
### Modifier une commande  
Pour modifier une commande existante, sélectionnez-la dans la liste puis cliquez sur « Modifier la commande ». Vous pouvez alors ajuster les informations, y compris le statut. Les statuts possibles sont :  
- En cours  
- Relancée  
- Livrée  
- Réglée
Les transitions entre statuts sont encadrées : une commande livrée ne peut plus repasser à un état antérieur. Une fois réglée, la commande est considérée comme définitive.
### Supprimer une commande  
Une commande peut être supprimée tant qu’elle n’a pas atteint le statut « Livrée ». Passé ce stade, la suppression n’est plus autorisée.
### Commandes de revues (abonnements)  
La gestion des abonnements se fait depuis l’onglet « Revues » de la fenêtre de gestion des commandes. L’interface est composée de quatre parties :  
- Recherche de revue  
- Informations détaillées de la revue  
- Liste des abonnements  
- Zone d’édition d’un abonnement
### Rechercher une revue  
Saisissez le numéro de la revue puis cliquez sur « Rechercher ». Si elle existe, ses informations s’affichent, ainsi que les exemplaires et les abonnements associés.<br>
### Ajouter un abonnement ou un renouvellement  
Cliquez sur « Nouvel abonnement/renouvellement ». La zone d’édition devient active. Renseignez la date de début, la date de fin, et le montant. La date de début doit être antérieure à la date de fin. Cliquez sur « Valider l’opération » pour enregistrer l’abonnement. En cas d’erreur, utilisez le bouton « Annuler l’opération ».<br>
### Supprimer un abonnement  
Un abonnement ne peut être supprimé que s’il n’est associé à aucune parution (aucun exemplaire reçu pendant sa période de validité). Dans le cas contraire, l’option de suppression est désactivée.<br>
## La base de données
La base de données 'mediatek86 ' est au format MySQL.<br>
Voici sa structure :<br>
![image2](https://github.com/user-attachments/assets/bad5a602-283a-4801-a63b-b13efc664945)
<br>On distingue les documents "génériques" (ce sont les entités Document, Revue, Livres-DVD, Livre et DVD) des documents "physiques" qui sont les exemplaires de livres ou de DVD, ou bien les numéros d’une revue ou d’un journal.<br>
Chaque exemplaire est numéroté à l’intérieur du document correspondant, et a donc un identifiant relatif. Cet identifiant est réel : ce n'est pas un numéro automatique. <br>
Un exemplaire est caractérisé par :<br>
. un état d’usure, les différents états étant mémorisés dans la table Etat ;<br>
. sa date d’achat ou de parution dans le cas d’une revue ;<br>
. un lien vers le fichier contenant sa photo de couverture de l'exemplaire, renseigné uniquement pour les exemplaires des revues, donc les parutions (chemin complet) ;
<br>
Un document a un titre (titre de livre, titre de DVD ou titre de la revue), concerne une catégorie de public, possède un genre et est entreposé dans un rayon défini. Les genres, les catégories de public et les rayons sont gérés dans la base de données. Un document possède aussi une image dont le chemin complet est mémorisé. Même les revues peuvent avoir une image générique, en plus des photos liées à chaque exemplaire (parution).<br>
Une revue est un document, d’où le lien de spécialisation entre les 2 entités. Une revue est donc identifiée par son numéro de document. Elle a une périodicité (quotidien, hebdomadaire, etc.) et un délai de mise à disposition (temps pendant lequel chaque exemplaire est laissé en consultation). Chaque parution (exemplaire) d'une revue n'est disponible qu'en un seul "exemplaire".<br>
Un livre a aussi pour identifiant son numéro de document, possède un code ISBN, un auteur et peut faire partie d’une collection. Les auteurs et les collections ne sont pas gérés dans des tables séparées (ce sont de simples champs textes dans la table Livre).<br>
De même, un DVD est aussi identifié par son numéro de document, et possède un synopsis, un réalisateur et une durée. Les réalisateurs ne sont pas gérés dans une table séparée (c’est un simple champ texte dans la table DVD).
Enfin, 3 tables permettent de mémoriser les données concernant les commandes de livres ou DVD et les abonnements. Une commande est effectuée à une date pour un certain montant. Un abonnement est une commande qui a pour propriété complémentaire la date de fin de l’abonnement : il concerne une revue.  Une commande de livre ou DVD a comme caractéristique le nombre d’exemplaires commandé et concerne donc un livre ou un DVD.<br>
<br>
La base de données est remplie de quelques exemples pour pouvoir tester son application. Dans les champs image (de Document) et photo (de Exemplaire) doit normalement se trouver le chemin complet vers l'image correspondante. Pour les tests, vous devrez créer un dossier, le remplir de quelques images et mettre directement les chemins dans certains tuples de la base de données qui, pour le moment, ne contient aucune image.<br>
Lorsque l'application sera opérationnelle, c'est le personnel de la médiathèque qui sera en charge de saisir les informations des documents.
## L'API REST
L'accès à la BDD se fait à travers une API REST protégée par une authentification basique.<br>
Le code de l'API se trouve ici :<br>
https://github.com/CNED-SLAM/rest_mediatekdocuments<br>
avec toutes les explications pour l'utiliser (dans le readme).
## Installation de l'application
Ce mode opératoire permet d'installer l'application pour pouvoir travailler dessus.<br>
- Installer Visual Studio 2019 entreprise et les extension Specflow et newtonsoft.json (pour ce dernier, voir l'article "Accéder à une API REST à partir d'une application C#" dans le wiki de ce dépôt : consulter juste le début pour la configuration, car la suite permet de comprendre le code existant).<br>
- Télécharger le code et le dézipper puis renommer le dossier en "mediatekdocuments".<br>
- Récupérer et installer l'API REST nécessaire (https://github.com/CNED-SLAM/rest_mediatekdocuments) ainsi que la base de données (les explications sont données dans le readme correspondant).
