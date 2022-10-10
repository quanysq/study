using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwaggerTest.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ValuesController : ApiController
    {
        // GET api/values
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// 根据 ID 获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// 创建数据
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        /// <summary>
        /// 更新指定 id 的数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        /// <summary>
        /// 删除指定 id 的数据
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
        }
    }
}
