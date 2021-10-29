using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            DMMaterialDTO.DapperMapping();
            MaterialDTO.DapperMapping();
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesDM_Material.GetDMMaterialQuery;
                connection.Open();
                var list = connection.Query<DMMaterialDTO, MaterialDTO, DMMaterialDTO>(sql, (dmMat, mat) => {
                    if (mat == null)
                    {
                        mat = new MaterialDTO()
                        {
                            NId = ""
                        };
                    }
                    dmMat.Material = new MaterialDTO
                    {
                        NId = mat.NId
                        ,Name = mat.Name
                        ,UId = mat.UId
                        ,Description = mat.Description
                        ,UoMNId = mat.UoMNId
                        ,TemplateNId = mat.TemplateNId
                        ,EntityType = mat.EntityType
                    };
                    return dmMat;

                },splitOn: "MaterialNId");
                DMMaterialDTO.DapperUnMapping();
                MaterialDTO.DapperUnMapping();

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
