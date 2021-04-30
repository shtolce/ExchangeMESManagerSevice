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
    public class EquipmentGroupConfigurationSQLRepository : IRepository<EquipmentGroupConfigurationDTO>, IDisposable
    {
        private string _connectionString;

        public EquipmentGroupConfigurationSQLRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public int Create(EquipmentGroupConfigurationDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentGroupConfiguration.CreateEquipmentGroupConfigurationQuery;
                connection.Open();
                var result = connection.Execute(sql,obj ,commandType: CommandType.Text);
                return result;
            };
        }

        public int Update(EquipmentGroupConfigurationDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentGroupConfiguration.UpdateEquipmentGroupConfigurationQuery;
                connection.Open();
                var result = connection.Execute(sql, obj, commandType: CommandType.Text);
                return result;
            };
        }

        public int Delete(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentGroupConfiguration.DeleteEquipmentGroupConfigurationQuery;
                connection.Open();
                var result = connection.Execute(sql, new { NId }, commandType: CommandType.Text);
                return result;
            }

        }

        public IEnumerable<EquipmentGroupConfigurationDTO> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentGroupConfiguration.GetEquipmentGroupConfigurationQuery;
                connection.Open();
                var list = connection.Query<EquipmentGroupConfigurationDTO>(sql, commandType: CommandType.Text);
                return list;
            };
        }

        public EquipmentGroupConfigurationDTO GetByNId(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentGroupConfiguration.GetEquipmentGroupConfigurationQueryByNId;
                connection.Open();
                var list = connection.QueryFirst<EquipmentGroupConfigurationDTO>(sql,new {NId}, commandType: CommandType.Text);
                return list;
            };

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
