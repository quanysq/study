<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="Web001.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>测试 Javascript 内存管理</title>
    <script src="/Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Testing
    </div>
    </form>
    <script lang="text/javascript">
        //------     使用内存段 
        /*alert("Start...");
        for (var i = 0; i < 100000; i++) {
            eval("a" + i + "= new Array();");
            
        }
        alert("OK");
        //--------释放内存段 
        for (var i = 0; i < 100000; i++) {
            eval("a" + i + "=   null;");
        }*/
        console.log(!1);
        console.log(!0);
        
        function CallService()
        {
            $.ajax({
                type: "POST",
                url: "/Webservice/WebService1.asmx/HelloWorld",
                dataType: "xml",
                data: {},
                success: function (data) {
                    alert(data);
                    console.log(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Get a error!");
                    console.log("XMLHttpRequest.responseText: " + XMLHttpRequest.responseText);
                    alertconsole.log("XMLHttpRequest.status: " + XMLHttpRequest.status);
                    console.log("XMLHttpRequest.readyState: " + XMLHttpRequest.readyState);
                    console.log("textStatus: " + textStatus);
                },
                complete: function (XMLHttpRequest, textStatus) {
                    console.log("Operation has completed!");
                }
            });
        }
        var refreshStatusTimeout = null;
        var refreshStatus = function refreshProcessStatus() {
            try {
                CallService();
            }
            catch (e) {

            }
            finally {
                //refreshStatusTimeout == null;
                //clearTimeout(refreshStatusTimeout);
                //refreshStatusTimeout = setTimeout(function () { refreshProcessStatus(); }, 500);
            }
        }

        refreshStatus();
    </script> 
</body>
</html>
