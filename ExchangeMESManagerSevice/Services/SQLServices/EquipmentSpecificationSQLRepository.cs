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

    public class EquipmentSpecificationSQLRepository : IRepository<EquipmentSpecificationDTO>, IDisposable
    {
        private string _connectionString;

        public EquipmentSpecificationSQLRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public int Create(EquipmentSpecificationDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentSpecification.CreateEquipmentSpecificationQuery;
                connection.Open();
                var result = connection.Execute(sql,obj ,commandType: CommandType.Text);
                return result;
            };
        }

        public int Update(EquipmentSpecificationDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentSpecification.UpdateEquipmentSpecificationQuery;
                connection.Open();
                var result = connection.Execute(sql, obj, commandType: CommandType.Text);
                return result;
            };
        }

        public int Delete(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentSpecification.DeleteEquipmentSpecificationQuery;
                connection.Open();
                var result = connection.Execute(sql, new { NId }, commandType: CommandType.Text);
                return result;
            }

        }

        public IEnumerable<EquipmentSpecificationDTO> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentSpecification.GetEquipmentSpecificationQuery;
                connection.Open();
                var list = connection.Query<EquipmentSpecificationDTO>(sql, commandType: CommandType.Text);
                return list;
            };
        }

        public EquipmentSpecificationDTO GetByNId(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentSpecification.GetEquipmentSpecificationQueryByNId;
                connection.Open();
                var list = connection.QueryFirst<EquipmentSpecificationDTO>(sql,new {NId}, commandType: CommandType.Text);
                return list;
            };

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
