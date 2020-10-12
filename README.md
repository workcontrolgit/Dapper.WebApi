## Background
I am working on a ASP.NET CORE 3.1 WebAPI project that requires to call database procedures to get data.  I found an excellent blog on Medium written by Oguz Berkay Yerdelen (https://medium.com/@berkayyerdelen/building-restful-api-with-dapper-and-asp-net-core-37e6d9d1bdda).  The blog came with with source code on Github (https://github.com/berkayyerdelen/Dapper.WebApi).  I forked and experimented with Dapper and Repository pattern.  I made a few changes to the original code and they can be found in this repo:

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

# Credit
The base class to manage the connection string is from https://www.joesauve.com/async-dapper-and-async-sql-connection-management/

# Example of ASP.NET WebAPI using Dapper
I am using Dapper in a sample ASP.NET CORE 3.1 project that is part of the DevKit WebAPI Security tutorial.  The DevKit contains source code for an integrated Client, Api Resource and Secure Token Service projects that all can run on localhost.   If you are interested to see how dapper is used in a large project, visit https://medium.com/@fuji.nguyen/devkit-webapi-security-d7a45e34a5cd
