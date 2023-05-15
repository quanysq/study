using ExtSampleMvc.Helper;
using ExtSampleMvc.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExtSampleMvc.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public JObject Login(LoginModel model)
        {
            bool success = false;
            JObject errors = new JObject();
            if (ModelState.IsValid)
            {
                string vcode = "";
                if (Session["vcode"] != null)
                {
                    vcode = Session["vcode"].ToString();
                }
                if (vcode.Count() > 0 && vcode.ToLower() == model.Vcode.ToLower())
                {
                    if (model.UserName.ToLower() == "admin" && model.Password == "123456")
                    {
                        success = true;
                    }
                    else
                    {
                        errors.Add("UserName", "错误的用户名或密码。");
                        errors.Add("Password", "错误的用户名或密码。");
                    }
                }
                else
                {
                    errors.Add("Vcode", "验证码错误");
                }
            }
            else
            {
                MyFunction.ModelStateToJObject(ModelState, errors);
            }
            return MyFunction.WriteJObjectResult(success, errors);
        }
    }
}