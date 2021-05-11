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
          [Product] = @Name
          ,[UID] = @UId
          ,[BD] = @Description
           WHERE [PartNo]= @NId

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
          [Product] = @Name
          ,[UID] = @UId
          ,[BD] = @Description
          WHERE [PartNo]= @NId
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
            [FiniteModeBehaviour] = N'Нет'
            ,[InfiniteModeBehaviour] = null
            ,[BD] = @Description
            ,[NameCalendar] =''
            ,[UID] = @AID
            ,[MaxLoad] = 0
            WHERE [Name] = @Name
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
            [FiniteModeBehaviour] = N'Нет'
            ,[InfiniteModeBehaviour] = null
            ,[BD] = @Description
            ,[NameCalendar] =''
            ,[UID] = @AID
            ,[MaxLoad] = 0
            WHERE [Name] = @Name
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
    public static class SQLQueriesEquipmentGroupConfiguration
    {

        #region GetEquipmentGroupConfigurationQuery
        public static string GetEquipmentGroupConfigurationQuery = $@"
            SELECT 
	               [Name] as NId
	              ,[Name] as Name
                  ,[Resource] as EquipmentConfigurationNId
                  ,[BD] as Description
                  ,[UID] as AId
              FROM [RealData].[ResourceGroupData]
        ";
        #endregion

        #region GetEquipmentGroupConfigurationQueryByNId
        public static string GetEquipmentGroupConfigurationQueryByNId = $@"Select       
        SELECT 
	            [Name] as NId
	            ,[Name] as Name
                ,[Resource] as EquipmentConfigurationNId
                ,[BD] as Description
                ,[UID] as AId
            FROM [RealData].[ResourceGroupData]
          Where NId = @NId";
        #endregion

        #region CreateEquipmentGroupConfigurationQuery
        public static string CreateEquipmentGroupConfigurationQuery = $@"
          IF NOT EXISTS(select 1 from RealData.Connect_ResourceGroup where ResourceGroup = @Name)
          BEGIN
               insert into [RealData].[Connect_ResourceGroup] (
               [ResourceGroup]
              ,[UID]
              ,[BD]
	          )
	          Values
	          (
 	             @Name
                ,@AId
	            ,@Description
	          )
         END;

          IF NOT EXISTS(select 1 from [RealData].[ResourceData] where Name = @EquipmentConfigurationNId)
          BEGIN
               insert into [RealData].[ResourceData] (
               [Name]
              ,[UID]
              ,[BD]
              ,[NameCalendar]
	          )
	          Values
	          (
 	             @EquipmentConfigurationNId
                ,@EquipmentConfigurationAId
	            ,@Description
 	            ,@EquipmentConfigurationNId
	          )
         END;


        insert into [RealData].[ResourceGroupData] (
        [Name]
        ,[Resource]
        ,[BD]
        ,[NameCalendar]
        ,[UID]
	    )
	    Values
	    (
	    @Name
	    ,@EquipmentConfigurationNId
	    ,@Description
	    ,@EquipmentConfigurationName
        ,@AId
	    )
        ";
        #endregion

        #region UpdateEquipmentGroupConfigurationQuery
        public static string UpdateEquipmentGroupConfigurationQuery = $@"
          IF NOT EXISTS(select 1 from RealData.Connect_ResourceGroup where ResourceGroup = @Name)
          BEGIN
               insert into [RealData].[Connect_ResourceGroup] (
               [ResourceGroup]
              ,[UID]
              ,[BD]
	          )
	          Values
	          (
 	             @Name
                ,@AId
	            ,@Description
	          )
         END;

          IF NOT EXISTS(select 1 from [RealData].[ResourceData] where Name = @EquipmentConfigurationNId)
          BEGIN
               insert into [RealData].[ResourceData] (
               [Name]
              ,[UID]
              ,[BD]
              ,[NameCalendar]
	          )
	          Values
	          (
 	             @EquipmentConfigurationNId
                ,@EquipmentConfigurationAId
	            ,@Description
 	            ,@EquipmentConfigurationNId
	          )
         END;

        Update [RealData].[ResourceGroupData] 
            SET
            [BD] = @Description
            ,[NameCalendar] =@EquipmentConfigurationName
            ,[UID] = @AID
        WHERE Name = @Name and [Resource] = @EquipmentConfigurationNId
       ";
        #endregion

        #region DeleteEquipmentGroupConfigurationQuery
        public static string DeleteEquipmentGroupConfigurationQuery = $@"
        Delete from [RealData].[ResourceGroupData]
	       where
		   [Name]= @NId
        ";
        #endregion

    }
    public static class SQLQueriesBuffer
    {

        #region GetBufferQuery
        public static string GetBufferQuery = $@"
          SELECT 
	           [Name] as Name
	          ,[Name] as NId
	          ,[Name] as EquipmentNId
	          ,[Name] as EquipmentName
              ,[BD] as Description
              ,[UID] as AID
	          ,GetDate() as CreatedOn
	          ,GetDate() as LastUpdatedOn
	          ,N'Siemens.SimaticIT.MasterData.EQU_MS.MSModel.DataModel.Buffer' as EntityType
          FROM [RealData].[ResourceData]       ";
        #endregion

        #region GetBufferQueryByNId
        public static string GetBufferQueryByNId = $@"Select       
          SELECT 
	           [Name] as Name
	          ,[Name] as NId
	          ,[Name] as EquipmentNId
	          ,[Name] as EquipmentName
              ,[BD] as Description
              ,[UID] as AID
	          ,GetDate() as CreatedOn
	          ,GetDate() as LastUpdatedOn
	          ,N'Siemens.SimaticIT.MasterData.EQU_MS.MSModel.DataModel.Buffer' as EntityType
          FROM [RealData].[ResourceData]
          Where NId = @NId";
        #endregion

        #region CreateBufferQuery
        public static string CreateBufferQuery = $@"
          insert into [RealData].[ResourceData] (
           [Name]
          ,[BD]
          ,[NameCalendar]
          ,[UID]
          ,[MaxLoad]
	      )
	      Values
	      (
  	         @Name
	        ,@Description
	        ,@Name
            ,@AID
	        ,0
	      )
         ";
        #endregion

        #region UpdateBufferQuery
        public static string UpdateBufferQuery = $@"
            Update [RealData].[ResourceData] 
            SET
             [BD] = @Description
            ,[NameCalendar] =@Name
            ,[UID] = @AID
            ,[MaxLoad] = 0
            WHERE [Name] = @Name
       ";
        #endregion

        #region DeleteBufferQuery
        public static string DeleteBufferQuery = $@"
        Delete from [RealData].[ResourceData]
	       where
		   [Name]= @NId
        ";
        #endregion

    }



}
