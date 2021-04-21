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
    public class HttpEquipmentRepository
    {
        private AuthorizationMesService _authService;

        public HttpEquipmentRepository(IHostedService authService)
        {
            _authService = (AuthorizationMesService)authService;
        }

        public EquipmentDTOResponse DeleteEquipment(EquipmentDTODeleteParameter com)
        {
            return ExecuteCommand<EquipmentDTODeleteParameter>(com, "DeleteEquipment"); ;
        }

        public EquipmentDTOResponse CreateEquipment(EquipmentDTOCreateParameter com)
        {
            return ExecuteCommand<EquipmentDTOCreateParameter>(com, "CreateEquipment"); ;
        }

        private EquipmentDTOResponse ExecuteCommand<T>(T com,string commandName)
        {
            HttpWebRequest webRequest = HttpWebRequest.Create($"http://localhost/sit-svc/Application/Equipment/odata/{commandName}") as HttpWebRequest;
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
                    var serStatusErr = JsonConvert.DeserializeObject<EquipmentDTOResponse>(testErr);
                    return serStatusErr;

                }

            }
            postStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(postStream);
            string responseFromServer = reader.ReadToEnd();
            var serStatus2 = JsonConvert.DeserializeObject<EquipmentDTOResponse>(responseFromServer);
            return serStatus2;
        }


        public EquipmentDTOResponse UpdateEquipment(EquipmentDTOUpdateParameter com)
        {
            return ExecuteCommand<EquipmentDTOUpdateParameter>(com, "UpdateEquipment");
        }

        public List<EquipmentDTO> Get(string urlProfile)
        {
            HttpClient client = new HttpClient();

            if (_authService.StateOAuth == null)
            {
                return new List<EquipmentDTO>();
            }
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _authService.StateOAuth.access_token);
            client.CancelPendingRequests();
            var task = Task.Run(async () => await client.GetAsync(urlProfile));
            HttpResponseMessage output = task.Result;
            HttpContent stream = output.Content;
            var content = Task.Run(async () => await stream.ReadAsAsync<EquipmentDTOResponse>());
            var res = content.Result;
            return res.value;

        }


        public List<EquipmentDTO> GetAll()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/Equipment";
            return Get(urlProfile);
        }

        //Сделать фильтр через ODATA
        public List<EquipmentDTO> GetByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/Equipment?$filter=NId eq '{NId}'";
            return Get(urlProfile);
        }



    }
}
