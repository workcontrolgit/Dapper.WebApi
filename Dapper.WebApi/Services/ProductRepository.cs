using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper.WebApi.Models;
using Dapper.WebApi.Services.ExecuteCommands;
using Dapper.WebApi.Services.Queries;
using Microsoft.Extensions.Configuration;

namespace Dapper.WebApi.Services
{
    public class ProductRepository : BaseRepository, IProductRepository 
    {
        private readonly IConfiguration _configuration;
        private readonly ICommandText _commandText;
        private readonly string _connStr;
        private readonly IExecuters _executers;

        public ProductRepository(IConfiguration configuration, ICommandText commandText, IExecuters executers) : base(configuration)
        {
            _commandText = commandText;
            _configuration = configuration;
            _connStr = _configuration.GetConnectionString("Dapper");
            _executers = executers;

        }

        public async Task<List<Product>> GetAllProducts()
        {
            //var query = _executers.ExecuteCommand(_connStr,
            //       conn => conn.Query<Product>(_commandText.GetProducts)).ToList();
            //return query;

            return await WithConnection(async conn =>
            {
                var result = await conn.QueryAsync<Product>(_commandText.GetProducts);
                return result.ToList();
            });

        }
        //public async Task<List<Product>> GetAllProducts()
        //{
        //    using (IDbConnection conn = new SqlConnection(_connStr))
        //    {
        //        conn.Open();
        //        List<Product> result = (List<Product>)await conn.QueryAsync<Product>(_commandText.GetProducts);
        //        return result;
        //    }
        //}
        // Original
        //public Product GetById(int id)
        //{
        //    var product = _executers.ExecuteCommand<Product>(_connStr, conn =>
        //        conn.Query<Product>(_commandText.GetProductById, new { @Id = id }).SingleOrDefault());
        //    return product;
        //}
        // Without baserepository
        //public async Task<Product> GetById(int id)
        //{
        //    using (var conn = new SqlConnection(_connStr))
        //    {
        //        await conn.OpenAsync();
        //        var result = await conn.QuerySingleOrDefaultAsync<Product>(_commandText.GetProductById, new { Id = id });
        //        return result;
        //    }
        //}

        // Use baserepository
        public async Task<Product> GetById(int id)
        {
            return await WithConnection(async conn =>
            {
                var result = await conn.QueryFirstOrDefaultAsync<Product>(_commandText.GetProductById, new { Id = id });
                return result;
            });
        }


        public void AddProduct(Product entity)
        {
            _executers.ExecuteCommand(_connStr, conn => {
                var query = conn.Query<Product>(_commandText.AddProduct,
                    new { Name = entity.Name, Cost = entity.Cost, CreatedDate = entity.CreatedDate });
            });
        }
        public void UpdateProduct(Product entity, int id)
        {
            _executers.ExecuteCommand(_connStr, conn =>
            {
                var query = conn.Query<Product>(_commandText.UpdateProduct,
                    new { Name = entity.Name, Cost = entity.Cost, Id = id });
            });
        }

        public void RemoveProduct(int id)
        {
            _executers.ExecuteCommand(_connStr, conn =>
            {
                var query = conn.Query<Product>(_commandText.RemoveProduct, new { Id = id });
            });
        }


     
    }
}
