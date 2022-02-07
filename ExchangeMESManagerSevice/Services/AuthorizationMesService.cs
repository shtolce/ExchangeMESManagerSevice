using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExchangeMESManagerSevice.Models.AuthenticationModels;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Services
{
    public class AuthorizationMesService : BackgroundService
    {
        public OAuthResponseModel StateOAuth { get; set; }
        private Timer _timer;
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(getAuthorization, null, TimeSpan.Zero,
                        TimeSpan.FromSeconds(StateOAuth == null ? 10: StateOAuth.expiresSec));
            return Task.CompletedTask;
        }

        private void getAuthorization(object state)
        {
            //Web Request OAuth2 перенести в библиотеку сервиса
            string grant_type = "password";
            string username = @"shtolce";
            string password = "berkut555676";

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
            StateOAuth = serStatus;
            AuthStateHelper.AuthState = serStatus==null?false:true;
            var test = TimeSpan.FromSeconds(StateOAuth == null ? 10 : StateOAuth.expiresSec);
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            _timer.Change(test, test);
        }


    }
}
