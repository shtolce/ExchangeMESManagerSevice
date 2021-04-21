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
    public class HttpAsPlannedBOPRepository
    {
        private AuthorizationMesService _authService;

        public HttpAsPlannedBOPRepository(IHostedService authService)
        {
            _authService = (AuthorizationMesService)authService;
        }

        public AsPlannedBOPDTOResponse DeleteAsPlannedBOP(AsPlannedBOPDTODeleteParameter com)
        {
            return ExecuteCommand<AsPlannedBOPDTODeleteParameter, AsPlannedBOPDTOResponse>(com, "DeleteAsPlannedBOP"); ;
        }

        public AsPlannedBOPDTOResponse CreateAsPlannedBOP(AsPlannedBOPDTOCreateParameter com)
        {
            return ExecuteCommand<AsPlannedBOPDTOCreateParameter, AsPlannedBOPDTOResponse>(com, "CreateAsPlannedBOP"); ;
        }
        /// <summary>
        /// Не используется
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public AsPlannedBOPDTOResponse UpdateAsPlannedBOP(AsPlannedBOPDTOUpdateParameter com)
        {
            return ExecuteCommand<AsPlannedBOPDTOUpdateParameter, AsPlannedBOPDTOResponse>(com, "UpdateAsPlannedBOP");
        }

        public ProcessesDTOResponse CreateProcess(ProcessesDTOCreateParameter com)
        {
            return ExecuteCommand<ProcessesDTOCreateParameter, ProcessesDTOResponse>(com, "UADMCreateProcess"); ;
        }
        public ProcessesDTOResponse UpdateProcess(ProcessesDTOUpdateParameter com)
        {
            return ExecuteCommand<ProcessesDTOUpdateParameter, ProcessesDTOResponse>(com, "UADMUpdateProcess"); ;
        }
        public ProcessesDTOResponse DeleteProcess(ProcessesDTODeleteParameter com)
        {
            return ExecuteCommand<ProcessesDTODeleteParameter, ProcessesDTOResponse>(com, "DeleteProcessFromCatalogue"); ;
        }

        

        private D ExecuteCommand<T,D>(T com,string commandName)
        {
            HttpWebRequest webRequest = HttpWebRequest.Create($"http://localhost/sit-svc/Application/AppU4DM/odata/{commandName}") as HttpWebRequest;
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

        public List<AsPlannedBOPDTO> Get(string urlProfile)
        {
            HttpClient client = new HttpClient();

            if (_authService.StateOAuth == null)
            {
                return new List<AsPlannedBOPDTO>();
            }
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _authService.StateOAuth.access_token);
            client.CancelPendingRequests();
            var task = Task.Run(async () => await client.GetAsync(urlProfile));
            HttpResponseMessage output = task.Result;
            HttpContent stream = output.Content;
            var content = Task.Run(async () => await stream.ReadAsAsync<AsPlannedBOPDTOResponse>());
            var res = content.Result;
            return res.value;

        }
        ///sit-svc/Application/AppU4DM/odata/AsPlannedBOP?$count=true&$filter=Processes/any()&$expand=Processes($expand=FinalMaterialId($expand=Material($select=NId));$select=Id,Name,Revision,NId,UId,Plant,Quantity),SegregationTags

        public List<AsPlannedBOPDTO> GetAll()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/AsPlannedBOP?$count=true&$filter=Processes/any()&$expand=Processes($expand=FinalMaterialId($expand=Material($select=NId)))";
            return Get(urlProfile);
        }

        //Сделать фильтр через ODATA
        public List<AsPlannedBOPDTO> GetByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/AsPlannedBOP?$count=true&$filter=BaseLineName eq '{NId}' & Processes/any()&$expand=Processes($expand=FinalMaterialId($expand=Material($select=NId)))";
            return Get(urlProfile);
        }



    }
}
