using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeMESManagerSevice.Models.AuthenticationModels
{
    public class OAuthResponseModel
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expiresSec { get; set; }
        public int expires_in;



    }
}
