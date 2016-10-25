<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web002.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Login</title>
</head>
<body>
  <form id="form1" runat="server">
    <table>
      <tr>
        <td>用户名：</td>
        <td>
          <asp:TextBox ID="txtUserName" runat="server" Style="width: 200px"></asp:TextBox></td>
      </tr>
      <tr>
        <td>密  码：</td>
        <td>
          <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Style="width: 200px"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td></td>
        <td>
          <asp:Button ID="Button1" runat="server" Text="登 录" OnClick="Button1_Click" />
        </td>
      </tr>
    </table>
  </form>
</body>
</html>
