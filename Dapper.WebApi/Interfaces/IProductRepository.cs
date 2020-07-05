using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper.WebApi.Models;

namespace Dapper.WebApi.Interfaces
{
    public interface IProductRepository : IGenericRepository<Task>
    {
        //Task<Product> GetById(int id);
        //Task AddProduct(Product entity);
        //Task UpdateProduct(Product entity, int id);
        //Task RemoveProduct(int id);
        //Task<List<Product>> GetAllProducts();
    }
}
