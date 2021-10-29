using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class QuantityType
    {
        public String UoMNId;
        public float? QuantityValue;
    }
    public class AMPowderPropertiesParameterType
    {
        public QuantityType MinQuantity;
        public int MaxRecycleCount;
    }
    
    public class DMMaterialDTOResponse
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<DMMaterialDTO> value;
        public bool Succeeded;
        public string DM_MaterialId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class DMMaterialDTOUpdateParameter
    {
        public string Id;
        public bool SerialNumberProfile;
        public bool FirstArticleInspection;
        public bool IsPhantom;
        public bool Traceable;
        public QuantityType Volume;
        public QuantityType Weight;
        public AMPowderPropertiesParameterType AMPowderProperties;
        public string LogisticClassNId;
        public string MaterialClassNId;
        public string FunctionalCodeNId;

        public DMMaterialDTOUpdateParameter(DMMaterialDTO DMMatEl)
        {
            Id = DMMatEl.Id;
            SerialNumberProfile = DMMatEl.SerialNumberProfile.HasValue ? DMMatEl.SerialNumberProfile.Value : false;
            FirstArticleInspection = DMMatEl.FirstArticleInspection.HasValue ? DMMatEl.FirstArticleInspection.Value : false;
            IsPhantom = DMMatEl.IsPhantom.HasValue ? DMMatEl.IsPhantom.Value : false;
            Traceable = DMMatEl.Traceable.HasValue ? DMMatEl.Traceable.Value : false;
            Volume = DMMatEl.Volume;
            Weight = DMMatEl.Weight;
            LogisticClassNId = DMMatEl.LogisticClassNId;
        }
    }

    public class DMMaterialDTOCreateParameter
    {
        public bool SerialNumberProfile;
        public bool FirstArticleInspection;
        public bool IsPhantom;
        public bool Traceable;
        public QuantityType Volume;
        public QuantityType Weight;
        public string MaterialId;
        public AMPowderPropertiesParameterType AMPowderProperties;
        public string LogisticClassNId;
        public string MaterialClassId;
        public string FunctionalCodeId;

        public DMMaterialDTOCreateParameter(DMMaterialDTO dmMatEl)
        {
            SerialNumberProfile = dmMatEl.SerialNumberProfile.HasValue?dmMatEl.SerialNumberProfile.Value:false;
            FirstArticleInspection = dmMatEl.FirstArticleInspection.HasValue?dmMatEl.FirstArticleInspection.Value:false;
            IsPhantom = dmMatEl.IsPhantom.HasValue?dmMatEl.IsPhantom.Value:false;
            Traceable = dmMatEl.Traceable.HasValue?dmMatEl.Traceable.Value:false;
            Volume = dmMatEl.Volume;
            Weight = dmMatEl.Weight;
            MaterialId = dmMatEl.Material_Id;
            LogisticClassNId = dmMatEl.LogisticClassNId;
        }
    }
    public class DMMaterialDTODeleteParameter
    {
        public string DM_MaterialId;
    }
    /// <summary>
    /// Доп свойства модели Material
    /// </summary>
    public class DMMaterialDTO
    {
        public static void DapperMapping()
        {
            Dapper.SqlMapper.SetTypeMap(typeof(DMMaterialDTO),
                new CustomPropertyTypeMap(typeof(DMMaterialDTO), (type, columnName) =>
                    type.GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(false).OfType<ColumnAttribute>()
                    .Any(attr => attr.Name == columnName)))
                );
        }
        public static void DapperUnMapping()
        {
            Dapper.SqlMapper.SetTypeMap(typeof(DMMaterialDTO),
                null
                );
        }

        [Column("DMMaterial_Id")]
        public string Id { get; set; }
        public string AId { get; set; }
        public Nullable<bool> IsFrozen { get; set; }
        public int ConcurrencyVersion { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string EntityType { get; set; }
        public string OptimisticVersion { get; set; }
        public String ConcurrencyToken { get; set; }
        public Nullable<bool> IsLocked { get; set; }
        public Nullable<bool> ToBeCleaned { get; set; }
        public Nullable<bool> SerialNumberProfile { get; set; }
        public Nullable<bool> FirstArticleInspection { get; set; }
        public Nullable<bool> IsPhantom { get; set; }
        public string LogisticClassNId { get; set; }
        public string CorrelationId { get; set; }
        public string EffectivityExpression { get; set; }
        public Nullable<bool> Traceable { get; set; }
        public string Material_Id { get; set; }
        public string Material_NId { get; set; }
        public string Material_Name { get; set; }
        public string MaterialClass_Id { get; set; }
        public string Supplier_Id { get; set; }
        public string FunctionalCode_Id { get; set; }
        public QuantityType Weight { get; set; }
        public QuantityType Volume { get; set; }
        public MaterialDTO Material { get; set; }
        public string[] SegregationTags { get; set; }
        public void UpdateRecord(DMMaterialDTO newEl)
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
            this.SerialNumberProfile = newEl.SerialNumberProfile;
            this.IsPhantom = newEl.IsPhantom;
            this.LogisticClassNId = newEl.LogisticClassNId;
            this.CorrelationId = newEl.CorrelationId;
            this.Material = newEl.Material;

        }//UpdateRecord

    }
}
