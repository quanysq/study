<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Web001.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AJAX</title>
    <script src="/Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
      <div>
        <input type="button" id="CallAPIBtn" value="Call Restful API" />
      </div>
    </form>
    <script type="text/javascript">
      $("#CallAPIBtn").click(function () {
        alert("I will call http://124.42.240.97:11000/job-rest-service/job/");

        $.ajax({
          type: "POST",
          url: "/Webservice/Service1.svc/TestCall",
          dataType: "json",
          data: { },
          headers: {
            "license": "e202b6dfc1ba5b3d1ea8f75fb69e3a3019e84658",
            "job-name": "Jacky_vSphere_Test"
          },
          success: function (data) {
            alert("Successful!");
            alert("The result is: " + data["d"]);
          },
          error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Get a error!");
            alert("XMLHttpRequest.responseText: " + XMLHttpRequest.responseText);
            alert("XMLHttpRequest.status: " + XMLHttpRequest.status);
            alert("XMLHttpRequest.readyState: " + XMLHttpRequest.readyState);
            alert("textStatus: " + textStatus);
          },
          complete: function (XMLHttpRequest, textStatus) {
            alert("Operation has completed!");
          }
        });
      });
    </script>

    <!--
      1. AJAX程序正确
      2. 呼叫http://124.42.240.97:11000/job-rest-service/job/有跨域的问题，需要API端配合进行处理
      3. 呼叫同域名下的/Webservice/Service1.svc/TestCall正常返回数据
    -->
</body>
</html>
