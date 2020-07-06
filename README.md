## Background
I am working on a ASP.NET CORE 3.1 WebAPI project that requires to call database procedures to get data.  I found an excellent blog on Medium written by Oguz Berkay Yerdelen (https://medium.com/@berkayyerdelen/building-restful-api-with-dapper-and-asp-net-core-37e6d9d1bdda).  The blog came with with source code on Github.  I forked and and experimented with Dapper and Repository pattern.  I made a few changes:

### Async/Await (to support high volumn webapi calls)
- Updated Services\IProductRepository.cs with keyword Task
- Updated Services\ProductRepository.cs with async/await

### Base class to manage DB connection (cleaner code)
- Added Services\BaseRepository.cs 
- Inherited BaseRepository in ProductRepository.cs
- Used WithConnection method to simplify database connection open/close

### Minor code clean up (development friendly)
- Updated connection string in asppsettings.json to use common Server=(localdb)\\mssqllocaldb (vs desktop name)
- Updated launhUrl to "swagger" (in the Properties\launchSettings.json)
- Referereced NSwag.AspNetCore package via Nuget Management and Updated Startup.cs to use UseSwaggerUi3

#Credit
The base class to manage the connection string is from https://www.joesauve.com/async-dapper-and-async-sql-connection-management/
