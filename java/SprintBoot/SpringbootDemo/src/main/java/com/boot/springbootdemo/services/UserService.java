package com.boot.springbootdemo.services;

import com.boot.springbootdemo.entities.User;

/**
 * @author jacky
 * @date 2023/3/23 10:37
 *
 * service接口类和实现类
 */
public interface UserService {
    User selectUserById(Integer userId);
}
