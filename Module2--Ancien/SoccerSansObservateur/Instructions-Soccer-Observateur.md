# Exercice sur l'Observateur en C#

## Situation

Le package `soccer-sans-observateur.unitypackage` contient une ébauche
pour un petit jeu de Soccer. On a deux scènes : `JeuPrincipal`, un jeu
de soccer normal où les bleus jouent contre les rouges, et `MiniJeu`,
qui n'est pas encore complété.

Dans le `JeuPrincipal`, la structure du code est un peu broche à
foin : c'est le ballon de soccer elle-même qui compte les points des
rouges et des bleus.

Dans un code propre, le gestionnaire de jeu est le seul responsable de
décider comment la gestion des points est faite, mais le code n'est
pas conçu comme ça. Ça nous pose un problème au moment de réutiliser
le même script de balle pour le `MiniJeu`, car le score ne sera plus
compté de la même façon.


Est-ce que c'est la rondelle dans une partie de hockey qui doit
compter le score? Est-ce qu'elle doit activement être au courant du
fait que l'arbitre existe pour toujours lui rappeler que c'est le
temps de changer d'équipe pendant un tir de barrage?

Clairement pas.

Plutôt, l'arbitre *observe* la rondelle. Quand il se passe un
événement avec la rondelle (quand elle rentre dans un but, quand elle
revole hors du jeu par un gros coup de force, etc), l'arbitre s'en
rend compte et réagit.

On va vouloir modifier le code ici pour introduire un gestionnaire de
jeu, qui va surveiller le ballon et réagir à ce qui se passe avec lui.

Une façon simple d'améliorer le code serait de dire :

    Quand le ballon touche le fillet, il appelle une méthode dans notre
    `GameManager` pour lui dire qu'il est entrée dans le but bleu ou
    dans le but rouge

Mais en faisant ça, on se limiterait à **un GameManager spécifique**.

Ici, on sait qu'on va avoir deux petits jeux : le jeu principal, ou le
mini-jeu.


On veut donc éviter de coupler le ballon à un GameManager particulier,
ce qui peut être effectué avec le patron Observateur.


## Nettoyer le code

1. Dans la scène du `JeuPrincipal`, ajoutez un GameManager et
   assurez-vous que c'est lui qui compte les points plutôt que le
   ballon

2. Dans le script `Ball.cs`, déclarez un nouveau type d'événement via
un `delegate` :

```csharp
    public delegate void BalleCollision(Collider collider);
```

Toujours dans cette classe, définissez-vous ensuite un événement qui
pourrait être intéressant pour des observateurs externes :

```csharp
    public event BalleCollision OnBalleDansFilet;
```

Plutôt que de directement appeler les méthodes d'un GameManager pour
faire avancer la partie quand un point est compté, on voudra
simplement notifier que cet événement s'est produit et laisser le
système d'événements de C# avertir les autres objets intéressés (ie,
le gestionnaire de jeu ici).

Quand un événement se produit, la balle doit notifier les observateurs
de cet événement via le code :

```csharp
// Tous les observateurs de l'événement se font
// notifier du fait que la balle vient d'entrer dans le filet
OnBalleDansFilet?.Invoke(collider);
```

Du côté du gestionnaire de jeu, au moment de commencer une partie, il
n'a qu'à s'enregistrer comme observateur aurpès des différents
événements de la balle, en indiquant quelle méthode appeler quand un
événement se produit :

```csharp
    // On enregistre la méthode "this.PointCompte(collider)" comme chose à
    // faire à chaque fois que l'événement `OnBalleDansFilet` se produit
    _ballon.OnBalleDansFilet += PointCompte;
```


## Compléter le `MiniJeu`

Une fois le jeu principal corrigé, complétez le code du `MiniJeu` :

En haut de l'écran, il y a un cube qui change de couleur. L'objectif
du mini-jeu est de rentrer le ballon dans le bon filet, selon la
couleur actuelle du cube.

Quand on entre le ballon dans le bon filet, on gagne un point et le
ballon est remis au centre du jeu.

Quand on entre le ballon dans le mauvais filet, on ne gagne pas de
point et le ballon est remis au centre.

