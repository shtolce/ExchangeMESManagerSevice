using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeMESManagerSevice.Services.SQLServices
{
    public static class SQLQueriesMaterial
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
	   FROM [RealData].[ItemData]";
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
	   FROM [RealData].[ItemData]
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
 
       #region UpdateMaterialQuery
       public static string UpdateMaterialQuery = $@"
       Update [RealData].[ItemData]
	       set
		   [PartNo]= @NId
          ,[Product] = @Name
          ,[UID] = @UId
          ,[BD] = @Description
       ";
        #endregion

        #region DeleteMaterialQuery
        public static string DeleteMaterialQuery = $@"
        Delete from [RealData].[ItemData]
	       where
		   [PartNo]= @NId
        ";
        #endregion












    }
    public static class SQLQueriesDM_Material
    {
        #region GetDMMaterialQuery
        public static string GetDMMaterialQuery = $@"Select       
        [PartNo] as NId
       ,[Product] as Name
       ,[UID] as UId
       ,[Area]
       ,[BD] as Description
	   ,N'n/a' as UoMNId
	   ,N'Default' as TemplateNId
	   ,N'Siemens.SimaticIT.MasterData.MAT_MS.MSModel.DataModel.DM_Material' as EntityType
	   ,[PartNo] as UId
	   FROM [RealData].[ItemData]";
        #endregion

        #region GetDMMaterialQueryByNId
        public static string GetDMMaterialQueryByNId = $@"Select       
        [PartNo] as NId
       ,[Product] as Name
       ,[UID] as UId
       ,[Area]
       ,[BD] as Description
	   ,N'n/a' as UoMNId
	   ,N'Default' as TemplateNId
	   ,N'Siemens.SimaticIT.MasterData.MAT_MS.MSModel.DataModel.DM_Material' as EntityType
	   ,[PartNo] as UId
	   FROM [RealData].[ItemData]
       Where PartNo = @NId";
        #endregion

        #region CreateDMMaterialQuery
        public static string CreateDMMaterialQuery = $@"
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

        #region UpdateDMMaterialQuery
        public static string UpdateDMMaterialQuery = $@"
       Update [RealData].[ItemData]
	       set
		   [PartNo]= @NId
          ,[Product] = @Name
          ,[UID] = @UId
          ,[BD] = @Description
       ";
        #endregion

        #region DeleteDMMaterialQuery
        public static string DeleteDMMaterialQuery = $@"
        Delete from [RealData].[ItemData]
	       where
		   [PartNo]= @NId
        ";
        #endregion












    }
    public static class SQLQueriesEquipmentConfiguration
    {
        #region GetEquipmentConfigurationQuery
        public static string GetEquipmentConfigurationQuery = $@"
          SELECT 
	           [Name] as Name
	          ,[Name] as NId
	          ,N'u' as UoMNId
	          ,N'ProductionUnit' as LevelNId
              ,[BD] as Description
              ,[UID] as AID
	          ,GetDate() as CreatedOn
	          ,GetDate() as LastUpdatedOn
	          ,N'Siemens.SimaticIT.MasterData.EQU_MS.MSModel.DataModel.EquipmentConfiguration' as EntityType
              ,N'Unit' asEquipmentTypeNId
          FROM [RealData].[ResourceData]       ";
        #endregion

        #region GetEquipmentConfigurationQueryByNId
        public static string GetEquipmentConfigurationQueryByNId = $@"Select       
          SELECT 
	           [Name] as Name
	          ,[Name] as NId
	          ,N'u' as UoMNId
	          ,N'ProductionUnit' as LevelNId
              ,[BD] as Description
              ,[UID] as AID
	          ,GetDate() as CreatedOn
	          ,GetDate() as LastUpdatedOn
	          ,N'Siemens.SimaticIT.MasterData.EQU_MS.MSModel.DataModel.EquipmentConfiguration' as EntityType
              ,N'Unit' asEquipmentTypeNId
          FROM [RealData].[ResourceData]
          Where NId = @NId";
        #endregion

        #region CreateEquipmentConfigurationQuery
        public static string CreateEquipmentConfigurationQuery = $@"
          insert into [RealData].[ResourceData] (
           [Name]
          ,[FiniteModeBehaviour]
          ,[InfiniteModeBehaviour]
          ,[BD]
          ,[NameCalendar]
          ,[UID]
          ,[MaxLoad]
	      )
	      Values
	      (
	        @Name
	        ,N'Нет'
            ,null
	        ,@Description
	        ,''
            ,@AID
	        ,0
	      )
         ";
        #endregion

        #region UpdateEquipmentConfigurationQuery
        public static string UpdateEquipmentConfigurationQuery = $@"
            Update [RealData].[ResourceData] 
            SET
            [Name] = @Name
            ,[FiniteModeBehaviour] = N'Нет'
            ,[InfiniteModeBehaviour] = null
            ,[BD] = @Description
            ,[NameCalendar] =''
            ,[UID] = @AID
            ,[MaxLoad] = 0
       ";
        #endregion

        #region DeleteEquipmentConfigurationQuery
        public static string DeleteEquipmentConfigurationQuery = $@"
        Delete from [RealData].[ResourceData]
	       where
		   [Name]= @NId
        ";
        #endregion












    }
    public static class SQLQueriesEquipment
    {

        #region GetEquipmentQuery
        public static string GetEquipmentQuery = $@"
          SELECT 
	           [Name] as Name
	          ,[Name] as NId
	          ,N'u' as UoMNId
	          ,N'ProductionUnit' as LevelNId
              ,[BD] as Description
              ,[UID] as AID
	          ,GetDate() as CreatedOn
	          ,GetDate() as LastUpdatedOn
	          ,N'Siemens.SimaticIT.MasterData.EQU_MS.MSModel.DataModel.Equipment' as EntityType
          FROM [RealData].[ResourceData]       ";
        #endregion

        #region GetEquipmentQueryByNId
        public static string GetEquipmentQueryByNId = $@"Select       
          SELECT 
	           [Name] as Name
	          ,[Name] as NId
	          ,N'u' as UoMNId
	          ,N'ProductionUnit' as LevelNId
              ,[BD] as Description
              ,[UID] as AID
	          ,GetDate() as CreatedOn
	          ,GetDate() as LastUpdatedOn
	          ,N'Siemens.SimaticIT.MasterData.EQU_MS.MSModel.DataModel.Equipment' as EntityType
          FROM [RealData].[ResourceData]
          Where NId = @NId";
        #endregion

        #region CreateEquipmentQuery
        public static string CreateEquipmentQuery = $@"
          insert into [RealData].[ResourceData] (
           [Name]
          ,[FiniteModeBehaviour]
          ,[InfiniteModeBehaviour]
          ,[BD]
          ,[NameCalendar]
          ,[UID]
          ,[MaxLoad]
	      )
	      Values
	      (
	        @Name
	        ,N'Нет'
            ,null
	        ,@Description
	        ,''
            ,@AID
	        ,0
	      )
         ";
        #endregion

        #region UpdateEquipmentQuery
        public static string UpdateEquipmentQuery = $@"
            Update [RealData].[ResourceData] 
            SET
            [Name] = @Name
            ,[FiniteModeBehaviour] = N'Нет'
            ,[InfiniteModeBehaviour] = null
            ,[BD] = @Description
            ,[NameCalendar] =''
            ,[UID] = @AID
            ,[MaxLoad] = 0
       ";
        #endregion

        #region DeleteEquipmentQuery
        public static string DeleteEquipmentQuery = $@"
        Delete from [RealData].[ResourceData]
	       where
		   [Name]= @NId
        ";
        #endregion

    }



}
