using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceON.Modules.Login.Models;

namespace WorkplaceON.Modules.Services
{
    public interface IRestService
    {
        Task<List<LoginItems>> LoginDataAsync(string UserName, string PassWord);
        Task<List<LoginItems>> EnterPINLoginDataAsync(string arg);
        //Task SaveTodoItemAsync(TodoItem item, bool isNewItem);

        //Task DeleteTodoItemAsync(string id);
    }
}
