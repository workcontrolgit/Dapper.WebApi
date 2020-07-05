using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace Dapper.WebApi.Services.ExecuteCommands
{
    public interface IExecuters
    {
        Task ExecuteCommand(string connStr, Action<SqlConnection> task);
        //T ExecuteCommand<T>(string connStr, Func<SqlConnection, T> task);
        Task<T> ExecuteCommand<T>(string connStr, Func<SqlConnection, Task<T>> task);

    }
}
