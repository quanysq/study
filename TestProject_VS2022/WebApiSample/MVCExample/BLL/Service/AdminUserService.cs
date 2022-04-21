using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCExample.BLL.IService;
using MVCExample.DAL;
using MVCExample.Models;

namespace MVCExample.BLL.Service
{
    public class AdminUserService: BaseRepository<AdminUser>, IAdminUserService
    {
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="adminUser"></param>
        /// <returns></returns>
        public ResponseResult ValidateLogin(AdminUser adminUser)
        {
            ResponseResult result = new ResponseResult();
            //查询用户信息
            var model = Query(a => a.Name == adminUser.Name && a.Password == adminUser.Password);
            //如果用户信息不为空
            if (model != null)
            {
                result.code = 1;
                result.data = model;
                result.msg = "登录成功";
                result.success = true;
            }
            else
            {
                result.code = 0;
                result.msg = "用户名或密码错误";
                result.success = false;
            }
            return result;
        }
    }
}