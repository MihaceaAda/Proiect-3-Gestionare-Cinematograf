# Proiect-3-Gestionare-Cinematograf
Să se dezvolte un sistem software, implementat în C# pentru gestionarea unui
cinematograf. Sistemul trebuie să permită gestionarea programului de filme,
înregistrarea clienților, rezervarea biletelor și calcularea taxelor pentru biletele
rezervate.
Contextul sistemului
Cinematograful:
● Are un nume, adresă și un program de filme disponibil.
● Permite clienților înregistrați să rezerveze bilete pentru filme.
● Înregistrează toate rezervările într-un fișier.
Utilizatori:
Există două feluri de utilizatori: administrator și client
Fiecare utilizator are nevoie de un cont creat pentru a putea rezerva sau gestiona
filme (username - unic și password).
Clienții:
● Fiecare client are un nume, un cod de identificare unic și un istoric de
rezervări anterioare (filmul rezervat, data rezervării, dacă rezervarea a fost
anulată sau finalizată cu succes).
Filmele:
● Filmele sunt de două tipuri:
○ Filme de acțiune: se pot rezerva pentru un interval de maxim 3 zile.
○ Filme de dramă: se pot rezerva pentru un interval de maxim 7 zile.
● Pentru fiecare film se cunosc:
○ Titlul, regizorul, genul, anul lansării, durata (în minute).
○ Nu pot exista două filme cu același titlu în programul cinematografului.
○ Disponibilitatea pentru rezervare (dacă filmul este programat în sălile
cinematografului în perioada aleasă).
Rezervările:
● Fiecare rezervare include un client, un film asociat, perioada de rezervare
(dată de început și dată de final) și durata (număr de zile).
● Taxele pentru biletele rezervate se calculează automat: 20 RON/zi pentru
filmele de acțiune și 15 RON/zi pentru filmele de dramă.
● Prețul final al rezervării se calculează utilizând formula: 50 * număr zile.
Anulările:
● Programul va permite anularea rezervărilor efectuate, actualizând istoricul
clientului și returnând banii pentru biletele anulate, dacă este cazul
Funcționalități
Cinematograful va fi creat în prealabil dacă nu există, respectiv încărcat din fișier
dacă a fost deja creată.
Aplicația dispune de următorul meniu:
1. Autentificare / Înregistrare
2. Pentru un administrator:
a. Adăugare film
b. Ștergere film
c. Modificare interval rezervare film
d. Ștergere client
e. Vizualizare istoric închirieri filme (per total)
f. Vizualizare istoric închirieri filme ale unui client
g. Vizualizare câștiguri totale
h. Vizualizare câștiguri pentru o anume perioadă
3. Pentru un client
a. Vizualizare filme disponibile pentru închiriat
b. Creeare rezervare
c. Modificare rezervare
d. Anulare rezervare
