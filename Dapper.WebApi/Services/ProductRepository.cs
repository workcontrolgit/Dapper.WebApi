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
        //private readonly IConfiguration _configuration;
        private readonly ICommandText _commandText;
        //private readonly string _connStr;
        //private readonly IExecuters _executers;

//        public ProductRepository(IConfiguration configuration, ICommandText commandText, IExecuters executers) : base(configuration)
        public ProductRepository(IConfiguration configuration, ICommandText commandText) : base(configuration)
        {
            _commandText = commandText;
            //_configuration = configuration;
            //_connStr = _configuration.GetConnectionString("Dapper");
            //_executers = executers;

        }

        public async Task<List<Product>> GetAllProducts()
        {

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Product>(_commandText.GetProducts);
                return query.ToList();
            });

            //var query = await _executers.ExecuteCommand(_connStr,
            //       async conn => await conn.QueryAsync<Product>(_commandText.GetProducts));
            //return query.ToList();

        }

        // Use baserepository
        public async Task<Product> GetById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Product>(_commandText.GetProductById, new { Id = id });
                return query;
            });

            //var query = await _executers.ExecuteCommand(_connStr,
            //       async conn => await conn.QueryFirstOrDefaultAsync<Product>(_commandText.GetProductById, new { Id = id }));
            //return query;

        }

        public async Task AddProduct(Product entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.AddProduct,
                    new { Name = entity.Name, Cost = entity.Cost, CreatedDate = entity.CreatedDate });
            });


            //await _executers.ExecuteCommand(_connStr,  conn =>
            //{
            //    conn.ExecuteAsync(_commandText.AddProduct,
            //        new { Name = entity.Name, Cost = entity.Cost, CreatedDate = entity.CreatedDate });
            //});
        }
        public async Task UpdateProduct(Product entity, int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.UpdateProduct,
                    new { Name = entity.Name, Cost = entity.Cost, Id = id });
            });


            //await _executers.ExecuteCommand(_connStr, conn =>
            //{
            //    conn.ExecuteAsync(_commandText.UpdateProduct,
            //        new { Name = entity.Name, Cost = entity.Cost, Id = id });
            //});
        }

        public async Task RemoveProduct(int id)
        {

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.RemoveProduct, new { Id = id });
            });


            //await _executers.ExecuteCommand(_connStr, conn =>
            //{
            //    conn.ExecuteAsync(_commandText.RemoveProduct, new { Id = id });
            //});
        }


     
    }
}
