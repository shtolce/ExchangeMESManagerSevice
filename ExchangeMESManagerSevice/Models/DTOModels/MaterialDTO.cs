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
    }
    public class BoMItemDTODeleteParameter
    {
        public String[] Ids;
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
        public string Id;
        public string AId;
        public bool IsFrozen;
        public int ConcurrencyVersion;
        public int IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public bool IsLocked;
        public bool ToBeCleaned;
        public string Name;
        public string Description;
        public int Priority;
        public DateTimeOffset? ValidityFrom;
        public DateTimeOffset? ValidityTo;
        public string Version;
        public string NId;
        public String MaterialDefinition_Id;
        public StatusType Status;
        public QuantityType Quantity;
        public string[] SegregationTags;
        public DMMaterialDTO MaterialDefinition;
    }
    public class BoMItemGroupTypeDTO
    {
        public string NId;
    }


    public class BoMItemDTO
    {
        public string Id;
        public string AId;
        public bool IsFrozen;
        public int ConcurrencyVersion;
        public int IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public bool IsLocked;
        public bool ToBeCleaned;
        public string NId;
        public string BoM_Id;
        public String BoMItemBoM_Id;
        public String GroupType_Id;
        public String MaterialDefinition_Id;
        public QuantityType Quantity;
        public DMMaterialDTO MaterialDefinition;
        public BoMDTO BoMItemBoM;
        public BoMItemGroupTypeDTO GroupType;

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
