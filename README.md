# 1.Antiforgery

### Med [IgnoreAntiforgeryToken]
1. Start projektet Bank.WebApp. Åbn DevTools.
2. Log ind med følgende credentials: email: user@eucsyd.dk og pw: P@ssw0rd
3. Åbn *DevTools | Application* og udpeg `.AspNetCore.Identity.Application Cookie`
4. Start Bank.EvilSite ved at højre klikke på projektet og vælge:* Debug | Start New Instance*. Bemærk at den kører på port 44344.
5. Send en email til dig selv med følgende indhold: Klik her for at se en kattekilling: https://localhost:44344/index.html
6. Klik på linket i mailen. Browseren med Banken åben vil åbne en ny fane med et kattebillede.
7. Refresh fanen med banken og se at din konto er blevet lænset for kr. 10 000!

#### Med AntigorgeryToken aktiv

8. Udkommentér attributten `[IgnoreAntiforgeryToken]` i PageModel.
9. Gentag forsøget med en hacker mail og se at det nu ikke lykkes!
9. Kig på *DevTools | Application *og bemærk en Cookie kaldet: `.AspNetCore.Antiforgery`. Den benyttes til at gemme en AntiforgeryToken på serveren, som er knyttet til brugerens session.
10. Kig også på* DevTools | Elements* og find `<input>` med navnet: __RequestVerificationToken af typen Hidden. Denne værdi ændres for hver roundtrip.
11. Serveren henter sin AntiforgeryToken værdi og sammenligner med den der postes og de skal være ens for at en Post metode vil eksekvere.
13. Prøv at redigere i AntiforgeryToken i DevTools og lav en ny Withdraw. Nu kan der ikke Postes!