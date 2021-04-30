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
    public class EquipmentConfigurationSQLRepository : IRepository<EquipmentConfigurationDTO>, IDisposable
    {
        private string _connectionString;

        public EquipmentConfigurationSQLRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public int Create(EquipmentConfigurationDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentConfiguration.CreateEquipmentConfigurationQuery;
                connection.Open();
                var result = connection.Execute(sql,obj ,commandType: CommandType.Text);
                return result;
            };
        }

        public int Update(EquipmentConfigurationDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentConfiguration.UpdateEquipmentConfigurationQuery;
                connection.Open();
                var result = connection.Execute(sql, obj, commandType: CommandType.Text);
                return result;
            };
        }

        public int Delete(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentConfiguration.DeleteEquipmentConfigurationQuery;
                connection.Open();
                var result = connection.Execute(sql, new { NId }, commandType: CommandType.Text);
                return result;
            }

        }

        public IEnumerable<EquipmentConfigurationDTO> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentConfiguration.GetEquipmentConfigurationQuery;
                connection.Open();
                var list = connection.Query<EquipmentConfigurationDTO>(sql, commandType: CommandType.Text);
                return list;
            };
        }

        public EquipmentConfigurationDTO GetByNId(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentConfiguration.GetEquipmentConfigurationQueryByNId;
                connection.Open();
                var list = connection.QueryFirst<EquipmentConfigurationDTO>(sql,new {NId}, commandType: CommandType.Text);
                return list;
            };

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
