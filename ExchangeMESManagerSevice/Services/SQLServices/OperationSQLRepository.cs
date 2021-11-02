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
    public class OperationSQLRepository : IRepository<OperationDTO>, IDisposable
    {
        private string _connectionString;

        public OperationSQLRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public int Create(OperationDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesOperation.CreateOperationQuery;
                connection.Open();
                var result = connection.Execute(sql,obj ,commandType: CommandType.Text);
                return result;
            };
        }

        public int Update(OperationDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesOperation.UpdateOperationQuery;
                connection.Open();
                var result = connection.Execute(sql, obj, commandType: CommandType.Text);
                return result;
            };
        }

        public int Delete(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesOperation.DeleteOperationQuery;
                connection.Open();
                var result = connection.Execute(sql, new { NId }, commandType: CommandType.Text);
                return result;
            }

        }

        public IEnumerable<OperationDTO> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesOperation.GetOperationQuery;
                connection.Open();
                var list = connection.Query<OperationDTO>(sql, commandType: CommandType.Text);
                return list;
            };
        }


        public OperationStructureDependencySQLDTO GetPreviousOperationByPartNo_OpNo(string PartNo,int OpNo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesOperation.GetPreviousOperationByPartNo_OpNo;
                connection.Open();
                var list = connection.QueryFirst<OperationStructureDependencySQLDTO>(sql, new { PartNo, OpNo }, commandType: CommandType.Text);
                return list;
            };


        }

        public OperationDTO GetByNId(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesOperation.GetOperationQueryByNId;
                connection.Open();
                var list = connection.QueryFirst<OperationDTO>(sql,new {NId}, commandType: CommandType.Text);
                return list;
            };

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
