using MVCExample.BLL.IService;
using MVCExample.DAL;
using MVCExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExample.BLL.Service
{
    public class HTFP14Service : BaseRepository<HTFP14>, IHTFP14Service
    {
        public ResponseResult ValidateLogin(HTFP14 hTFP14)
        {
            ResponseResult result = new ResponseResult();
            //查询用户信息
            var model = Query(a => a.COMPHT14 == hTFP14.COMPHT14);
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