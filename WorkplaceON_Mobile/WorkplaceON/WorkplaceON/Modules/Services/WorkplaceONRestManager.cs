using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceON.Modules.Login.Models;

namespace WorkplaceON.Modules.Services
{

    public class WorkplaceONRestManager
    {
        IRestService restService;
        public WorkplaceONRestManager(IRestService service)
        {
            restService = service;
        }
        public Task<List<LoginItems>> GetLoginData(string username, string password)
        {
            return restService.LoginDataAsync(username, password);
        }

        public Task<List<LoginItems>> EnterPINLoginDataAsync(string authToken)
        {
            return restService.EnterPINLoginDataAsync(authToken);
        }


    }
}
