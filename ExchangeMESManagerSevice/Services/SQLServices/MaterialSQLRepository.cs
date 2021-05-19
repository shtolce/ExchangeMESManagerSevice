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
    public class MaterialSQLRepository : IRepository<MaterialDTO>, IDisposable
    {
        private string _connectionString;

        public MaterialSQLRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public int Create(MaterialDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesMaterial.CreateMaterialQuery;
                connection.Open();
                var result = connection.Execute(sql,obj ,commandType: CommandType.Text);
                return result;
            };
        }

        public int Update(MaterialDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesMaterial.UpdateMaterialQuery;
                connection.Open();
                var result = connection.Execute(sql, obj, commandType: CommandType.Text);
                return result;
            };
        }

        public int Delete(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesMaterial.DeleteMaterialQuery;
                connection.Open();
                var result = connection.Execute(sql, new { NId }, commandType: CommandType.Text);
                return result;
            }

        }

        public IEnumerable<MaterialDTO> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesMaterial.GetMaterialQuery;
                connection.Open();
                var list = connection.Query<MaterialDTO>(sql, commandType: CommandType.Text);
                return list;
            };
        }

        public MaterialDTO GetByNId(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesMaterial.GetMaterialQueryByNId;
                connection.Open();
                var list = connection.QueryFirst<MaterialDTO>(sql,new {NId}, commandType: CommandType.Text);
                return list;
            };

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
