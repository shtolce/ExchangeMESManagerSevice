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
        public float QuantityValue;
    }

    public class DMMaterialDTOResponse
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<DMMaterialDTO> value;
        public bool Succeeded;
        public string MaterialId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class DMMaterialDTOUpdateParameter
    {
        public string Id;
        public string Name;
        public string Description;
        public string UoMNId;
    }

    public class DMMaterialDTOCreateParameter
    {
        public bool UseDefault;
        public string NId;
        public string Revision;
        public string UId;
        public string Name;
        public string Description;
        public string UoMNId;
        public String TemplateNId;
    }
    public class DMMaterialDTODeleteParameter
    {
        public string Id;
    }
    /// <summary>
    /// Доп свойства модели Material
    /// </summary>
    public class DMMaterialDTO
    {
        public string Id;
        public string AId;
        public bool IsFrozen;
        public int ConcurrencyVersion;
        public int IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;//"Siemens.SimaticIT.MasterData.MAT_MS.MSModel.DataModel.DMMaterial"
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public bool IsLocked;
        public bool ToBeCleaned;
        public bool SerialNumberProfile;
        public bool FirstArticleInspection;
        public bool IsPhantom;
        public string LogisticClassNId;
        public string CorrelationId;
        public string EffectivityExpression;
        public bool Traceable;
        public string Material_Id;
        public string MaterialClass_Id;
        public string Supplier_Id;
        public string FunctionalCode_Id;
        public QuantityType Weight;
        public QuantityType Volume;
        public MaterialDTO Material;
        string[] SegregationTags;
    }
}
