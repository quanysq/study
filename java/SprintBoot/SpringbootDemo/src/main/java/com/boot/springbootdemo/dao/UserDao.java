package com.boot.springbootdemo.dao;

import com.boot.springbootdemo.entities.User;
import org.apache.ibatis.annotations.Mapper;

/**
 * @author jacky
 * @date 2023/3/23 10:30
 *
 * Dao接口类，用来对应mapper文件
 */
@Mapper
public interface UserDao {
    public User selectUserById(Integer userId);
}
