# 1.Antiforgery

### Med [IgnoreAntiforgeryToken]
1. Start projektet Bank.WebApp. �bn DevTools.
2. Log ind med f�lgende credentials: email: user@eucsyd.dk og pw: P@ssw0rd
3. �bn *DevTools | Application* og udpeg `.AspNetCore.Identity.Application Cookie`
4. Start Bank.EvilSite ved at h�jre klikke p� projektet og v�lge:* Debug | Start New Instance*. Bem�rk at den k�rer p� port 44344.
5. Send en email til dig selv med f�lgende indhold: Klik her for at se en kattekilling: https://localhost:44344/index.html
6. Klik p� linket i mailen. Browseren med Banken �ben vil �bne en ny fane med et kattebillede.
7. Refresh fanen med banken og se at din konto er blevet l�nset for kr. 10 000!

#### Med AntigorgeryToken aktiv

8. Udkomment�r attributten `[IgnoreAntiforgeryToken]` i PageModel.
9. Gentag fors�get med en hacker mail og se at det nu ikke lykkes!
9. Kig p� *DevTools | Application *og bem�rk en Cookie kaldet: `.AspNetCore.Antiforgery`. Den benyttes til at gemme en AntiforgeryToken p� serveren, som er knyttet til brugerens session.
10. Kig ogs� p�* DevTools | Elements* og find `<input>` med navnet: __RequestVerificationToken af typen Hidden. Denne v�rdi �ndres for hver roundtrip.
11. Serveren henter sin AntiforgeryToken v�rdi og sammenligner med den der postes og de skal v�re ens for at en Post metode vil eksekvere.
13. Pr�v at redigere i AntiforgeryToken i DevTools og lav en ny Withdraw. Nu kan der ikke Postes!