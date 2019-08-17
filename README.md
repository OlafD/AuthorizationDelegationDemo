Example on how to use permission delegation in an Azure Web App. Also see this link for more information about delegation: 
https://eur03.safelinks.protection.outlook.com/?url=https%3A%2F%2Fdocs.microsoft.com%2Fen-us%2Fazure%2Factive-directory%2Fdevelop%2Fv1-permissions-and-consent&data=01%7C01%7Colaf.didszun%40plan-b-gmbh.com%7C008bb06597aa46419aba08d7226472f5%7C07957fd777e54597be214fcbc87e451a%7C1&sdata=3CevythMYXRUbts99m38JZT6lWNjSr%2FtcMm2%2Fx%2FP%2F6w%3D&reserved=0

Very important is the sentence "Your app can never have more privileges than the signed-in user."!

This project was set up in the following way:

1. Create a new ASP.NET Web Application in Visual Studio (I used Visual Studio 2017), take an MVC application and configure 
authentication against an Azure Active Directory. This will create a new App Registration in the selected Azure Active Directory.

2. In the App Registration for the Azure Web Application that was created by Visual Studio add a Client Secret.

3. Add API Permissions the the App Registration to access SharePoint Online. I selected AllSites.Manage as delegatetd permissions.

4. Add the SharePpint PnP package from NuGet to the Visual Studio project.

5. In the Web.config add the following entries in the appSettings section:
- key "Resources" has the root site of SharePoint Online of the tenant to use in the value
- key "ida:ClientSecret" has the configured client secret (see above) in the value
- key "SiteUrl" has the web address of the SharePoint site in the tenant, where we want to connect to in the value

6. Added the TokenCache class to store the access tokens of the logged in users

7. Make necessary modifications to the Startup.cs to initialize the AccessTokenCache

8. Make necessary modifications to the Startup.Auth.cs to handle the authentication and storing the access token

9. Add ShowWebTitle method to the HomeController with the connect to the SharePoint Online site, when an access token was found in
the cache

10. Add the view for ShowWebTitle to show some output, when the connection to the SharePoint site was established.

