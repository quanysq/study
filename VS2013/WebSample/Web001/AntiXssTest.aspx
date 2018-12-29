<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AntiXssTest.aspx.cs" Inherits="Web001.AntiXssTest" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <textarea id="txtParam" runat="server" style="width: 90%; height: 200px;"></textarea>
        <br />
        <br />
        <input type="button" id="btnOK" runat="server" value="OK" />
    </div>
    </form>
</body>
</html>
