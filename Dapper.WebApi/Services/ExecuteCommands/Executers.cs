using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace Dapper.WebApi.Services.ExecuteCommands
{
    public class Executers: IExecuters
    { 
        public async Task ExecuteCommand(string connStr, Action<SqlConnection> task)
        {
            using (var conn = new SqlConnection(connStr))
            {
                await conn.OpenAsync();
                task(conn);
            }
        }
        public async Task<T> ExecuteCommand<T>(string connStr, Func<SqlConnection, Task<T>> task)
        {
            using (var conn = new SqlConnection(connStr))
            {
                await conn.OpenAsync();
                return await task(conn);
            }
        }
    }
}
