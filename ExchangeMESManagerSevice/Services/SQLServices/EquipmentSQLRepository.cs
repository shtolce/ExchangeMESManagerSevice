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
    public class EquipmentSQLRepository : IRepository<EquipmentDTO>, IDisposable
    {
        private string _connectionString;

        public EquipmentSQLRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public int Create(EquipmentDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipment.CreateEquipmentQuery;
                connection.Open();
                var result = connection.Execute(sql,obj ,commandType: CommandType.Text);
                return result;
            };
        }

        public int Update(EquipmentDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipment.UpdateEquipmentQuery;
                connection.Open();
                var result = connection.Execute(sql, obj, commandType: CommandType.Text);
                return result;
            };
        }

        public int Delete(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipment.DeleteEquipmentQuery;
                connection.Open();
                var result = connection.Execute(sql, new { NId }, commandType: CommandType.Text);
                return result;
            }

        }

        public IEnumerable<EquipmentDTO> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipment.GetEquipmentQuery;
                connection.Open();
                var list = connection.Query<EquipmentDTO>(sql, commandType: CommandType.Text);
                return list;
            };
        }

        public EquipmentDTO GetByNId(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipment.GetEquipmentQueryByNId;
                connection.Open();
                var list = connection.QueryFirst<EquipmentDTO>(sql,new {NId}, commandType: CommandType.Text);
                return list;
            };

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
