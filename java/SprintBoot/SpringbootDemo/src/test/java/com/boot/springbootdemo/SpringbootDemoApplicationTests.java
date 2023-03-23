package com.boot.springbootdemo;

import com.boot.springbootdemo.entities.User;
import com.boot.springbootdemo.services.UserService;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

@SpringBootTest
class SpringbootDemoApplicationTests {

    @Autowired
    private UserService userService;

    @Test
    public void selectUserByIdTest() {
        Logger logger = LoggerFactory.getLogger(this.getClass());

        User user = userService.selectUserById(10);
        System.out.println(user.toString());
        String msg = "Result: " + user;
        logger.info(msg);
    }

}
