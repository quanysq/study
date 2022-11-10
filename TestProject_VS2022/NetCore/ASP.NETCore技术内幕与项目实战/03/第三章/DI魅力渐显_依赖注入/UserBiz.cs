﻿namespace DI魅力渐显_依赖注入
{
    class UserBiz : IUserBiz
    {
        private readonly IUserDAO userDAO;

        public UserBiz(IUserDAO userDAO)
        {
            this.userDAO = userDAO;
        }

        public bool CheckLogin(string userName, string password)
        {
            var user = userDAO.GetByUserName(userName);
            if (user == null)
            {
                return false;
            }
            else
            {
                return user.Password == password;
            }
        }
    }
}
