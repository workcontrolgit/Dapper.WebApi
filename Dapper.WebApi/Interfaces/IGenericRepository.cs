using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.WebApi.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T entity);
        Task<int> Delete(int id);
        Task<int> Update(T entity, int id);
    }
}
