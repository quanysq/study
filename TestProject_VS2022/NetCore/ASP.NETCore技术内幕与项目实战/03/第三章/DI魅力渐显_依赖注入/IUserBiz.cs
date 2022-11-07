namespace DI魅力渐显_依赖注入
{
    interface IUserBiz
    {
        /// <summary>
        /// 检查用户名、密码是否匹配
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckLogin(string userName, string password);
    }
}
