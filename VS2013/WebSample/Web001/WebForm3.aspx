<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Web001.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>jQuery国际化</title>
  <script type="text/javascript" src="/Web001/Scripts/jquery-1.10.2.min.js"></script>
  <script type="text/javascript" src="/Web001/Scripts/jquery.i18n.properties-1.0.9.js"></script>
</head>
<body>
  <form id="form1" runat="server">

    <div>
      <a href="WebForm3.aspx?language=zh">中文版</a>
      <a href="WebForm3.aspx?language=en">英文版</a>
    </div>

    <hr />

    <div id="content">
      <table>
        <tr>
          <td>
            <label id="label_username"></label>
          </td>
          <td>
            <input type="text" id="username" />
          </td>
        </tr>
        <tr>
          <td>
            <label id="label_password"></label>
          </td>
          <td>
            <input type="password" id="password" />
          </td>
        </tr>
        <tr>
          <td></td>
          <td><input type="button" id="button_login" /></td>
        </tr>
      </table>
    </div>

  </form>

  <script type="text/javascript">
    $(function () {
      var _language = getUrlParam("language");
      if (_language == null) _language = "zh";
      console.log(_language);

      jQuery.i18n.properties({
        name: 'strings', //资源文件名称
        path: '/Web001/i18n/', //资源文件路径
        mode: 'both', //用Map的方式使用资源文件中的值
        language: _language,
        callback: function () {//加载成功后设置显示内容
          var s = jQuery.i18n.prop('UserName');
          console.log("UserName is ["+ s +"]");
          $('#button_login').val($.i18n.prop('Login'));
          $('#label_username').html($.i18n.prop('UserName'));
          $('#label_password').html($.i18n.prop('Password'));
        }
      });
    });

    //获取url中的参数
    function getUrlParam(name) {
      var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
      var r = window.location.search.substr(1).match(reg);  //匹配目标参数
      if (r != null) return unescape(r[2]); return null; //返回参数值
    }
  </script>
</body>
</html>
