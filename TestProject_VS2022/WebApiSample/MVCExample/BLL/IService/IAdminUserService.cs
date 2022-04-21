using MVCExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.BLL.IService
{
    public interface IAdminUserService
    {
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="adminUser"></param>
        /// <returns></returns>
        ResponseResult ValidateLogin(AdminUser adminUser);
    }
}
