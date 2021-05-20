using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ExchangeMESManagerSevice.Models.DTOModels;
namespace ExchangeMESManagerSevice.Services.SQLServices
{
    public class ProcessToOperationLinkSQLRepository : IRepository<ProcessToOperationLinkDTO>, IDisposable
    {
        private string _connectionString;

        public ProcessToOperationLinkSQLRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public int Create(ProcessToOperationLinkDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesProcessToOperationLink.CreateProcessToOperationLinkQuery;
                connection.Open();
                var result = connection.Execute(sql,obj ,commandType: CommandType.Text);
                return result;
            };
        }

        public int Update(ProcessToOperationLinkDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesProcessToOperationLink.UpdateProcessToOperationLinkQuery;
                connection.Open();
                var result = connection.Execute(sql, obj, commandType: CommandType.Text);
                return result;
            };
        }

        public int Delete(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesProcessToOperationLink.DeleteProcessToOperationLinkQuery;
                connection.Open();
                var result = connection.Execute(sql, new { NId }, commandType: CommandType.Text);
                return result;
            }

        }

        public IEnumerable<ProcessToOperationLinkDTO> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesProcessToOperationLink.GetProcessToOperationLinkQuery;
                connection.Open();
                var list = connection.Query<ProcessToOperationLinkDTO>(sql);

                foreach (var item in list)
                {
                    item.ChildOperation = new OperationDTO
                    {
                        NId = item.ChildOperation_NId
                        ,Name = item.ChildOperation_NId
                        ,Description = item.CorrelationId
                    };
                }

                return list;
            };
        }

        public ProcessToOperationLinkDTO GetByNId(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesProcessToOperationLink.GetProcessToOperationLinkQueryByNId;
                connection.Open();
                var item = connection.QueryFirst<ProcessToOperationLinkDTO>(sql,new {NId}, commandType: CommandType.Text);
                item.ChildOperation = new OperationDTO
                {
                    NId = item.ChildOperation_NId
                    ,Name = item.ChildOperation_NId
                    ,Description = item.CorrelationId
                };

                return item;
            };

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
