package com.bdna.c2.activitiui.mvc;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

import com.bdna.c2.activitiui.api.LoginAPI;
import com.bdna.c2.activitiui.bean.UserBean;

@Controller
@RequestMapping("/")
public class LoginController {
	@RequestMapping(value="login", method= RequestMethod.GET)
	@ResponseBody
	public UserBean Login(String userName, String userPwd) {
		UserBean userBean = null;
		try {
			userBean = LoginAPI.execute(userName, userPwd);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return userBean;
	}
}
