package com.boot.springbootdemo.controller;

import com.boot.springbootdemo.entities.User;
import com.boot.springbootdemo.services.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;

/**
 * @author jacky
 * @date 2023/3/23 15:22
 */
@Controller
@RequestMapping("/user")
public class UserController {
    @Autowired
    private UserService userService;

    @RequestMapping(value="")
    public String getIndex(Model model){
        User user = userService.selectUserById(1);
        model.addAttribute("user", user);
        return "index";
    }
}
