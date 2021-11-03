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
	   ,[PartNo] as TemplateNId
	   ,N'Siemens.SimaticIT.MasterData.MAT_MS.MSModel.DataModel.Material' as EntityType
	   ,[PartNo] as UId
       ,'A' as Revision
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
	   ,[PartNo] as TemplateNId
	   ,N'Siemens.SimaticIT.MasterData.MAT_MS.MSModel.DataModel.Material' as EntityType
	   ,[PartNo] as UId
       ,'A' as Revision

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
            ROW_NUMBER() over (Order by Partno) as DMMaterial_Id
           ,[PartNo] as MaterialNId
           ,[Product] as MaterialName
           ,[UID] as MaterialId
           ,[Area]
           ,[BD] as Description
	       ,N'n/a' as MaterialUoMNId
	       ,N'Default' as MaterialTemplateNId
	       ,N'Siemens.SimaticIT.MasterData.MAT_MS.MSModel.DataModel.DM_Material' as EntityType
	       ,[PartNo] as MaterialUId
	   FROM [RealData].[ItemData]";
        #endregion

        #region GetDMMaterialQueryByNId
        public static string GetDMMaterialQueryByNId = $@"Select       
           ROW_NUMBER() over (Order by Partno) as DMMaterial_Id
           ,[PartNo] as NId
           ,[Product] as Name
           ,[UID] as UId
           ,[Area]
           ,[BD] as Description
	       ,N'n/a' as MaterialUoMNId
	       ,N'Default' as MaterialTemplateNId
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
    
    public static class SQLQueriesAsPlannedBOP
    {
        #region GetAsPlannedBOPQuery не сделан просто скопирован шаблон
        public static string GetAsPlannedBOPQuery = $@"Select       
        [PartNo] as NId
       ,[Product] as Name
       ,[UID] as UId
       ,[Area]
       ,[BD] as Description
	   ,N'n/a' as UoMNId
	   ,N'Default' as TemplateNId
	   ,N'Siemens.SimaticIT.MasterData.MAT_MS.MSModel.DataModel.AsPlannedBOP' as EntityType
	   ,[PartNo] as UId
	   FROM [RealData].[ItemData]";
        #endregion

        #region GetAsPlannedBOPQueryByNId
        public static string GetAsPlannedBOPQueryByNId = $@"Select       
        [PartNo] as NId
       ,[Product] as Name
       ,[UID] as UId
       ,[Area]
       ,[BD] as Description
	   ,N'n/a' as UoMNId
	   ,N'Default' as TemplateNId
	   ,N'Siemens.SimaticIT.MasterData.MAT_MS.MSModel.DataModel.AsPlannedBOP' as EntityType
	   ,[PartNo] as UId
	   FROM [RealData].[ItemData]
       Where PartNo = @NId";
        #endregion

        #region CreateAsPlannedBOPQuery
        public static string CreateAsPlannedBOPQuery = $@"
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

        #region UpdateAsPlannedBOPQuery
        public static string UpdateAsPlannedBOPQuery = $@"
       Update [RealData].[ItemData]
	       set
          [Product] = @Name
          ,[UID] = @UId
          ,[BD] = @Description
           WHERE [PartNo]= @NId

       ";
        #endregion

        #region DeleteAsPlannedBOPQuery
        public static string DeleteAsPlannedBOPQuery = $@"
        Delete from [RealData].[ItemData]
	       where
		   [PartNo]= @NId
        ";
        #endregion


    }
    
    public static class SQLQueriesOperation
    {
        #region GetOperationQuery
        public static string GetOperationQuery = $@"
               SELECT r.[PartNo] collate Cyrillic_General_CI_AS+'_'+[OperationName]+'_'+Cast(OperationNo as nvarchar(20)) as CorrelationId
              ,[OperationName] as Name
              ,[OperationNo] as Sequence
              ,[ResourceGroup]
              ,[RequiredResource]
              ,[SetupTime]
              ,[ProcessTimeType]
              ,[RunTime] as EstimatedDuration_Ticks
              ,r.[BD] as Description
              ,r.[PartNo] collate Cyrillic_General_CI_AS+'_'+[OperationName]+'_'+Cast(OperationNo as nvarchar(20)) as UId
              ,r.[PartNo] collate Cyrillic_General_CI_AS+'_'+[OperationName]+'_'+Cast(OperationNo as nvarchar(20)) as NId
              ,'Siemens.SimaticIT.U4DM.MasterData.FB_MS_BOP.MSModel.DataModel.Operation' as EntityType
              ,N'Процесс для детали ' + r.[PartNo] as ProcessName
              ,i.Product collate Cyrillic_General_CI_AS+'_' +r.[PartNo] as ProcessNId
               ,r.PartNo
          FROM [RealData].[RoutingData] r
		  		  left join [RealData].[ItemData] i on i.PartNo = r.PartNo
				  order by r.PartNo,r.OperationNo

            ";
        #endregion

        #region GetOperationQueryByNId
        public static string GetOperationQueryByNId = $@"
         SELECT r.[PartNo] collate Cyrillic_General_CI_AS+'_'+[OperationName]+'_'+Cast(OperationNo as nvarchar(20)) as CorrelationId
              ,[OperationName] as Name
              ,[OperationNo] as Sequence
              ,[ResourceGroup]
              ,[RequiredResource]
              ,[SetupTime]
              ,[ProcessTimeType]
              ,[RunTime] as EstimatedDuration_Ticks
              ,[BD] as Description
              ,r.[PartNo] collate Cyrillic_General_CI_AS+'_'+[OperationName]+'_'+Cast(OperationNo as nvarchar(20)) as UId
              ,r.[PartNo] collate Cyrillic_General_CI_AS+'_'+[OperationName]+'_'+Cast(OperationNo as nvarchar(20)) as NId
              ,'Siemens.SimaticIT.U4DM.MasterData.FB_MS_BOP.MSModel.DataModel.Operation' as EntityType
              ,ResourceGroup 
          FROM [RealData].[RoutingData] r
       Where PartNo = @NId";
        #endregion

        #region CreateOperationQuery
        public static string CreateOperationQuery = $@"

          IF NOT EXISTS(select 1 from RealData.[ItemData] where PartNo = @CorrelationId)
          BEGIN
               insert into [RealData].[ItemData] (
               [PartNo]
              ,[Product]
              ,[BD]
	          )
	          Values
	          (
 	             @CorrelationId
 	             ,@CorrelationId
	            ,@Description
	          )
         END;

          IF NOT EXISTS(select 1 from RealData.Connect_ResourceGroup where ResourceGroup = @ResourceGroup)
          BEGIN
               insert into [RealData].[Connect_ResourceGroup] (
               [ResourceGroup]
              ,[BD]
	          )
	          Values
	          (
 	             @ResourceGroup
	            ,@Description
	          )
         END;



        Insert into [RealData].[RoutingData]
       (
               [PartNo]
              ,[OperationName]
              ,[OperationNo]
              ,[RunTime]
              ,[BD]
              ,[UID]
              ,[ResourceGroup]
	   )
	   Values
       (
           @CorrelationId
          ,@Name
          ,@Sequence
          ,@EstimatedDuration_Ticks/10000000
          ,@Description
          ,@UId
          ,@ResourceGroup
       )";
        #endregion

        #region UpdateOperationQuery
        public static string UpdateOperationQuery = $@"

          IF NOT EXISTS(select 1 from RealData.[ItemData] where PartNo = @CorrelationId)
          BEGIN
               insert into [RealData].[ItemData] (
               [PartNo]
              ,[Product]
              ,[BD]
	          )
	          Values
	          (
 	             @CorrelationId
 	             ,@CorrelationId
	            ,@Description
	          )
         END;

          IF NOT EXISTS(select 1 from RealData.Connect_ResourceGroup where ResourceGroup = @ResourceGroup)
          BEGIN
               insert into [RealData].[Connect_ResourceGroup] (
               [ResourceGroup]
              ,[BD]
	          )
	          Values
	          (
 	             @ResourceGroup
	            ,@Description
	          )
         END;


        Update [RealData].[RoutingData]
	       set
               [OperationName] = @Name
              ,[OperationNo] = @Sequence
              ,[RunTime]  = @EstimatedDuration_Ticks/10000000
              ,[BD] = @Description
              ,[UID] = @UId
              ,ResourceGroup = @ResourceGroup
           WHERE [PartNo]= @CorrelationId

       ";
        #endregion

        #region DeleteOperationQuery
        public static string DeleteOperationQuery = $@"
        Delete from [RealData].[RoutingData]
	       where
		   [PartNo]= @NId
        ";
        #endregion
        #region GetPreviousOperationByPartNo_OpNo
        public static string GetPreviousOperationByPartNo_OpNo = @"

            select * from 
            (
            Select  
			   rn
			   ,CorrelationId
              ,Name
              ,Sequence
			  ,Lag(Sequence) over (Partition by partNo order by partNo,rn)  as prevSeq
              ,[ResourceGroup]
              ,[RequiredResource]
              ,[SetupTime]
              ,[ProcessTimeType]
              ,EstimatedDuration_Ticks
              ,Description
              ,UId
              ,NId
              ,EntityType
              ,ProcessName
              ,ProcessNId
              ,PartNo
               ,[PartNo] collate Cyrillic_General_CI_AS+'_'
                    +Cast(Lag(Name) over (Partition by partNo order by partNo,rn) as nvarchar(199))
                    +'_'+Cast(Lag(Sequence) over (Partition by partNo order by partNo,rn) as nvarchar(20)) as PrevNId


from(
               SELECT 
			   ROW_NUMBER() over (partition by r.PartNo order by r.Partno,OperationNo ) as rn
			   ,r.[PartNo] collate Cyrillic_General_CI_AS+'_'+[OperationName]+'_'+Cast(OperationNo as nvarchar(20)) as CorrelationId
              ,[OperationName] as Name
              ,[OperationNo] as Sequence
              ,[ResourceGroup]
              ,[RequiredResource]
              ,[SetupTime]
              ,[ProcessTimeType]
              ,[RunTime] as EstimatedDuration_Ticks
              ,r.[BD] as Description
              ,r.[PartNo] collate Cyrillic_General_CI_AS+'_'+[OperationName]+'_'+Cast(OperationNo as nvarchar(20)) as UId
              ,r.[PartNo] collate Cyrillic_General_CI_AS+'_'+[OperationName]+'_'+Cast(OperationNo as nvarchar(20)) as NId
              ,'Siemens.SimaticIT.U4DM.MasterData.FB_MS_BOP.MSModel.DataModel.Operation' as EntityType
              ,N'Процесс для детали ' + r.[PartNo] as ProcessName
              ,i.Product collate Cyrillic_General_CI_AS+'_' +r.[PartNo] as ProcessNId
              ,r.PartNo
			   FROM [RealData].[RoutingData] r
		  		  left join [RealData].[ItemData] i on i.PartNo = r.PartNo
			   ) as innerT
				
				  
            ) outerT
				  where outerT.PartNo =@PartNo and outerT.Sequence = @OpNo
				  
				  order by outerT.PartNo,outerT.Sequence
        ";


        #endregion
    }

    public static class SQLQueriesProcesses
    {
        #region GetProcessesQuery
        public static string GetProcessesQuery = $@"
              SELECT distinct
               r.[PartNo] as FinalMaterialId_Material_NId
              ,r.[PartNo] as Material_NId
              ,N'Процесс для детали ' + r.[PartNo] as Name
              ,r.[PartNo] as Revision
              ,i.Product collate Cyrillic_General_CI_AS+'_' +r.[PartNo] as NId
              ,i.Product collate Cyrillic_General_CI_AS+'_' +r.[PartNo] as UId
			  ,i.Product as FinalMaterialName
              ,r.[PartNo] as FinalMaterialNId
              ,'Siemens.SimaticIT.U4DM.MasterData.FB_MS_BOP.MSModel.DataModel.Processes' as EntityType
          FROM [RealData].[RoutingData] r
		  left join [RealData].[ItemData] i on i.PartNo = r.PartNo
        ";
        #endregion

        #region GetProcessesQueryByNId
        public static string GetProcessesQueryByNId = $@"       
              SELECT distinct
               r.[PartNo] as FinalMaterialId_Material_NId
              ,r.[PartNo] as Material_NId
              ,N'Процесс для детали' + r.[PartNo] as Name
              ,r.[PartNo] as Revision
              ,r.[PartNo] as NId
              ,[ResourceGroup] as Plant
			  ,i.Product as FinalMaterialName
              ,r.[PartNo] as FinalMaterialNId
              ,'Siemens.SimaticIT.U4DM.MasterData.FB_MS_BOP.MSModel.DataModel.Processes' as EntityType
          FROM [RealData].[RoutingData] r
		  left join [RealData].[ItemData] i on i.PartNo = r.PartNo       Where r.PartNo = @NId";
        #endregion

        #region CreateProcessesQuery
        public static string CreateProcessesQuery = $@"

          IF NOT EXISTS(select 1 from RealData.[ItemData] where PartNo = @FinalMaterialNId)
          BEGIN
               insert into [RealData].[ItemData] (
               [PartNo]
              ,[Product]
              ,[BD]
	          )
	          Values
	          (
 	             @FinalMaterialNId
 	             ,@FinalMaterialName
	            ,@Description
	          )
         END;


       ";
        #endregion

        #region UpdateProcessesQuery
        public static string UpdateProcessesQuery = $@"

          IF NOT EXISTS(select 1 from RealData.[ItemData] where PartNo = @CorrelationId)
          BEGIN
               insert into [RealData].[ItemData] (
               [PartNo]
              ,[Product]
              ,[BD]
	          )
	          Values
	          (
 	             @FinalMaterialNId
 	             ,@FinalMaterialName
	            ,@Description
	          )
         END;

       ";
        #endregion

        #region DeleteProcessesQuery
        public static string DeleteProcessesQuery = $@"
        Delete from [RealData].[ItemData]
	       where
		   [PartNo]= @NId
        ";
        #endregion


    }

    public static class SQLQueriesProcessToOperationLink
    {
        #region GetProcessToOperationLinkQuery
        public static string GetProcessToOperationLinkQuery = $@"
             SELECT [PartNo] as ParentProcess_NId
              ,[OperationName] as ChildOperation_Name
              ,[OperationNo] as Sequence
              ,[BD] as CorrelationId
              ,[PartNo]+'_'+CAST([OperationNo] as nvarchar(99)) as UID
              ,[PartNo]+'_'+CAST([OperationNo] as nvarchar(99)) as AId
              ,'Siemens.SimaticIT.U4DM.MasterData.FB_MS_BOP.MSModel.DataModel.ProcessToOperationLink' as EntityType
            FROM [RealData].[RoutingData]
        ";
        #endregion

        #region GetProcessToOperationLinkQueryByNId
        public static string GetProcessToOperationLinkQueryByNId = $@"       
             SELECT [PartNo] as ParentProcess_NId
              ,[OperationName] as ChildOperation_Name
              ,[OperationNo] as Sequence
              ,[BD] as CorrelationId
              ,[PartNo]+'_'+CAST([OperationNo] as nvarchar(99)) as UID
              ,[PartNo]+'_'+CAST([OperationNo] as nvarchar(99)) as AId
              ,'Siemens.SimaticIT.U4DM.MasterData.FB_MS_BOP.MSModel.DataModel.ProcessToOperationLink' as EntityType
            FROM [RealData].[RoutingData]
		  Where r.PartNo = @NId";
        #endregion

        #region CreateProcessToOperationLinkQuery
        public static string CreateProcessToOperationLinkQuery = $@"
          IF NOT EXISTS(select 1 from RealData.[ItemData] where PartNo = @CorrelationId)
          BEGIN
               insert into [RealData].[ItemData] (
               [PartNo]
              ,[Product]
              ,[BD]
	          )
	          Values
	          (
 	             @ParentProcess_NId
 	             ,@ParentProcess_Name
	            ,@CorrelationId
	          )
         END;

          IF NOT EXISTS(select 1 from RealData.Connect_ResourceGroup where ResourceGroup = @ResourceGroup)
          BEGIN
               insert into [RealData].[Connect_ResourceGroup] (
               [ResourceGroup]
              ,[BD]
	          )
	          Values
	          (
 	             @Plant
	            ,@CorrelationId
	          )
         END;

          IF NOT EXISTS(select 1 from RealData.[RoutingData] where PartNo = @FinalMaterialNId)
          BEGIN
               insert into [RealData].[RoutingData] (
               [PartNo]
              ,[Product]
              ,[OperationName]
              ,[OperationNo]
              ,[BD]
	          )
	          Values
	          (
 	             @ParentProcess_NId
 	            ,@ParentProcess_Name
                ,@ChildOperation_Name
                ,@Sequence
	            ,@CorrelationId
	          )
         END;


       ";
        #endregion

        #region UpdateProcessToOperationLinkQuery
        public static string UpdateProcessToOperationLinkQuery = $@"
          IF NOT EXISTS(select 1 from RealData.[ItemData] where PartNo = @CorrelationId)
          BEGIN
               insert into [RealData].[ItemData] (
               [PartNo]
              ,[Product]
              ,[BD]
	          )
	          Values
	          (
 	             @ParentProcess_NId
 	             ,@ParentProcess_Name
	            ,@CorrelationId
	          )
         END;

          IF NOT EXISTS(select 1 from RealData.Connect_ResourceGroup where ResourceGroup = @ResourceGroup)
          BEGIN
               insert into [RealData].[Connect_ResourceGroup] (
               [ResourceGroup]
              ,[BD]
	          )
	          Values
	          (
 	             @Plant
	            ,@CorrelationId
	          )
         END;

        Update [RealData].[RoutingData]
	       set
               [OperationName] = @ParentProcess_Name
              ,[OperationNo] = @Sequence
              ,[BD] = @CorrelationId
              ,[UID] = @ParentProcess_NId
              ,ResourceGroup = @Plant
              ,[OperationName] = @ChildOperation_Name
           WHERE [PartNo]= @ParentProcess_NId


       ";
        #endregion

        #region DeleteProcessToOperationLinkQuery
        public static string DeleteProcessToOperationLinkQuery = $@"
        Delete from [RealData].[ItemData]
	       where
		   [PartNo]= @NId
        ";
        #endregion


    }

    public static class SQLQueriesMaterialSpecification
    {
        #region GetMaterialSpecificationQuery
        public static string GetMaterialSpecificationQuery = $@"
            SELECT   
               idP.Product collate Cyrillic_General_CI_AS+'_' +PBom.[PartNo] as AsPlannedBOP_NId
	          ,idP.Product as Product
              --,pBom.[PartNo] as MaterialNId
              ,[OperationName] as Operation_Name
              ,[OperationNo] as Operation_Number
              ,[RequiredPartNo] as MaterialNId
	          ,idRp.Product as requiredProduct
              ,[RequiredQuantity] as QuantityVal
              ,pBom.[UID] as CorrelationId
              ,pBom.[UID] 
              ,pBom.[PartNo] collate Cyrillic_General_CI_AS+'_'+[OperationName]+'_'+Cast(OperationNo as nvarchar(20)) as UId
              ,pBom.[PartNo] collate Cyrillic_General_CI_AS+'_'+[OperationName]+'_'+Cast(OperationNo as nvarchar(20)) as OperationNId

            FROM [RealData].[ProductBoMData] pBom
            inner join [RealData].[ItemData] idP 
                on idP.PartNo = pBom.PartNo
            inner join [RealData].[ItemData] idRp 
                on idrP.PartNo = pBom.RequiredPartNo

        ";
        #endregion


        #region GetBoMQuery
        public static string GetBoMQuery = $@"
            SELECT 
              pBom.[UID]  as Id
              ,pBom.[PartNo] as NId
	          ,idP.Product as Name
              ,[RequiredPartNo] as ItemNId
	          ,idRp.Product as ItemName
              ,[RequiredQuantity] as ItemQuantityVal
            FROM [RealData].[ProductBoMData] pBom
            inner join [RealData].[ItemData] idP 
                on idP.PartNo = pBom.PartNo
            inner join [RealData].[ItemData] idRp 
                on idrP.PartNo = pBom.PartNo


        ";
        #endregion



        #region GetMaterialSpecificationQueryByNId
        public static string GetMaterialSpecificationQueryByNId = $@"
            SELECT pBom.[PartNo] as AsPlannedBOP_NId
	          ,idP.Product as Product
              ,[OperationName] as Operation_Name
              ,[OperationNo] as Operation_Number
              ,[RequiredPartNo] as MaterialNId
	          ,idRp.Product as requiredProduct
              ,[RequiredQuantity] as QuantityVal
              ,pBom.[BD] as CorrelationId
              ,pBom.[UID] 
            FROM [RealData].[ProductBoMData] pBom
            inner join [RealData].[ItemData] idP 
                on idP.PartNo = pBom.PartNo
            inner join [RealData].[ItemData] idRp 
                on idrP.PartNo = pBom.PartNo
            Where PartNo = @NId";
        #endregion

        #region CreateMaterialSpecificationQuery
        public static string CreateMaterialSpecificationQuery = $@"
       Insert into [RealData].[ProductBoMData]
       (
           [PartNo]
          ,[OperationName]
          ,[OperationNo]
          ,[RequiredPartNo]
          ,[RequiredQuantity]
          ,[BD]
          ,[UID]
	   )
	   Values
       (
            @AsPlannedBOP_NId
          , @Operation_Name
          , @Operation_Number
          , @MaterialNId
          , @QuantityVal
          , @CorrelationId
          , @MaterialNId
       )";
        #endregion

        #region UpdateMaterialSpecificationQuery
        public static string UpdateMaterialSpecificationQuery = $@"
       Update [RealData].[ProductBoMData]
	       set
           [PartNo] = @AsPlannedBOP_NId
          ,[OperationName] = @Operation_Name
          ,[OperationNo] = @Operation_Number
          ,[RequiredPartNo] = @MaterialNId
          ,[RequiredQuantity] = @QuantityVal
          ,[BD] = @CorrelationId
          ,[UID] = @MaterialNId


         WHERE [PartNo]= @NId and  OperationNo=@Operation_Number and [RequiredPartNo] = @MaterialNId

       ";
        #endregion

        #region DeleteMaterialSpecificationQuery
        public static string DeleteMaterialSpecificationQuery = $@"
        Delete from [RealData].[ProductBoMData]
	       where
		    [PartNo]= @NId and  OperationNo=@Operation_Number and [RequiredPartNo] = @MaterialNId
        ";
        #endregion


    }

    public static class SQLQueriesEquipmentSpecification
    {
        #region GetEquipmentSpecificationQuery
        public static string GetEquipmentSpecificationQuery = $@"
            SELECT 
	               rd.[PartNo] as AsPlannedBOP_NId
                  ,rd.[OperationName] as ParentOperation_NId
                  ,rd.[OperationName] as ParentOperation_Name
                  ,rd.[OperationNo] as ParentOperation_Sequence
                  ,rd.[ResourceGroup]  as EquipmentGroupNId
                  ,rd.[SetupTime] 
                  ,rd.[ProcessTimeType] 
                  ,rd.[RunTime] 
                  ,rd.[BD] 
                  --,rd.[UID] 
                  ,'' as UID 
	              ,rg.Resource as EquipmentNId
            FROM [RealData].[RoutingData] rd
            inner join [RealData].[ResourceGroupData] rg
            on rg.Name = ResourceGroup
        ";
        #endregion

        #region GetEquipmentSpecificationQueryByNId
        public static string GetEquipmentSpecificationQueryByNId = $@"
            SELECT 
	               rd.[PartNo] as AsPlannedBOP_NId
                  ,rd.[OperationName] as ParentOperation_NId
                  ,rd.[OperationName] as ParentOperation_Name
                  ,rd.[OperationNo] as ParentOperation_Sequence
                  ,rd.[ResourceGroup] as  EquipmentGroupNId
                  ,rd.[SetupTime] 
                  ,rd.[ProcessTimeType] 
                  ,rd.[RunTime] 
                  ,rd.[BD] 
                  ,rd.[UID] 
	              ,rg.Resource as EquipmentNId
            FROM [RealData].[RoutingData] rd
            inner join [RealData].[ResourceGroupData] rg
            on rg.Name = ResourceGroup
           Where PartNo = @NId";
        #endregion

        #region CreateEquipmentSpecificationQuery
        public static string CreateEquipmentSpecificationQuery = $@"

          IF NOT EXISTS(select 1 from RealData.Connect_ResourceGroup where ResourceGroup = @EquipmentGroupNId)
          BEGIN
               insert into [RealData].[Connect_ResourceGroup] (
               [ResourceGroup]
              ,[BD]
	          )
	          Values
	          (
 	             @EquipmentGroupNId
	            ,'103'
	          )
         END;

        Insert into [RealData].[RoutingData]
       (
               [PartNo]
              ,[OperationName]
              ,[OperationNo]
              ,[RunTime]
              ,[BD]
              ,[UID]
              ,[ResourceGroup]
	   )
	   Values
       (
           @AsPlannedBOP_NId
          ,@ParentOperation_NId
          ,@ParentOperation_Sequence
          ,@EstimatedDuration_Ticks/10000000
          ,'103'
          ,@AId
          ,@EquipmentGroupNId
       )";
        #endregion

        #region UpdateEquipmentSpecificationQuery
        public static string UpdateEquipmentSpecificationQuery = $@"

          IF NOT EXISTS(select 1 from RealData.Connect_ResourceGroup where ResourceGroup = @EquipmentGroupNId)
          BEGIN
               insert into [RealData].[Connect_ResourceGroup] (
               [ResourceGroup]
              ,[BD]
	          )
	          Values
	          (
 	             @EquipmentGroupNId
	            ,'103'
	          )
         END;

        Update [RealData].[RoutingData]
	       set
               PartNo = @AsPlannedBOP_NId             
              ,[OperationName] = @ParentOperation_NId
              ,[OperationNo] = @ParentOperation_NId
              ,[BD] = '103'
              ,UID = @AId
              ,ResourceGroup = @EquipmentGroupNId
           WHERE [PartNo]= @AsPlannedBOP_NId

       ";
        #endregion

        #region DeleteEquipmentSpecificationQuery
        public static string DeleteEquipmentSpecificationQuery = $@"
        Delete from [RealData].[RoutingData]
	       where
		   [PartNo]= @NId
        ";
        #endregion


    }

    public static class SQLQueriesWO
    {
        #region GetWOQuery
        public static string GetWOQuery = $@"
            SELECT [OrderNo] Name
                   ,[OrderNo] ERPOrder
	               ,OrderNo NId
                  ,[Quantity] InitialQuantity
                  ,[ReleaseDate]  CreationDate
                  ,[DueDate] DueDate
                  ,[Priority] Priority
                  ,[EarliestStartDate]
                  ,[ParentDemand] ParentBatch
                  ,f.[uid] as AId
                  ,i.Product collate Cyrillic_General_CI_AS+'_' +f.[PartNo] as ProcessNId
	              ,'Siemens.SimaticIT.U4DM.OperationalData.Runtime.OPModel.DataModel.WorkOrder' EntityType
                  ,f.[PartNo] as Material_NId
                  ,[Description] Material_Name
                  ,OrderNo+'_'+f.[PartNo] collate Cyrillic_General_CI_AS+'_'+rd.[OperationName]+'_'+Cast(rd.OperationNo as nvarchar(20)) as OperationNId
				  ,rd.OperationNo as Sequence
                  ,rd.OperationName OperationName
				  ,rd.RunTime as EstimatedDuration_Ticks

                FROM [RealData].[FirmOrdersData] f
			  left join [RealData].[RoutingData] rd
			  on rd.PartNo = f.PartNo
		  left join [RealData].[ItemData] i on i.PartNo = f.PartNo

            ";
        #endregion

        #region GetWOQueryByNId
        public static string GetWOQueryByNId = $@"
            SELECT [OrderNo] Name
                   ,[OrderNo] ERPOrder
	               ,OrderNo NId
                  ,[Quantity] InitialQuantity
                  ,[ReleaseDate]  CreationDate
                  ,[DueDate] DueDate
                  ,[Priority] Priority
                  ,[EarliestStartDate]
                  ,[ParentDemand] ParentBatch
                  ,f.[uid] as AId
                  ,i.Product collate Cyrillic_General_CI_AS+'_' +f.[PartNo] as ProcessNId
	              ,'Siemens.SimaticIT.U4DM.OperationalData.Runtime.OPModel.DataModel.WorkOrder' EntityType
                  ,f.[PartNo] as Material_NId
                  ,[Description] Material_Name
				  ,rd.OperationNo as Sequence
                  ,OrderNo+'_'+f.[PartNo] collate Cyrillic_General_CI_AS+'_'+rd.[OperationName]+'_'+Cast(rd.OperationNo as nvarchar(20)) as OperationNId
				  ,rd.OperationName OperationName
				  ,rd.RunTime as EstimatedDuration_Ticks
              FROM [RealData].[FirmOrdersData] f
			  left join [RealData].[RoutingData] rd
			  on rd.PartNo = f.PartNo
		  left join [RealData].[ItemData] i on i.PartNo = f.PartNo
            where OrderNo=@NId

        ";
        #endregion


        #region GetPreviousWOOperationByOrderNo_OpNo
        public static string GetPreviousWOOperationByOrderNo_OpNo = @"

             select * from 
            (
			select
			*
			,Lag(Sequence) over (Partition by NId order by NId,rn)  as prevSeq
			               ,NId collate Cyrillic_General_CI_AS+'_'+Material_NId+'_'
                    +Cast(Lag(OperationName) over (Partition by NId order by NId,rn) as nvarchar(199))
                    +'_'+Cast(Lag(Sequence) over (Partition by NId order by NId,rn) as nvarchar(20)) as PrevNId

			from
			(
			SELECT 
    			   ROW_NUMBER() over (partition by [OrderNo] order by [OrderNo],rd.OperationNo ) as rn
				  ,[OrderNo] Name
                  ,[OrderNo] ERPOrder
	              ,OrderNo NId
                  ,[Quantity] InitialQuantity
                  ,[ReleaseDate]  CreationDate
                  ,[DueDate] DueDate
                  ,[Priority] Priority
                  ,[EarliestStartDate]
                  ,[ParentDemand] ParentBatch
                  ,f.[uid] as AId
                  ,i.Product collate Cyrillic_General_CI_AS+'_' +f.[PartNo] as ProcessNId
	              ,'Siemens.SimaticIT.U4DM.OperationalData.Runtime.OPModel.DataModel.WorkOrder' EntityType
                  ,f.[PartNo] as Material_NId
                  ,[Description] Material_Name
				  ,rd.OperationNo as Sequence
                  ,OrderNo+'_'+f.[PartNo] collate Cyrillic_General_CI_AS+'_'+rd.[OperationName]+'_'+Cast(rd.OperationNo as nvarchar(20)) as OperationNId
				  ,rd.OperationName OperationName
				  ,rd.RunTime as EstimatedDuration_Ticks
              FROM [RealData].[FirmOrdersData] f
			  left join [RealData].[RoutingData] rd
			  on rd.PartNo = f.PartNo
		  left join [RealData].[ItemData] i on i.PartNo = f.PartNo
		  )innerT
		  )outerT
		  		  where outerT.Sequence = @OpNo
				  and outerT.ERPOrder=@OrderNo
				  
				  order by outerT.Material_NId,outerT.Sequence
        ";


        #endregion




        #region CreateWOQuery
        public static string CreateWOQuery = $@"

        ";
        #endregion

        #region UpdateWOQuery
        public static string UpdateWOQuery = $@"


       ";
        #endregion

        #region DeleteWOQuery
        public static string DeleteWOQuery = $@"
        ";
        #endregion

    }



}
