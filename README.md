# AspNetWebApp
Asp.Net Mvc Web Application

# Materials Used

- IDE : Jetbrains Rider on Macos(Can be use Visual Studio or other stuffs)
- Tech : Asp.Net Web Application
- Framework : .Net Framework v4.7.2
- Database : Postgresql
- Theme : adminlte (https://adminlte.io/)

## * Repository Pattern

## * Use of layered architecture,
- AspNetWebApp
- AspNetWebApp.Entities
- AspNetWebApp.Dal 
- AspNetWebApp.Bll

## * Code First with EntityFramework , 
You can migrate of datase with Code First Entity Framework.
Basic CLI commands for using Entitiy Framework on Visual Studio is down below.
```
After clone the project;
Enable-Migrations
Add-Migration MigrationName
update-database
```

## * Authentication with Sessions
### Web.Config
```
 <system.web>
    <compilation debug="true" targetFramework="4.7.2" />
    <httpRuntime targetFramework="4.5" />
    <authentication mode="Forms">
      <forms loginUrl="/Login/Index/">
      </forms>
    </authentication>
  </system.web>
```
### Global.asax.cs
For all pages security
```
GlobalFilters.Filters.Add(new AuthorizeAttribute());
```
### LoginController.cs
Exclude control security
```
[AllowAnonymous]
    public class LoginController : Controller
    {
```


