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
    public class AsPlannedBOPSQLRepository : IRepository<AsPlannedBOPDTO>, IDisposable
    {
        private string _connectionString;

        public AsPlannedBOPSQLRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public int Create(AsPlannedBOPDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesAsPlannedBOP.CreateAsPlannedBOPQuery;
                connection.Open();
                var result = connection.Execute(sql,obj ,commandType: CommandType.Text);
                return result;
            };
        }

        public int Update(AsPlannedBOPDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesAsPlannedBOP.UpdateAsPlannedBOPQuery;
                connection.Open();
                var result = connection.Execute(sql, obj, commandType: CommandType.Text);
                return result;
            };
        }

        public int Delete(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesAsPlannedBOP.DeleteAsPlannedBOPQuery;
                connection.Open();
                var result = connection.Execute(sql, new { NId }, commandType: CommandType.Text);
                return result;
            }

        }

        public IEnumerable<AsPlannedBOPDTO> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesAsPlannedBOP.GetAsPlannedBOPQuery;
                connection.Open();
                var list = connection.Query<AsPlannedBOPDTO>(sql, commandType: CommandType.Text);
                return list;
            };
        }

        public AsPlannedBOPDTO GetByNId(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesAsPlannedBOP.GetAsPlannedBOPQueryByNId;
                connection.Open();
                var list = connection.QueryFirst<AsPlannedBOPDTO>(sql,new {NId}, commandType: CommandType.Text);
                return list;
            };

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
