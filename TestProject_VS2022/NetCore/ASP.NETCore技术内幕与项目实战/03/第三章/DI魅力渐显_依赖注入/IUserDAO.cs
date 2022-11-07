namespace DI魅力渐显_依赖注入
{
    interface IUserDAO
    {
        /// <summary>
        /// 查询用户名为userName的用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User? GetByUserName(string userName);
    }
}
