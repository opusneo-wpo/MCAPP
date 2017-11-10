using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkplaceON.Modules.Login.Models
{
    class Regisration
    {
        public string username { get; set; }
        public string apiKey { get; set; }
        public int clientId { get; set; }
        public string packageName { get; set; }
        public string registrationToken { get; set; }
        public int deviceId { get; set; }
        public string group { get; set; }
        public string platform { get; set; }
    }
}
