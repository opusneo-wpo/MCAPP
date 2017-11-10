using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkplaceON.Modules.Login.Models
{
    public class LoginItems
    {
        public string Location { get; set; }

        public string Cookies { get; set; }

        public string  Headers{ get; set; }

        public bool Done { get; set; }

        public string UserName { get; set; }
    }
}
