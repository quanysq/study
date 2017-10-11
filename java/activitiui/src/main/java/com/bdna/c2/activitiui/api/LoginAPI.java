package com.bdna.c2.activitiui.api;

import java.util.Base64;
import org.apache.log4j.Logger;

import com.bdna.c2.activitiui.bean.UserBean;
import com.bdna.c2.activitiui.util.HttpClientUtil;

public class LoginAPI {
	private static final Logger logger = Logger.getLogger(LoginAPI.class); 
	
	public static UserBean execute(String userName, String userPwd) throws Exception {
		logger.info("Starting to login activiti...");
		String url = "/activiti-rest/service/identity/users/" + userName;
		byte[] bytearr = (userName + ":" + userPwd).getBytes("UTF-8");
		String encoding = Base64.getEncoder().encodeToString(bytearr);
		String auth = "Basic " + encoding;
		UserBean userBean = HttpClientUtil.httpGet(url, auth, UserBean.class, true);
		userBean.setBasicAuth(auth);
		logger.info("Login activiti successfully...");
		return userBean;
	}
}
