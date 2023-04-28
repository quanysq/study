package com.boot.springbootdemo.services;

import com.boot.springbootdemo.dao.UserDao;
import com.boot.springbootdemo.entities.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 * @author jacky
 * @date 2023/3/23 10:38
 *
 * 实现 UserService
 */
@Service
public class UserServiceImpl implements UserService{
    // 依赖注入 UserDao
    @Autowired
    private UserDao userDao;

    @Override
    public User selectUserById(Integer userId) {
        return userDao.selectUserById(userId);
    }
}
