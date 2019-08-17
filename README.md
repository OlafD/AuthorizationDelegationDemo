Example on how to use permission delegation in an Azure Web App. This project was set up in the following way:

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

