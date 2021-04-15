using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeMESManagerSevice.Models
{
    public class ExchangeSettings
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string SQLServerInstance { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }

    }
}
