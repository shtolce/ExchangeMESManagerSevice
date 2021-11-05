using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExchangeMESManagerSevice.Models.CommandModels;
using ExchangeMESManagerSevice.Models.DTOModels;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Services
{
    public class HttpWorkOrdersRepository
    {
        private AuthorizationMesService _authService;

        public HttpWorkOrdersRepository(IHostedService authService)
        {
            _authService = (AuthorizationMesService)authService;
        }
        public WorkOrderDTOResponse CreateWorkOrdersFromAsPlannedBOP(WorkOrderDTOCreateFromAsPlannedBOPParameter com)
        {
            return ExecuteCommand<WorkOrderDTOCreateFromAsPlannedBOPParameter, WorkOrderDTOResponse>(com, "UADMCreateWorkOrdersFromAsPlannedBOP"); ;
        }
        public WorkOrderDTOResponse CreateWorkOrderFromProcess(WorkOrderDTOCreateFromProcessParameter com)
        {
            return ExecuteCommand<WorkOrderDTOCreateFromProcessParameter, WorkOrderDTOResponse>(com, "UADMCreateWorkOrderFromProcess"); ;
        }
        public WorkOrderDTOResponse CreateWorkOrder(WorkOrderDTOCreateParameter com)
        {
            return ExecuteCommand<WorkOrderDTOCreateParameter, WorkOrderDTOResponse>(com, "CreateWorkOrder"); ;
        }
        public WorkOrderDTOResponse DeleteWorkOrder(WorkOrderDTODeleteParameter com)
        {
            return ExecuteCommand<WorkOrderDTODeleteParameter, WorkOrderDTOResponse>(com, "DeleteWorkOrder"); ;
        }
        public WorkOrderDTOResponse UpdateWorkOrder(WorkOrderDTOUpdateParameter com)
        {
            return ExecuteCommand<WorkOrderDTOUpdateParameter, WorkOrderDTOResponse>(com, "EditWorkOrder"); ;
        }
        public WorkOrderOperationDTOResponse CreateWorkOrderOperation(WorkOrderOperationDTOCreateParameter com)
        {
            return ExecuteCommand<WorkOrderOperationDTOCreateParameter, WorkOrderOperationDTOResponse>(com, "CreateWorkOrderOperation"); ;
        }
        public WorkOrderOperationDTOResponse CreateWorkOrderOperations(WorkOrderOperationsDTOCreateParameter com)
        {
            return ExecuteCommand<WorkOrderOperationsDTOCreateParameter, WorkOrderOperationDTOResponse>(com, "CreateWorkOrderOperations"); ;
        }
        public WorkOrderOperationDTOResponse CreateWorkOrderOperationFromProcessOperation(WorkOrderOperationFromProcessOperationDTOCreateParameter com)
        {
            return ExecuteCommand<WorkOrderOperationFromProcessOperationDTOCreateParameter, WorkOrderOperationDTOResponse>(com, "UADMCreateWorkOrderOperationFromProcessOperation"); ;
        }
        public WorkOrderOperationDTOResponse UpdateWorkOrderOperation(WorkOrderOperationDTOUpdateParameter com)
        {
            return ExecuteCommand<WorkOrderOperationDTOUpdateParameter, WorkOrderOperationDTOResponse>(com, "EditWorkOrderOperation"); ;
        }
        public WorkOrderOperationDTOResponse DeleteWorkOrderOperation(WorkOrderOperationDTODeleteParameter com)
        {
            return ExecuteCommand<WorkOrderOperationDTODeleteParameter, WorkOrderOperationDTOResponse>(com, "DeleteWorkOrderOperation"); ;
        }


        public WorkOOperationDependencyDTOResponse CreateWorkOrderOperationDependencies(WorkOrderOperationDependenciesDTOCreateParameter com)
        {
            return ExecuteCommand<WorkOrderOperationDependenciesDTOCreateParameter, WorkOOperationDependencyDTOResponse>(com, "CreateWorkOOperationDependencies"); ;
        }
        public WorkOOperationDependencyDTOResponse DeleteWOOperationDependency(WorkOrderOperationDependenciesDTODeleteParameter com)
        {
            return ExecuteCommand<WorkOrderOperationDependenciesDTODeleteParameter, WorkOOperationDependencyDTOResponse>(com, "DeleteWOOperationDependency"); ;
        }

        public ToBeConsumedMaterialDTOResponse CreateToBeConsumedMaterials(ToBeConsumedMaterialsDTOCreateParameter com)
        {
            return ExecuteCommand<ToBeConsumedMaterialsDTOCreateParameter, ToBeConsumedMaterialDTOResponse>(com, "CreateToBeConsumedMaterials"); ;
        }
        public ToBeConsumedMaterialDTOResponse DeleteToBeConsumedMaterials(ToBeConsumedMaterialsDTODeleteParameter com)
        {
            return ExecuteCommand<ToBeConsumedMaterialsDTODeleteParameter, ToBeConsumedMaterialDTOResponse>(com, "DeleteToBeConsumedMateria"); ;
        }




        public MaterialBatchDTOResponse GenerateMaterialBatchId(MaterialBatchDTOGenerateParameter com)
        {
            return ExecuteCommand<MaterialBatchDTOGenerateParameter, MaterialBatchDTOResponse>(com, "GenerateMaterialBatchId"); ;
        }

        private D ExecuteCommand<T, D>(T com, string commandName,string AppName= "AppU4DM")
            where D : class
        {
            if (_authService.StateOAuth == null)
                return null;
            HttpWebRequest webRequest = HttpWebRequest.Create($"http://localhost/sit-svc/Application/{AppName}/odata/{commandName}") as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            Command<T> comTest = new Command<T>()
            {
                command = com
            };
            string parameters = JsonConvert.SerializeObject(comTest);
            byte[] byteArray = Encoding.UTF8.GetBytes(parameters);
            webRequest.ContentLength = byteArray.Length;
            webRequest.Headers.Add("Authorization", "Bearer " + _authService.StateOAuth.access_token);
            Stream postStream = webRequest.GetRequestStream();
            postStream = webRequest.GetRequestStream();
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();

            WebResponse response;
            try
            {
                response = webRequest.GetResponse();
            }
            catch (WebException ex)
            {
                using (var reader1 = new StreamReader(ex.Response.GetResponseStream()))
                {
                    var testErr = reader1.ReadToEnd();
                    var serStatusErr = JsonConvert.DeserializeObject<D>(testErr);
                    return serStatusErr;
                }

            }
            postStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(postStream);
            string responseFromServer = reader.ReadToEnd();
            var serStatus2 = JsonConvert.DeserializeObject<D>(responseFromServer);
            return serStatus2;
        }

        public List<T> Get<T, D>(string urlProfile) where D : IResponse<T>
        {
            HttpClient client = new HttpClient();

            if (_authService.StateOAuth == null)
            {
                return new List<T>();
            }
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _authService.StateOAuth.access_token);
            client.CancelPendingRequests();
            var task = Task.Run(async () => await client.GetAsync(urlProfile));
            HttpResponseMessage output = task.Result;
            HttpContent stream = output.Content;
            var content = Task.Run(async () => await stream.ReadAsAsync<D>());
            var res = content.Result;
            return res.value;
        }

        public List<WorkOrderDTO> GetAll()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/WorkOrder?$expand=FinalMaterial($expand = Material),ProductionType($select= NId),WorkOrderOperations($expand=ToBeConsumedMaterials),SegregationTags, ProducedMaterialItems($expand= DM_MaterialTrackingUnit($expand = MaterialTrackingUnit($select = code)))";
            return Get<WorkOrderDTO, WorkOrderDTOResponse>(urlProfile); 
        }

        public List<WorkOrderDTO> GetByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/WorkOrder?$expand=FinalMaterial($expand = Material),ProductionType($select= NId),WorkOrderOperations($expand=ToBeConsumedMaterials),SegregationTags, ProducedMaterialItems($expand= DM_MaterialTrackingUnit($expand = MaterialTrackingUnit($select = code)))&$filter=NId eq '{NId}'";
            return Get<WorkOrderDTO, WorkOrderDTOResponse>(urlProfile);
        }

        public List<WorkOrderOperationDTO> GetAllWorkOrderOperations()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/WorkOrderOperation?$count=true&$expand=WorkOrder,ToBeConsumedMaterials,ToBeUsedMachines,WorkOperationType,OperationStepCategoryId";
            return Get<WorkOrderOperationDTO, WorkOrderOperationDTOResponse>(urlProfile);
        }

        public List<WorkOrderOperationDTO> GetWorkOrderOperationsByOrderNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/WorkOrderOperation?$count=true&$expand=WorkOrder,ToBeConsumedMaterials,ToBeUsedMachines,WorkOperationType,OperationStepCategoryId&$filter=WorkOrder/NId eq '{NId}'";
            return Get<WorkOrderOperationDTO, WorkOrderOperationDTOResponse>(urlProfile);
        }
        public List<WorkOrderOperationDTO> GetWorkOrderOperationsByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/WorkOrderOperation?$count=true&$expand=WorkOrder,ToBeConsumedMaterials,ToBeUsedMachines,WorkOperationType,OperationStepCategoryId&$filter=NId eq '{NId}'";
            return Get<WorkOrderOperationDTO, WorkOrderOperationDTOResponse>(urlProfile);
        }

        public List<ToBeConsumedMaterialDTO> GetAllToBeConsumedMaterialDTO()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/ToBeConsumedMaterial?$count=true&$expand=WorkOrderOperation,MaterialDefinition";
            return Get<ToBeConsumedMaterialDTO, ToBeConsumedMaterialDTOResponse>(urlProfile);
        }
        public List<ToBeConsumedMaterialDTO> GetAllToBeConsumedMaterialDTOById(string Id)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/ToBeConsumedMaterial?$count=true&$expand=WorkOrderOperation,MaterialDefinition&$filter=WorkOrderOperation_Id eq {new Guid(Id)}";
            return Get<ToBeConsumedMaterialDTO, ToBeConsumedMaterialDTOResponse>(urlProfile);
        }

        public List<TemplateToMaterialPlantDTO> GetAllTemplateToMaterialPlant()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/TemplateToMaterialPlant?$expand=Template($expand=TemplateType),SegregationTags";
            return Get<TemplateToMaterialPlantDTO, TemplateToMaterialPlantDTOResponse>(urlProfile);
        }

        public List<WorkOOperationDependencyDTO> GetAllWorkOOperationDependency()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/WorkOOperationDependency?$count=true&$expand=FromWOO($expand=WorkOrder),ToWOO($expand=WorkOrder)";
            return Get<WorkOOperationDependencyDTO, WorkOOperationDependencyDTOResponse>(urlProfile);
        }
        public List<WorkOOperationDependencyDTO> GetAllWorkOOperationDependencyByToWOId(string Id)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/WorkOOperationDependency?$count=true&$expand=FromWOO($expand=WorkOrder),ToWOO($expand=WorkOrder)&$filter=ToWOO/Id eq '{Id}'";
            return Get<WorkOOperationDependencyDTO, WorkOOperationDependencyDTOResponse>(urlProfile);
        }
        public List<WorkOOperationDependencyDTO> GetAllWorkOOperationDependencyByFromWOId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/WorkOOperationDependency?$count=true&$expand=FromWOO($expand=WorkOrder),ToWOO($expand=WorkOrder)&$filter=FromWOO/NId eq '{NId}'";
            return Get<WorkOOperationDependencyDTO, WorkOOperationDependencyDTOResponse>(urlProfile);
        }





    }
}
