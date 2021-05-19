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
    public class ProcessesSQLRepository : IRepository<ProcessesDTO>, IDisposable
    {
        private string _connectionString;

        public ProcessesSQLRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public int Create(ProcessesDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesProcesses.CreateProcessesQuery;
                connection.Open();
                var result = connection.Execute(sql,obj ,commandType: CommandType.Text);
                return result;
            };
        }

        public int Update(ProcessesDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesProcesses.UpdateProcessesQuery;
                connection.Open();
                var result = connection.Execute(sql, obj, commandType: CommandType.Text);
                return result;
            };
        }

        public int Delete(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesProcesses.DeleteProcessesQuery;
                connection.Open();
                var result = connection.Execute(sql, new { NId }, commandType: CommandType.Text);
                return result;
            }

        }

        public IEnumerable<ProcessesDTO> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesProcesses.GetProcessesQuery;
                connection.Open();
                var list = connection.Query<ProcessesDTO>(sql);
                foreach(var item in list)
                {
                    item.Quantity = new QuantityType { UoMNId = "u", QuantityValue = 1 };
                    item.FinalMaterialId = new DMMaterialDTO
                    {
                        Material = new MaterialDTO
                        {
                            Name = item.FinalMaterialName
                            ,NId = item.NId
                        }
                    };
                }
                return list;
            };
        }

        public ProcessesDTO GetByNId(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesProcesses.GetProcessesQueryByNId;
                connection.Open();
                var item = connection.QueryFirst<ProcessesDTO>(sql,new {NId}, commandType: CommandType.Text);

                item.Quantity = new QuantityType { UoMNId = "u", QuantityValue = 1 };
                item.FinalMaterialId = new DMMaterialDTO
                {
                    Material = new MaterialDTO
                    {
                        Name = item.FinalMaterialName
                        ,
                        NId = item.NId
                    }
                };
                return item;
            };

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
