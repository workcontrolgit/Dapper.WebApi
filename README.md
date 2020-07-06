This repository is a forked from https://github.com/berkayyerdelen/Dapper.WebApi.  Below is a summary of refactoring to the repo

### Refactor controller and repository class to use async/await
-Updated Services\IProductRepository.cs with keyword Task
-Updated Services\ProductRepository.cs with async/await

### Simplify connection code by adding a base class to manage connection string
- Added Services\BaseRepository.cs 
- Inherited BaseRepository in ProductRepository.cs
- Used WithConnection method to simplify database connection open/close