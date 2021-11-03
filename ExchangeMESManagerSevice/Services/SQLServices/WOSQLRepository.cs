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
    public class WOSQLRepository : IRepository<WorkOrderDTO>, IDisposable
    {
        private string _connectionString;

        public WOSQLRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public int Create(WorkOrderDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesWO.CreateWOQuery;
                connection.Open();
                var result = connection.Execute(sql,obj ,commandType: CommandType.Text);
                return result;
            };
        }

        public int Update(WorkOrderDTO obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesWO.UpdateWOQuery;
                connection.Open();
                var result = connection.Execute(sql, obj, commandType: CommandType.Text);
                return result;
            };
        }

        public int Delete(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesWO.DeleteWOQuery;
                connection.Open();
                var result = connection.Execute(sql, new { NId }, commandType: CommandType.Text);
                return result;
            }

        }

        public IEnumerable<WorkOrderDTO> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesWO.GetWOQuery;
                connection.Open();
                var TempDict = new Dictionary<string, WorkOrderDTO>();
                var list = connection.Query<WorkOrderDTO,DMMaterialDTO, WorkOrderOperationDTO, WorkOrderDTO>(sql, (wo, mat,woOp) => {

                    WorkOrderDTO specEntity;
                    if (!TempDict.TryGetValue(wo.NId, out specEntity))
                    {
                        TempDict.Add(wo.NId, specEntity = wo);
                    }

                    if (specEntity.WorkOrderOperations == null)
                    {
                        specEntity.WorkOrderOperations = new List<WorkOrderOperationDTO>();
                    }

                    if (woOp == null)
                    {
                        woOp = new WorkOrderOperationDTO()
                        {
                           OperationNId =""
                        };
                    }

                    if (woOp != null)
                    {
                        if (!specEntity.WorkOrderOperations.Any(x => x.OperationNId == woOp.OperationNId))
                        {
                            specEntity.WorkOrderOperations.Add(woOp);
                        }
                    }


                    if (mat == null)
                    {
                        mat = new DMMaterialDTO()
                        {
                            Material_NId = ""
                        };
                    }
                    specEntity.FinalMaterial = new DMMaterialDTO
                    {
                         Material_NId = mat.Material_NId
                        ,Material_Name = mat.Material_Name
                    };

                    return specEntity;

                }, splitOn: "Material_NId,OperationNId");
                return list;
            };
        }


        public WorkOrderDTO GetByNId(string NId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesWO.GetWOQueryByNId;
                connection.Open();
                var TempDict = new Dictionary<string, WorkOrderDTO>();
                var list = connection.Query<WorkOrderDTO, DMMaterialDTO, WorkOrderOperationDTO, WorkOrderDTO>(sql, (wo, mat, woOp) => {

                    WorkOrderDTO specEntity;
                    if (!TempDict.TryGetValue(wo.NId, out specEntity))
                    {
                        TempDict.Add(wo.NId, specEntity = wo);
                    }

                    if (specEntity.WorkOrderOperations == null)
                    {
                        specEntity.WorkOrderOperations = new List<WorkOrderOperationDTO>();
                    }

                    if (woOp == null)
                    {
                        woOp = new WorkOrderOperationDTO()
                        {
                            OperationNId = ""
                        };
                    }

                    if (woOp != null)
                    {
                        if (!specEntity.WorkOrderOperations.Any(x => x.OperationNId == woOp.OperationNId))
                        {
                            specEntity.WorkOrderOperations.Add(woOp);
                        }
                    }


                    if (mat == null)
                    {
                        mat = new DMMaterialDTO()
                        {
                            Material_NId = ""
                        };
                    }
                    specEntity.FinalMaterial = new DMMaterialDTO
                    {
                        Material_NId = mat.Material_NId
                        ,
                        Material_Name = mat.Material_Name
                    };

                    return specEntity;

                }, new { NId }, splitOn: "Material_NId,OperationNId");
                return list.FirstOrDefault();
            };

        }

        public OperationStructureDependencySQLDTO GetPreviousWOOperationByOrderNo_OpNo(int OpNo,string OrderNo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = SQLQueriesWO.GetPreviousWOOperationByOrderNo_OpNo;
                connection.Open();
                var list = connection.QueryFirst<OperationStructureDependencySQLDTO>(sql, new { OpNo,OrderNo }, commandType: CommandType.Text);
                return list;
            };


        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
