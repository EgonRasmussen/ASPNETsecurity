# 1. Prevent Cross-Site Request Forgery (XSRF/CSRF)
 Se denne Pluralsight video https://app.pluralsight.com/course-player?clipId=9cbe2b8b-8ead-43e2-97a5-7faaa13744d9
> [Prevent Cross-Site Request Forgery (XSRF/CSRF) attacks in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-3.1)

1. I DevTools studeres en POST pakke i Element, hvor der browses til form. Prøv at redigere hidden attributten `__RequestVerificationToken`
    og se at en ny Submit nu giver en HTTP 400 error. 
2. I DevTools sammenlignes cookie under *Application | Cookies* med den kode, der ligger i hidden field og ses i fanen *Elements*

Denne kode sættes i html af serveren samtidigt med at den også gemmer den i en cookie. Koden er ny for hver request.
    
XCSS er bygget default ind i RazorPages. I ASP.NET Core MVC
    skal man manuelt tilføje `[ValidateAntiForgeryToken]` til samtlige POST-actions.
   
&nbsp;

# 2. Cross Site Scripting (XSS)
> [Prevent Cross-Site Scripting (XSS) in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/cross-site-scripting?view=aspnetcore-3.1)

1. Skriv følgende i et tekstfelt: `<script>alert('Hi!')</script>`. Bemærk at det ikke eksekveres, men blot vises. Åbn *View Source* i browseren og se at 
koden er blevet HTML-encodet.
2. I List-pagen ændres koden for restaurant-name til følgende: `<td>@Html.Raw(restaurant.Name)</td>`. Når siden køres, er det en JavaScript pop-up som vises!

&nbsp;

# 3. Open Redirection Attack
- Et link modtages i en Phishing email: http://bank.com/Account/LogOn?returnUrl=http://bank.net/Account/LogOn
- Logger ind på korrekt site, omdrigeres til fake
- Tror han har fejlindtastet password og prøver igen.
- Nu er password fisket!
- 
Ingen demo her. Vis blot koden:
```c#
if(!Url.IsLocalUrl(returnUrl))
{
    // throw new Exception();
}
```