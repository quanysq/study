package com.boot.springbootdemo.controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * @author jacky
 * @date 2023/3/22 22:30
 */
@RestController
@RequestMapping("/hello")
public class HelloController {

    @RequestMapping("/world")
    public String helloWorld(){
        return "Hello World!";
    }
}
