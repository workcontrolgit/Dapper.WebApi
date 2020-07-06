This repository is a forked from https://github.com/berkayyerdelen/Dapper.WebApi.  I made the following update to the repo

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
