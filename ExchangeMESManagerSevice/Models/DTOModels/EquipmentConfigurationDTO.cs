using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class EquipmentConfigurationDTOResponse:IResponse<EquipmentConfigurationDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<EquipmentConfigurationDTO> value { get; set; }
        public bool Succeeded;
        public string EquipmentConfigurationId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }
    public class EquipmentGroupConfigurationDTOResponse : IResponse<EquipmentGroupConfigurationDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<EquipmentGroupConfigurationDTO> value { get; set; }
        public bool Succeeded;
        public string EquipmentConfigurationId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class EquipmentConfigurationDTOUpdateParameter
    {

        public string Name;
        public string Description;
        public string LevelNId;
        public string Id;

        public EquipmentConfigurationDTOUpdateParameter(EquipmentConfigurationDTO eq)
        {
            Name = eq.Name;
            Description = eq.Description;
            LevelNId = eq.LevelNId;
            Id = eq.Id;
        }
    }

    public class EquipmentConfigurationDTOCreateParameter
    {
        public string LevelNId;
        public string NId;
        public string Name;
        public string Description;
        public string EquipmentTypeNId;
        //public String LocationNId;

        public EquipmentConfigurationDTOCreateParameter(EquipmentConfigurationDTO eq)
        {
            LevelNId = eq.LevelNId;
            NId = eq.NId;
            Name = eq.Name;
            Description = eq.Description;
            EquipmentTypeNId = eq.EquipmentTypeNId;
            //LocationNId = eq.LocationNId;
        }
    }
    public class EquipmentConfigurationDTODeleteParameter
    {
        public string Id;
    }



    public class EquipmentGroupConfigurationDTOUpdateParameter
    {


        public string Id;
        public string Name;
        public string Description;

        public EquipmentGroupConfigurationDTOUpdateParameter(EquipmentGroupConfigurationDTO eq)
        {
            Id = eq.Id;
            Name = eq.Name;
            Description = eq.Description;
        }
    }

    public class EquipmentGroupConfigurationDTOCreateParameter
    {
        public string NId;
        public string Name;
        public string Description;
    }
    public class EquipmentGroupConfigurationDTODeleteParameter
    {
        public string Id;
    }

    public class EquipmentGroupConfigurationDTOAssociateParameter
    {
        public string EquipmentGroupConfigurationId;
        public string[] EquipmentConfigurationIds;
    }

    public class EquipmentGroupConfigurationDTO:ICloneable
    {
        public string Id { get; set; }
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
        public string NId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public String Category { get; set; }
        public List<EquipmentConfigurationDTO> EquipmentConfigurations;
        //Два поля нужны для автомаппинга 
        public String EquipmentConfigurationNId { get; set; }
        public String EquipmentConfigurationName { get; set; }
        public String EquipmentConfigurationAId { get; set; }


        public object Clone()
        {
            return new EquipmentGroupConfigurationDTO
            {
                 Id = this.Id
                ,AId = this.AId
                ,IsFrozen = this.IsFrozen
                ,ConcurrencyVersion = this.ConcurrencyVersion
                ,IsDeleted = this.IsDeleted
                ,CreatedOn = this.CreatedOn
                ,LastUpdatedOn = this.LastUpdatedOn
                ,EntityType = this.EntityType
                ,OptimisticVersion = this.OptimisticVersion
                ,ConcurrencyToken = this.ConcurrencyToken
                ,IsLocked = this.IsLocked
                ,ToBeCleaned = this.ToBeCleaned
                ,NId = this.NId
                ,Name = this.Name
                ,Description = this.Description
                ,Category = this.Category
                ,EquipmentConfigurations = this.EquipmentConfigurations.GetRange(0, this.EquipmentConfigurations.Count)

            };
        }
    }


    /// <summary>
    /// Класс материалов MES. Является базовым. Все его доп свойства расширены в другой модели EquipmentConfiguration
    /// </summary>
    public class EquipmentConfigurationDTO
    {
        public string Id { get; set; }
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
        public bool IsCurrent { get; set; }
        public string UId { get; set; }
        public string NId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UoMNId { get; set; }
        public String TemplateNId { get; set; }
        public String WorkCalendarNId { get; set; }
        public String LocationNId { get; set; }
        public String EquipmentConfigurationId { get; set; }
        public String EquipmentTypeNId { get; set; }
        public String LevelNId { get; set; }
        public void UpdateRecord(EquipmentConfigurationDTO newEq)
        {
            this.AId = newEq.AId;
            this.IsFrozen = newEq.IsFrozen;
            this.ConcurrencyVersion = newEq.ConcurrencyVersion;
            this.IsDeleted = newEq.IsDeleted;
            this.CreatedOn = newEq.CreatedOn;
            this.LastUpdatedOn = newEq.LastUpdatedOn;
            this.EntityType = newEq.EntityType;
            this.OptimisticVersion = newEq.OptimisticVersion;
            this.ConcurrencyToken = newEq.ConcurrencyToken;
            this.IsLocked = newEq.IsLocked;
            this.ToBeCleaned = newEq.ToBeCleaned;
            this.IsCurrent = newEq.IsCurrent;
            this.UId = newEq.UId;
            this.NId = newEq.NId;
            this.Name = newEq.Name;
            this.Description = newEq.Description;
            this.UoMNId = newEq.UoMNId;
            this.TemplateNId = newEq.TemplateNId;
            this.WorkCalendarNId = newEq.WorkCalendarNId;
            this.LocationNId = newEq.LocationNId;
            this.EquipmentConfigurationId = newEq.EquipmentConfigurationId;
            this.LevelNId = newEq.LevelNId;

        }

    }
    ///sit-svc/Application/Equipment/odata/EquipmentConfiguration

}
