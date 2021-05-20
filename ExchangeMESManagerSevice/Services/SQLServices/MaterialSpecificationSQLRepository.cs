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
    public class MaterialSpecificationSQLRepository : IRepository<MaterialSpecificationDTO>, IDisposable
    {
        private string _connectionString;

        public MaterialSpecificationSQLRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public int Create(MaterialSpecificationDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesMaterialSpecification.CreateMaterialSpecificationQuery;
                connection.Open();
                var result = connection.Execute(sql,obj ,commandType: CommandType.Text);
                return result;
            };
        }

        public int Update(MaterialSpecificationDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesMaterialSpecification.UpdateMaterialSpecificationQuery;
                connection.Open();
                var result = connection.Execute(sql, obj, commandType: CommandType.Text);
                return result;
            };
        }

        public int Delete(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesMaterialSpecification.DeleteMaterialSpecificationQuery;
                connection.Open();
                var result = connection.Execute(sql, new { NId }, commandType: CommandType.Text);
                return result;
            }

        }

        public int Delete(MaterialSpecificationDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesMaterialSpecification.DeleteMaterialSpecificationQuery;
                connection.Open();
                var result = connection.Execute(sql, obj, commandType: CommandType.Text);
                return result;
            }

        }


        public IEnumerable<MaterialSpecificationDTO> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesMaterialSpecification.GetMaterialSpecificationQuery;
                connection.Open();
                var list = connection.Query<MaterialSpecificationDTO>(sql, commandType: CommandType.Text);
                return list;
            };
        }

        public MaterialSpecificationDTO GetByNId(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesMaterialSpecification.GetMaterialSpecificationQueryByNId;
                connection.Open();
                var list = connection.QueryFirst<MaterialSpecificationDTO>(sql,new {NId}, commandType: CommandType.Text);
                return list;
            };

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
