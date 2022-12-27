﻿using System.Data;

namespace DI魅力渐显_依赖注入
{
    class UserDAO : IUserDAO
    {
        private readonly IDbConnection conn;

        // 通过构造方法要求依赖注入容器为其注入一个IDbConnection对象
        public UserDAO(IDbConnection conn)
        {
            this.conn = conn;
        }

        public User? GetByUserName(string userName)
        {
            using var dt = SqlHelper.ExecuteQuery(conn, $"select * from T_Users where UserName={userName}");
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            DataRow row = dt.Rows[0];
            int id = (int)row["Id"];
            string uname = (string)row["UserName"];
            string password = (string)row["Password"];
            return new User(id, uname, password);
        }
    }
}
