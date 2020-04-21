# !/usr/bin/python3
# _*_ coding: UTF-8 _*_

# URL: https://www.runoob.com/python3/python3-socket.html

# Server 端和 Client 端要分开两个 CMD 窗口执行
# 否则将报错：no connection could be made because the target machine actively refused it.

# 导入 socket、sys 模块
import socket
import sys

# 创建 socket 对象
serversocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# 获取本地主机名
host = socket.gethostname()
port = 9999
addr = (host, port)
# 绑定端口号
serversocket.bind(addr)

# 设置最大连接数，超过后排队
serversocket.listen(5)

while True:
    # 建立客户端连接
    clientsocket,addr = serversocket.accept()
    print("连接地址：%s" % str(addr))
    msg = "欢迎访问菜鸟教程！\r\n"
    clientsocket.send(msg.encode("utf-8"))
    clientsocket.close()
    