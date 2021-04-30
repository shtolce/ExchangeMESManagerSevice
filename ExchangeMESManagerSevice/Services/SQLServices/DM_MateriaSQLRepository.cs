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
    public class DM_MateriaSQLRepository : IRepository<DMMaterialDTO>, IDisposable
    {
        private string _connectionString;

        public DM_MateriaSQLRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public int Create(DMMaterialDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesDM_Material.CreateDMMaterialQuery;
                connection.Open();
                var result = connection.Execute(sql,obj ,commandType: CommandType.Text);
                return result;
            };
        }

        public int Update(DMMaterialDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesDM_Material.UpdateDMMaterialQuery;
                connection.Open();
                var result = connection.Execute(sql, obj, commandType: CommandType.Text);
                return result;
            };
        }

        public int Delete(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesDM_Material.DeleteDMMaterialQuery;
                connection.Open();
                var result = connection.Execute(sql, new { NId }, commandType: CommandType.Text);
                return result;
            }

        }

        public IEnumerable<DMMaterialDTO> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesDM_Material.GetDMMaterialQuery;
                connection.Open();
                var list = connection.Query<DMMaterialDTO>(sql, commandType: CommandType.Text);
                return list;
            };
        }

        public DMMaterialDTO GetByNId(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesDM_Material.GetDMMaterialQueryByNId;
                connection.Open();
                var list = connection.QueryFirst<DMMaterialDTO>(sql,new {NId}, commandType: CommandType.Text);
                return list;
            };

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
