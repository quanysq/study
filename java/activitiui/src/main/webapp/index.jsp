<%@page import="com.bdna.c2.activitiui.util.PropertyUtil"%>
<%@page import="com.bdna.c2.activitiui.api.LoginAPI"%>
<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>Spring MVC and Ajax</title>
	<script src="https://unpkg.com/axios/dist/axios.min.js"></script>
</head>
<body>
	<div>
		<input type="button" value="Return Json" onclick="ajaxTestForJson();" />
	</div>
</body>

<script>
	function ajaxTestForJson() {
		var url = "${pageContext.request.contextPath}/login.json";
		console.log(url);
		axios.get(url, { "params": { "userName": "kermit", "userPwd": "kermit" }})
		.then(function (response) {
	    	console.log(response);
	  	})
		.catch(function (error){
			alert(error);
		});
	}
</script>
</html>
