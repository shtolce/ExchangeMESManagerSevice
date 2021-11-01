using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExchangeMESManagerSevice.Models.CommandModels;
using ExchangeMESManagerSevice.Models.DTOModels;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Services
{
    public class HttpDMMaterialsRepository
    {
        private AuthorizationMesService _authService;

        public HttpDMMaterialsRepository(IHostedService authService)
        {
            _authService = (AuthorizationMesService)authService;
        }

        public DMMaterialDTOResponse Delete(DMMaterialDTODeleteParameter com)
        {
            return ExecuteCommand<DMMaterialDTODeleteParameter>(com, "DSMaterial_UADMDeleteDM_Material"); ;
        }

        public DMMaterialDTOResponse Create(DMMaterialDTOCreateParameter com)
        {
            return ExecuteCommand<DMMaterialDTOCreateParameter>(com, "DSMaterial_UADMCreateDM_Material");
        }

        private DMMaterialDTOResponse ExecuteCommand<T>(T com, string commandName)
        {
            if (_authService.StateOAuth == null)
                return null;

            HttpWebRequest webRequest = HttpWebRequest.Create($"http://localhost/sit-svc/Application/Material/odata/{commandName}") as HttpWebRequest;
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
                    var serStatusErr = JsonConvert.DeserializeObject<DMMaterialDTOResponse>(testErr);
                    return serStatusErr;

                }

            }
            postStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(postStream);
            string responseFromServer = reader.ReadToEnd();
            var serStatus2 = JsonConvert.DeserializeObject<DMMaterialDTOResponse>(responseFromServer);
            postStream.Close();
            return serStatus2;
        }


        public DMMaterialDTOResponse Update(DMMaterialDTOUpdateParameter com)
        {
            return ExecuteCommand<DMMaterialDTOUpdateParameter>(com, "DSMaterial_UADMUpdateDM_Material");
        }

        public List<DMMaterialDTO> Get(string urlProfile)
        {
            HttpClient client = new HttpClient();
            if (_authService.StateOAuth == null)
            {
                return new List<DMMaterialDTO>();
            }
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _authService.StateOAuth.access_token);
            client.CancelPendingRequests();
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var task = Task.Run(async () => await client.GetAsync(urlProfile));
            HttpResponseMessage output = task.Result;
            HttpContent stream = output.Content;
            var content = Task.Run(async () => await stream.ReadAsAsync<DMMaterialDTOResponse>());
            var res = content.Result;
            return res.value;



        }

        public List<DMMaterialDTO> GetAll()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/DM_Material?$expand=Material";
            return Get(urlProfile);
        }

        //Сделать фильтр через ODATA
        public List<DMMaterialDTO> GetByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/DM_Material?$expand=Material,SegregationTags&$filter=Material/NId eq '{NId}'";
            return Get(urlProfile);
        }



    }
}
