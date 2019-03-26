'''
题目：
暂停 3 秒输出，并格式化当前时间。

程序分析：无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

import time

print(time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time())))

# 暂停 3s
time.sleep(3)

print(time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time())))