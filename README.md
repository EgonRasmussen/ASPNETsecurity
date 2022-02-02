# 1.Cross-SiteRequestForgeryCSRF

### Med [IgnoreAntiforgeryToken]
1. Start projekteterne **Bank.WebApp** (port 44336) og **Bank.EvilSite** (port 44344) samtidigt (Multiple startup) i Debug.
2. Log ind med f�lgende credentials: email: user@eucsyd.dk og pw: P@ssw0rd
3. �bn *DevTools | Application* og udpeg `.AspNetCore.Identity.Application` Cookie.
4. Send en email til dig selv med f�lgende indhold: "Klik her for at se en kattekilling: https://localhost:44344/index.html"
5. Klik p� linket i mailen. Browseren med Banken �ben vil �bne en ny fane med et kattebillede.
6. Refresh fanen med banken og se at din konto er blevet l�nset for kr. 10 000!

#### Med AntiforgeryToken aktiv

7. Udkomment�r attributten `[IgnoreAntiforgeryToken]` i PageModel.
8. Gentag fors�get med en hacker mail og se at det nu ikke lykkes!
9. Kig p� *DevTools | Application* og bem�rk en Cookie kaldet: `.AspNetCore.Antiforgery`. Den benyttes til at gemme en AntiforgeryToken p� serveren, som er knyttet til brugerens session.
10. Kig ogs� p� *DevTools | Elements* og find `<input>` med navnet: __RequestVerificationToken af typen Hidden. Denne v�rdi �ndres for hver roundtrip.
11. Serveren henter sin AntiforgeryToken v�rdi og sammenligner med den der postes og de skal v�re ens for at en Post metode vil eksekvere.
12. Pr�v at redigere i AntiforgeryToken i DevTools og lav en ny Withdraw. Nu kan der ikke Postes! 