<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="Web001.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>抽取同花顺数据</title>
    <script src="/Scripts/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border:1px solid #ccc; width: 200px; height: 500px; float:left;">
            <ul>
                <li>
                    <a href="javascript:;">美锦能源 000723</a>
                </li>
            </ul>
        </div>
        <div style="border:1px solid #ccc; width: 710px; height: 800px; margin-left:210px;">
            <div style="margin:5px 5px; padding: 5px 5px; height:60px; border:1px solid #ccc;">

            </div>
            <div id="divweb" style="margin:5px 5px; padding: 5px 5px; height:700px; border:1px solid #ccc;">
                <iframe id="thsframe" style="width:100%; height:506px;" frameborder="0" scrolling="yes">

                </iframe>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#thsframe").attr("src", "http://stockpage.10jqka.com.cn/600537/");
                
            var iframe = document.getElementById("thsframe");
            iframe.onload = function () {
                setTimeout(function () {
                    console.log(111);
                    var s = $(window.frames["thsframe"].document).find("div[class='m_content']"); //$('#thsframe iframe ul li[hxc3-data-type="hxc3KlineQfqWeek"]');

                    console.log(s.html());
                }, 10000)
                
            };
        });
    </script>
</body>
</html>
