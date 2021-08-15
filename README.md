# 2. Cross Site Scripting (XSS)
> [Prevent Cross-Site Scripting (XSS) in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/cross-site-scripting?view=aspnetcore-3.1)

1. Skriv følgende i f.eks. Edit-tekstfeltet: `<script>alert('Hi!')</script>`. Bemærk at det ikke eksekveres, men blot vises. Åbn *View Source* i browseren og se at 
koden er blevet HTML-encodet: `<h2>&lt;script&gt;alert(&#x27;Hi!&#x27;)&lt;/script&gt;</h2>`
2. I List-pagen ændres koden for restaurant-name til følgende: `<td>@Html.Raw(restaurant.Name)</td>`. N�r siden køres, er det en JavaScript pop-up som vises!

&nbsp;

# 3. Open Redirection Attack
- Et link modtages i en Phishing email: http://bank.com/Account/LogOn?returnUrl=http://bank.net/Account/LogOn
- Logger ind på korrekt site, omdrigeres til en fake.
- Tror han har fejlindtastet password og prøver igen.
- Nu er password fisket!

Ingen demo her. Vis blot koden:
```c#
if(!Url.IsLocalUrl(returnUrl))
{
    // throw new Exception();
}
```