.Net Core, .Net 8, EF Core (code first), Angular 16, Swagger

INSTALLATION REQUIREMENTS
Visual Studio 2022 or higher
.Net 8.0

Clone repository in Visual Studio, run master branch (default). **SignUpApp.Server** is set as startup project. Press Start ▶ for debugging.
On first run automatic npm install and nuget packages restore will take some time. 
Will automatically open 2 windows: Swagger API in Chrome and SignupClient (in Edge or Crome - depends on your default settings). 
When server runs - you can open SignupClient in any other browser.

If edited in swagger - refresh client to see the changes. Web Socket is not implemented as its not required. 

**Domain project** contains all relevant business logic, data access layer( Dto converters) and EF Migrations. On initialization the MSSQL localhost data base UsersDbConection will be seeded. 

**signupapp.client** - angular project, set up to launch automatically in brouser. Lounches lazy loaded Usersmodule with responcive table of content. Edit/Add components are reusable. Includes PrimeNG & Nebulat UI components and some Bootstrap for styling.
![image](https://github.com/ola-goldin/SignUpApp/assets/10331361/5661ffbd-fd8a-4160-9710-d2461f83f369)

**SignUpApp.Server** - start up project, web api with simple swagger. Contains a controller with CRUD only. 


