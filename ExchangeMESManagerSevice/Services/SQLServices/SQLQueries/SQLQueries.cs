using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeMESManagerSevice.Services.SQLServices
{
    public static class SQLQueries
    {
        #region GetMaterialQuery
        public static string GetMaterialQuery = $@"Select       
        [PartNo] as NId
       ,[Product] as Name
       ,[UID] as UId
       ,[Area]
       ,[BD] as Description
	   ,N'n/a' as UoMNId
	   ,N'Default' as TemplateNId
	   ,N'Siemens.SimaticIT.MasterData.MAT_MS.MSModel.DataModel.Material' as EntityType
	   ,[PartNo] as UId
	   FROM [PBD_Preactor].[RealData].[ItemData]";
        #endregion

        #region GetMaterialQueryByNId
        public static string GetMaterialQueryByNId = $@"Select       
        [PartNo] as NId
       ,[Product] as Name
       ,[UID] as UId
       ,[Area]
       ,[BD] as Description
	   ,N'n/a' as UoMNId
	   ,N'Default' as TemplateNId
	   ,N'Siemens.SimaticIT.MasterData.MAT_MS.MSModel.DataModel.Material' as EntityType
	   ,[PartNo] as UId
	   FROM [PBD_Preactor].[RealData].[ItemData]
       Where PartNo = @NId";
       #endregion

      #region CreateMaterialQuery
       public static string CreateMaterialQuery = $@"
       Insert into [RealData].[ItemData]
       (
	       [PartNo]
          ,[Product]
          ,[UID]
          ,[BD]
	   )
	   Values
       (
            @NId
          , @Name
          , @UId
          , @Description
       )";
       #endregion








    }
}
