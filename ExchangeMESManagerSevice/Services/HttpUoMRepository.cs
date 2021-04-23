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
    public class HttpUoMRepository
    {
        private AuthorizationMesService _authService;

        public HttpUoMRepository(IHostedService authService)
        {
            _authService = (AuthorizationMesService)authService;
        }

        public UoMDTOResponse Delete(UoMDTODeleteParameter com)
        {
            return ExecuteCommand<UoMDTODeleteParameter>(com, "DeleteBaseUoM"); ;
        }

        public UoMDTOResponse Create(UoMDTOCreateParameter com)
        {
            return ExecuteCommand<UoMDTOCreateParameter>(com, "CreateBaseUoM"); ;
        }

        private UoMDTOResponse ExecuteCommand<T>(T com,string commandName)
        {
            HttpWebRequest webRequest = HttpWebRequest.Create($"http://localhost/sit-svc/Application/Reference/odata/{commandName}") as HttpWebRequest;
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
                    var serStatusErr = JsonConvert.DeserializeObject<UoMDTOResponse>(testErr);
                    return serStatusErr;

                }

            }
            postStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(postStream);
            string responseFromServer = reader.ReadToEnd();
            var serStatus2 = JsonConvert.DeserializeObject<UoMDTOResponse>(responseFromServer);
            return serStatus2;
        }


        public UoMDTOResponse Update(UoMDTOUpdateParameter com)
        {
            return ExecuteCommand<UoMDTOUpdateParameter>(com, "UpdateUoM");
        }

        public List<UoMDTO> Get(string urlProfile)
        {
            HttpClient client = new HttpClient();

            if (_authService.StateOAuth == null)
            {
                return new List<UoMDTO>();
            }
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _authService.StateOAuth.access_token);
            client.CancelPendingRequests();
            var task = Task.Run(async () => await client.GetAsync(urlProfile));
            HttpResponseMessage output = task.Result;
            HttpContent stream = output.Content;
            var content = Task.Run(async () => await stream.ReadAsAsync<UoMDTOResponse>());
            var res = content.Result;
            return res.value;

        }

        public List<UoMDTO> GetAll()
        {
            var urlProfile = "http://localhost/sit-svc/Application/Reference/odata/UoM?$expand=UoMDimension($select=Name)&$orderby=NId asc";
            return Get(urlProfile);
        }

        public List<UoMDTO> GetByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/Reference/odata/UoM?$filter=NId eq '{NId}'&$expand=UoMDimension($select=Name)";
            return Get(urlProfile);
        }

        public List<UoMDTO> GetById(string Id)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/Reference/odata/UoM?$filter=Id eq '{Id}'&$expand=UoMDimension($select=Name)";
            return Get(urlProfile);
        }


    }
}
