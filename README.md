This repository is a forked from https://github.com/berkayyerdelen/Dapper.WebApi.  Below is a summary of refactoring to the forked repo

### Async/Await to support scalability
-Updated Services\IProductRepository.cs with keyword Task
-Updated Services\ProductRepository.cs with async/await

### Base class to manage DB connection (clean code)
- Added Services\BaseRepository.cs 
- Inherited BaseRepository in ProductRepository.cs
- Used WithConnection method to simplify database connection open/close

### Code clean up
- Updated connection string in asppsettings.json to use common Server=(localdb)\\mssqllocaldb (vs desktop name)
- Updated larcunUrl to "swagger" (in the Properties\launchSettings.json)
- Referereced NSwag.AspNetCore via NugetManagement and Updated Startup.cs to use UseSwaggerUi3
