<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web003.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <% if (User.Identity.IsAuthenticated)
               {
                   Response.Write("<span style='color:red'>" + User.Identity.Name + "</span>已登录!");
                   if (User.IsInRole("管理员"))
                   {
                       Response.Write(" 当前用户角色：管理员");
                   }

                   if (User.IsInRole("会员"))
                   {
                       Response.Write("，会员。");
                   }

                   Response.Write(" <a href='logout.aspx'>安全退出</a>");
               }
               else
               {
                   Response.Write("请先<a href='login.aspx'>登录</a>");
               }
            %>
        </div>
    </form>
</body>
</html>
