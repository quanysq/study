using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace ExtSampleMvc.Helper
{
    public class MyFunction
    {
        public static JObject WriteJObjectResult(bool success, JObject errors)
        {
            JObject jo = new JObject {
                new JProperty("success",success)
            };
            if (errors != null && errors.HasValues)
            {
                jo.Add(new JProperty("errors", errors));
            }
            return jo;
        }

        public static void ModelStateToJObject(ModelStateDictionary ModelState, JObject errors)
        {
            foreach (var c in ModelState.Keys)
            {
                if (!ModelState.IsValidField(c))
                {
                    string errStr = "";
                    foreach (var err in ModelState[c].Errors)
                    {
                        errStr += err.ErrorMessage + "<br/>";
                    }
                    errors.Add(new JProperty(c, errStr));
                }
            }
        }
    }
}