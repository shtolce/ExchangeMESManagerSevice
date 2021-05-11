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
        private List<EquipmentGroupConfigurationDTO> ExpandRecords(EquipmentGroupConfigurationDTO obj)
        {
            List<EquipmentGroupConfigurationDTO> resList = new List<EquipmentGroupConfigurationDTO>();
            foreach (EquipmentConfigurationDTO item in obj.EquipmentConfigurations)
            {
                var tempObj = obj.Clone() as EquipmentGroupConfigurationDTO;
                tempObj.EquipmentConfigurationNId = item.NId;
                tempObj.EquipmentConfigurationName = item.Name;
                tempObj.EquipmentConfigurationAId = item.AId;
                resList.Add(tempObj);
            }
            return resList;
        }




        public int Create(EquipmentGroupConfigurationDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                var sql = SQLQueriesEquipmentGroupConfiguration.CreateEquipmentGroupConfigurationQuery;
                connection.Open();
                var list = ExpandRecords(obj);
                foreach (var item in list)
                {
                    try
                    {
                        var result = connection.Execute(sql, item, commandType: CommandType.Text);
                    }
                    catch(Exception ex)
                    {
                        return 0;
                    }
                }
                return 1;
            };
        }

        public int Update(EquipmentGroupConfigurationDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesEquipmentGroupConfiguration.UpdateEquipmentGroupConfigurationQuery;
                connection.Open();
                var list = ExpandRecords(obj);
                foreach (var item in list)
                {
                    try
                    {
                        var result = connection.Execute(sql, item, commandType: CommandType.Text);
                    }
                    catch (Exception ex)
                    {
                        return 0;
                    }
                }
                return 1;
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
