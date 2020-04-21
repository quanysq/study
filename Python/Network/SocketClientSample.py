# !/usr/bin/python3
# _*_ coding: UTF-8 _*_

# URL: https://www.runoob.com/python3/python3-socket.html

# 导入 socket、sys 模块
import socket
import sys

# 创建 socket 对象
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# 获取本地主机名
host = socket.gethostname()
port = 9999
addr = (host, port)

# 连接服务，指定主机和端口
s.connect(addr)

# 接收小于 1024 字节的数据
msg = s.recv(1024)

s.close()

print(msg.decode("utf-8"))