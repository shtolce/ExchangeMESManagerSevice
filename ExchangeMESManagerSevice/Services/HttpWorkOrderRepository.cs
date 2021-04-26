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

        public WorkOrderDTOResponse Delete(WorkOrderDTODeleteParameter com)
        {
            return ExecuteCommand<WorkOrderDTODeleteParameter, WorkOrderDTOResponse>(com, "DeleteWorkOrder"); ;
        }

        public WorkOrderDTOResponse Create(WorkOrderDTOCreateParameter com)
        {
            return ExecuteCommand<WorkOrderDTOCreateParameter, WorkOrderDTOResponse>(com, "CreateWorkOrder"); ;
        }
        public WorkOrderDTOResponse Update(WorkOrderDTOUpdateParameter com)
        {
            return ExecuteCommand<WorkOrderDTOUpdateParameter, WorkOrderDTOResponse>(com, "UpdateWorkOrder");
        }

        public BoMDTOResponse CreateBoM(BoMDTOCreateParameter com)
        {
            return ExecuteCommand<BoMDTOCreateParameter, BoMDTOResponse>(com, "DSWorkOrder_CreateBoM"); ;
        }

        public BoMItemDTOResponse CreateBoMItem(BoMItemDTOCreateParameter com)
        {
            return ExecuteCommand<BoMItemDTOCreateParameter, BoMItemDTOResponse>(com, "CreateBoMItem", "AppU4DM"); ;
        }
        public BoMItemDTOResponse DeleteBoMItemList(BoMItemDTODeleteParameter com)
        {
            return ExecuteCommand<BoMItemDTODeleteParameter, BoMItemDTOResponse>(com, "DeleteBoMItemList", "AppU4DM"); ;
        }
        

        public BoMDTOResponse ChangeBoMStatus(WorkOrderDTOCreateParameter com)
        {
            return ExecuteCommand<WorkOrderDTOCreateParameter, BoMDTOResponse>(com, "DSWorkOrder_ChangeBoMStatus"); ;
        }




        private D ExecuteCommand<T, D>(T com, string commandName,string AppName="WorkOrder")
        {
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
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/WorkOrder?$expand=FinalMaterial($expand = Material),ProductionType($select= NId),WorkOrderOperations,SegregationTags, ProducedMaterialItems($expand= DM_MaterialTrackingUnit($expand = MaterialTrackingUnit($select = code)))";
            return Get<WorkOrderDTO, WorkOrderDTOResponse>(urlProfile); 
        }

        //Сделать фильтр через ODATA
        public List<WorkOrderDTO> GetByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/WorkOrder?$expand=FinalMaterial($expand = Material),ProductionType($select= NId),WorkOrderOperations,SegregationTags, ProducedMaterialItems($expand= DM_MaterialTrackingUnit($expand = MaterialTrackingUnit($select = code)))&$filter=NId eq '{NId}'";
            return Get<WorkOrderDTO, WorkOrderDTOResponse>(urlProfile);
        }

        public List<WorkOrderOperationDTO> GetAllWorkOrderOperations()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/WorkOrderOperation?$count=true&$expand=WorkOrder,ToBeUsedMachines,WorkOperationType,OperationStepCategoryId";
            return Get<WorkOrderOperationDTO, WorkOrderOperationDTOResponse>(urlProfile);
        }

        //Сделать фильтр через ODATA
        public List<WorkOrderOperationDTO> GetGetWorkOrderOperationsByOrderNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/WorkOrderOperation?$count=true&$expand=WorkOrder,ToBeUsedMachines,WorkOperationType,OperationStepCategoryId&$filter=WorkOrder/NId eq '{NId}'";
            return Get<WorkOrderOperationDTO, WorkOrderOperationDTOResponse>(urlProfile);
        }


    }
}
