using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefitSample
{
    public interface IUserApi
    {
        [Get("/prod-api/report/comList")]
        Task<User> GetUserList();
    }

    public class User
    {
        public int total {  get; set; }
    }
}
