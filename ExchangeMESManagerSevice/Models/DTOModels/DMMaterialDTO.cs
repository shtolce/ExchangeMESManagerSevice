using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class QuantityType
    {
        public string UoMNId;
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
        public string MaterialId;
        public string CorrelationId;
        public string EffectivityExpression;
        public string SupplierId;
        public AMPowderPropertiesParameterType AMPowderProperties;
        public string LogisticClassNId;
        public string MaterialClassId;
        public string FunctionalCodeId;
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
        public string Id;
        public string AId;
        public Nullable<bool> IsFrozen;
        public int ConcurrencyVersion;
        public int IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;//"Siemens.SimaticIT.MasterData.MAT_MS.MSModel.DataModel.DMMaterial"
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public Nullable<bool> IsLocked;
        public Nullable<bool> ToBeCleaned;
        public Nullable<bool> SerialNumberProfile;
        public Nullable<bool> FirstArticleInspection;
        public Nullable<bool> IsPhantom;
        public string LogisticClassNId;
        public string CorrelationId;
        public string EffectivityExpression;
        public Nullable<bool> Traceable;
        public string Material_Id;
        public string MaterialClass_Id;
        public string Supplier_Id;
        public string FunctionalCode_Id;
        public QuantityType Weight;
        public QuantityType Volume;
        public MaterialDTO Material;
        public string[] SegregationTags;
    }
}
