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
    public class MateriaSQLRepository : IRepository<MaterialDTO>, IDisposable
    {
        private string _connectionString;

        public MateriaSQLRepository()
        {
            _connectionString = @"Data Source=DMKIM\MSSQLSERVER1;Integrated Security=True;Initial Catalog=PBD_Preactor;";

        }

        public int Create(MaterialDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueries.CreateMaterialQuery;
                connection.Open();
                var result = connection.Execute(sql,obj ,commandType: CommandType.Text);
                return result;
            };
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MaterialDTO> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueries.GetMaterialQuery;
                connection.Open();
                var list = connection.Query<MaterialDTO>(sql, commandType: CommandType.Text);
                return list;
            };
        }

        public MaterialDTO GetByNId(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueries.GetMaterialQueryByNId;
                connection.Open();
                var list = connection.QueryFirst<MaterialDTO>(sql,new {NId}, commandType: CommandType.Text);
                return list;
            };

        }

        public void Update(MaterialDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
