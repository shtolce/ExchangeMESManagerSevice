using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class MaterialDTOResponse:IResponse<MaterialDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<MaterialDTO> value { get; set; }
        public bool Succeeded;
        public string MaterialId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }
    public class BoMDTOResponse : IResponse<BoMDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<BoMDTO> value { get; set; }
        public bool Succeeded;
        public string Id;
        public string MaterialId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }
    public class BoMItemDTOResponse : IResponse<BoMItemDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<BoMItemDTO> value { get; set; }
        public bool Succeeded;
        public string MaterialId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class BoMItemDTOCreateParameter
    {
        public string NId;
        public String GroupName;
        public QuantityType Quantity;
        public int? LogicalPosition;
        public String MaterialDefinition;
        public String BoM;
        public String GroupType;
        private BoMItemDTO item;

        public BoMItemDTOCreateParameter(BoMItemDTO item)
        {
            NId = item.NId;
            Quantity = item.Quantity;
            MaterialDefinition = item.MaterialDefinition_Id;
            GroupType = item.GroupType_Id;
        }
    }

    public class BoMItemDTOUpdateParameter
    {
        public string BillOfMaterialId;
        public String Id;
        public Optional_Revision MaterialRevision;
        public QuantityType MaterialQuantity;

        public BoMItemDTOUpdateParameter(BoMItemDTO el)
        {
            BillOfMaterialId = el.BoM_Id;
            Id = el.Id;
            MaterialRevision = new Optional_Revision { OptionalRevision="A"};
            MaterialQuantity = el.Quantity;
        }
    }

    public class Optional_Revision
    {
        public string OptionalRevision;
    }

    public class BoMItemDTODeleteParameter
    {
        public String[] Ids;

        public BoMItemDTODeleteParameter(BoMItemDTO el)
        {
            Ids = new string[] { el.Id };
        }
    }



    public class BoMDTOCreateParameter
    {
        public string NId;
        public string Version;
        public string Name;
        public string Description;
        public QuantityType Quantity;
        public DateTimeOffset? ValidFrom;
        public DateTimeOffset? ValidTo;
        public String MaterialDefinition;

        public BoMDTOCreateParameter(BoMDTO specEl)
        {
            NId = specEl.NId;
            Version = specEl.Version;
            Name = specEl.Name;
            Description = specEl.Description;
            Quantity = specEl.Quantity;
            MaterialDefinition = specEl.MaterialDefinition_Id;
        }
    }

    public class BoMDTOChangeStatusParameter
    {
        public string BoMId;
        public String StatusNId = "Obsolete";
    }

    public class MaterialDTOUpdateParameter
    {
        public string Id;
        public string Name;
        public string Description;
        public string UoMNId;

        public MaterialDTOUpdateParameter(MaterialDTO matEl)
        {
            Id = matEl.Id;
            Name = matEl.Name;
            Description = matEl.Description;
            UoMNId = matEl.UoMNId;
        }
    }

    public class MaterialDTOCreateParameter
    {
        public bool UseDefault;
        public string NId;
        public string Revision;
        public string UId;
        public string Name;
        public string Description;
        public string UoMNId;
        public String TemplateNId;

        public MaterialDTOCreateParameter(MaterialDTO matEl)
        {
            UseDefault = false;
            NId = matEl.NId;
            Revision = matEl.Revision;
            UId = matEl.UId;
            Name = matEl.Name;
            Description = matEl.Description;
            UoMNId = matEl.UoMNId;
            //TemplateNId = matEl.TemplateNId;
        }
    }
    public class MaterialDTODeleteParameter
    {
        public string Id;
    }

    public class BoMDTO
    {
        [Column("Id")]
        public string Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("NId")]
        public string NId { get; set; }
        public ICollection<BoMItemDTO> Items { get; set; }
        public string AId { get; set; }
        public bool IsFrozen { get; set; }
        public int ConcurrencyVersion { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string EntityType { get; set; }
        public string OptimisticVersion { get; set; }
        public String ConcurrencyToken { get; set; }
        public bool IsLocked { get; set; }
        public bool ToBeCleaned { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTimeOffset? ValidityFrom { get; set; }
        public DateTimeOffset? ValidityTo { get; set; }
        public string Version { get; set; }
        public String MaterialDefinition_Id { get; set; }
        public StatusType Status { get; set; }
        public QuantityType Quantity { get; set; }
        public string[] SegregationTags { get; set; }
        public DMMaterialDTO MaterialDefinition { get; set; }
        public static void DapperMapping()
        {
            Dapper.SqlMapper.SetTypeMap(typeof(BoMDTO),
                new CustomPropertyTypeMap(typeof(BoMDTO), (type, columnName) =>
                    type.GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(false).OfType<ColumnAttribute>()
                    .Any(attr => attr.Name == columnName)))
                );
        }
        public static void DapperUnMapping()
        {
            Dapper.SqlMapper.SetTypeMap(typeof(BoMDTO),
                null
                );
        }

    }
    public class BoMItemGroupTypeDTO
    {
        public string NId;
    }


    public class BoMItemDTO
    {
        public string ItemId { get; set; }
        public string Id { get; set; }
        [Column("ItemAId")]
        public string AId { get; set; }
        public bool IsFrozen { get; set; }
        public int ConcurrencyVersion { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string EntityType { get; set; }
        public string OptimisticVersion { get; set; }
        public String ConcurrencyToken { get; set; }
        public bool IsLocked { get; set; }
        public bool ToBeCleaned { get; set; }
        [Column("ItemNId")]
        public string NId { get; set; }
        [Column("ItemName")]
        public string Name { get; set; }

        public string BoM_Id { get; set; }
        public String BoMItemBoM_Id { get; set; }
        public String GroupType_Id { get; set; }
        public String MaterialDefinition_Id { get; set; }

        [Column("ItemQuantityVal")]
        public double QuantityVal { get; set; }
        public QuantityType Quantity { get; set; }
        public DMMaterialDTO MaterialDefinition{ get; set; }
        public BoMDTO BoMItemBoM { get; set; }
        public BoMItemGroupTypeDTO GroupType { get; set; }
        public static void DapperMapping()
        {
            Dapper.SqlMapper.SetTypeMap(typeof(BoMItemDTO),
                new CustomPropertyTypeMap(typeof(BoMItemDTO), (type, columnName) =>
                    type.GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(false).OfType<ColumnAttribute>()
                    .Any(attr => attr.Name == columnName)))
                );
        }
        public static void DapperUnMapping()
        {
            Dapper.SqlMapper.SetTypeMap(typeof(BoMItemDTO),
                null
                );
        }

    }

    /// <summary>
    /// Класс материалов MES. Является базовым. Все его доп свойства расширены в другой модели DMMaterial
    /// </summary>
    public class MaterialDTO
    {
        /// <summary>
        /// При запуске этого метода задействуются атрибуты анотации при маппировании даппером
        /// </summary>
        public static void DapperMapping()
        {
            Dapper.SqlMapper.SetTypeMap(typeof(MaterialDTO),
                new CustomPropertyTypeMap(typeof(MaterialDTO), (type, columnName) =>
                    type.GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(false).OfType<ColumnAttribute>()
                    .Any(attr => attr.Name == columnName)))
                );
        }
        public static void DapperUnMapping()
        {
            Dapper.SqlMapper.SetTypeMap(typeof(MaterialDTO),
                null
                );
        }


        [Column("MaterialId")]
        public string Id { get; set; }
        [Column("MaterialAId")]
        public string AId { get; set; }
        public bool IsFrozen { get; set; }
        public int ConcurrencyVersion { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string EntityType { get; set; }
        public string OptimisticVersion { get; set; }
        public String ConcurrencyToken { get; set; }
        public bool IsLocked { get; set; }
        public bool ToBeCleaned { get; set; }
        public string Revision { get; set; }
        public String SourceRevision { get; set; }
        public bool IsCurrent { get; set; }
        [Column("MaterialUId")]
        public string UId { get; set; }
        [Column("MaterialNId")]
        public string NId { get; set; }
        [Column("MaterialName")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Column("MaterialUoMNId")]
        public string UoMNId { get; set; }
        [Column("MaterialTemplateNId")]
        public String TemplateNId { get; set; }
        public void UpdateRecord(MaterialDTO newEl)
        {
            this.AId = newEl.AId;
            this.IsFrozen = newEl.IsFrozen;
            this.ConcurrencyVersion = newEl.ConcurrencyVersion;
            this.IsDeleted = newEl.IsDeleted;
            this.CreatedOn = newEl.CreatedOn;
            this.LastUpdatedOn = newEl.LastUpdatedOn;
            this.EntityType = newEl.EntityType;
            this.OptimisticVersion = newEl.OptimisticVersion;
            this.ConcurrencyToken = newEl.ConcurrencyToken;
            this.IsLocked = newEl.IsLocked;
            this.ToBeCleaned = newEl.ToBeCleaned;
            this.Revision = newEl.Revision;
            this.SourceRevision = newEl.SourceRevision;
            this.IsCurrent = newEl.IsCurrent;
            this.UId = newEl.UId;
            this.NId = newEl.NId;
            this.Name = newEl.Name;
            this.Description = newEl.Description;
            this.UoMNId = newEl.UoMNId;
            this.TemplateNId = newEl.TemplateNId;
        }//UpdateRecord

    }
}
