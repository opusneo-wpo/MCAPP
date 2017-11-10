using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WorkplaceON.Modules.Login.Models
{
    public class UserInfo
    {
	    public static CookieContainer CookieContainer = new CookieContainer();
        public static String locationUrl = "";

        [PrimaryKey]
        public string UserName
        { get; set; }
        
        public string AuthToken
        { get; set; }
        public string PIN
        { get; set; }
        public string DeviceId
        { get; set; }       
    }
}
