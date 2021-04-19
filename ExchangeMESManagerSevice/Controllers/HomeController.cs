using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExchangeMESManagerSevice.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data.Common;
using System.Data;
using System.Reflection;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Wmi;
using System.Management;
using ExchangeMESManagerSevice.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Text;
using System.IO;
using ExchangeMESManagerSevice.Models.AuthenticationModels;
using Newtonsoft.Json;
using System.Net.Http;
using ExchangeMESManagerSevice.Models.DTOModels;

namespace ExchangeMESManagerSevice.Controllers
{
    public class HomeController : Controller
    {
        ExchangeSettingsContext db;
        public HomeController(ExchangeSettingsContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            //Web Request OAuth2 перенести в библиотеку сервиса
            string grant_type = "password";
            string username = @"DMKIM\Shtolce";
            string password = "159753";

            

            HttpWebRequest webRequest = HttpWebRequest.Create("http://localhost/sit-auth/OAuth/Token") as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";


            string parameters =
                  "scope=global"
                + "&client_id=" + "RaytecIntegration"
                + "&client_secret=" + password
                + "&grant_type=" + grant_type
                + "&username=" + username
                + "&password=" + password;

            byte[] byteArray = Encoding.UTF8.GetBytes(parameters);
            webRequest.ContentLength = byteArray.Length;
            Stream postStream = webRequest.GetRequestStream();
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();
            WebResponse response = webRequest.GetResponse();
            postStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(postStream);
            string responseFromServer = reader.ReadToEnd();
            OAuthResponseModel serStatus = JsonConvert.DeserializeObject<OAuthResponseModel>(responseFromServer);
            //Получили токены, теперь исполним простой запрос на чтение материалов
            ///sit-svc/Application/Material/odata/Material?$top=24&$skip=0&$orderby=NId%20asc&$count=true HTTP/1.1
            //HttpWebRequest webRequest2 = HttpWebRequest.Create("http://localhost/sit-svc/Application/Material/odata/Material") as HttpWebRequest;
            HttpClient client = new HttpClient();
            var urlProfile = "http://localhost/sit-svc/Application/Material/odata/Material";
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + serStatus.access_token);
            client.CancelPendingRequests();
            var task = Task.Run(async ()=>await client.GetAsync(urlProfile));
            HttpResponseMessage output = task.Result;
            HttpContent stream = output.Content;
            var content = Task.Run(async () => await stream.ReadAsAsync<MaterialDTOResponse>());
            var res = content.Result;





            //------------------
            List<string> list = WMISevice.GetSQLInstances().ToList();
            SelectList listOptionRes = new SelectList(list,list[0]);
            return View(listOptionRes);
        }

    }
}
