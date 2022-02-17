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
    public class HttpBufferRepository
    {
        private AuthorizationMesService _authService;

        public HttpBufferRepository(IHostedService authService)
        {
            _authService = (AuthorizationMesService)authService;
        }

        public BufferDTOResponse Delete(BufferDTODeleteParameter com)
        {
            return ExecuteCommand<BufferDTODeleteParameter, BufferDTOResponse>(com, "DeleteBuffer"); ;
        }

        public BufferDTOResponse Create(BufferDTOCreateParameter com)
        {
            return ExecuteCommand<BufferDTOCreateParameter, BufferDTOResponse>(com, "CreateBuffer"); ;
        }

        public BufferDefinitionDTOResponse CreateBufferDefinition(BufferDefinitionDTOCreateParameter com)
        {
            return ExecuteCommand<BufferDefinitionDTOCreateParameter, BufferDefinitionDTOResponse>(com, "CreateBufferDefinition"); ;
        }

        public BufferDefinitionDTOResponse DeleteBufferDefinition(BufferDefinitionDTODeleteParameter com)
        {
            return ExecuteCommand<BufferDefinitionDTODeleteParameter, BufferDefinitionDTOResponse>(com, "DeleteBufferDefinition"); ;
        }

        private D ExecuteCommand<T, D>(T com, string commandName, string AppName = "AppU4DM")
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
                if (ex.Response == null)
                    return null;

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



        public BufferDTOResponse Update(BufferDTOUpdateParameter com)
        {
            return ExecuteCommand<BufferDTOUpdateParameter, BufferDTOResponse>(com, "UpdateBuffer");
        }

        public List<BufferDTO> Get(string urlProfile)
        {
            HttpClient client = new HttpClient();

            if (_authService.StateOAuth == null)
            {
                return new List<BufferDTO>();
            }
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _authService.StateOAuth.access_token);
            client.CancelPendingRequests();
            var task = Task.Run(async () => await client.GetAsync(urlProfile));
            HttpResponseMessage output = task.Result;
            HttpContent stream = output.Content;
            var content = Task.Run(async () => await stream.ReadAsAsync<BufferDTOResponse>());
            var res = content.Result;
            return res.value;

        }


        public List<BufferDTO> GetAll()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/Buffer?$expand=BufferDefinition,CapacityType";
            return Get(urlProfile);
        }

        //Сделать фильтр через ODATA
        public List<BufferDTO> GetByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/Buffer?$expand=BufferDefinition,CapacityType&$filter=NId eq '{NId}'";
            return Get(urlProfile);
        }

        public List<BufferDTO> GetAllBufferDefinitions()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/BufferDefinition?$count=true&$expand=CapacityType";
            return Get(urlProfile);
        }
        public List<BufferDTO> GetAllBufferDefinitionsByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/BufferDefinition?$count=true&$expand=CapacityType&$filter=NId eq '{NId}'";
            return Get(urlProfile);
        }




    }
}
