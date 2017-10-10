# vega
Learning Asp.net Core with SPA using angular


# DotNet Core package --version 2.0.0
* `<DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="2.0.0" />`
* `dotnet add package Microsoft.EnittyFrameworkCore.SqlServer`
* `<DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" />`
* `dotnet add package AutoMapper`
* `dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection`


# Entity Framework Core Command --version 2.0.0
* Add Migrations - `dotnet ef migrations add InitialModel`
* Remove Migrations -  `dotnet ef migrations remove`
* Update Database - `dotnet ef database update`
* Update database with last Migragions - `dotnet ef database update 0`


# Errors and Resolution
* Self Referencing Loop - ` To prevent self refrenceing loop we convert API model to resources latest commint is - https://github.com/vinay01joshi/vega/commit/fed7f117bb7774ffebda8fbdc320d93bb02610fc  | Best practive - Crate View model as we are creating here as resources `

* Can not Genereate component using angular cli - Read following stackover flow article.
    ` https://stackoverflow.com/questions/46268181/i-cant-add-new-component-with-angular-cli-in-asp-net-core-spas | command is  - " ng g c vehicle-form  --skip-import=true" `

* All modules are not complted on first time webpack Errors : - (Run following commands)
    `webpack --config webpack.config.vendor.js ` and then run `webpack`

# Open Issues
* NgZone is Not defined `https://github.com/vinay01joshi/vega/issues/4`