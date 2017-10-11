package com.bdna.c2.activitiui.bean;

public class UserBean {
	private String id;
	private String firstName;
	private String lastName;
	private String url;
	private String email;
	private String pictureUrl;
	private String basicAuth;
	
	public UserBean() {
		
	}
	
	public String getId() {
		return id;
	}
	
	public void setId(String id) {
		this.id = id;
	}
	
	public String getFirstName() {
		return firstName;
	}
	
	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}
	
	public String getLastName() {
		return lastName;
	}
	
	public String getUrl() {
		return url;
	}
	
	public void setUrl(String url) {
		this.url = url;
	}
	
	public String getEmail() {
		return email;
	}
	
	public void setEmail(String email) {
		this.email = email;
	}
	
	public String getPictureUrl() {
		return pictureUrl;
	}
	
	public void setPictureUrl(String pictureUrl) {
		this.pictureUrl = pictureUrl;
	}
	
	public String getBasicAuth() {
		return basicAuth;
	}
	
	public void setBasicAuth(String basicAuth) {
		this.basicAuth = basicAuth;
	}
}
