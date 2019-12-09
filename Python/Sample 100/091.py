'''
题目：
时间函数举例1。

程序分析：
无。
'''
# !/usr/bin/python3
# _*_ coding: UTF-8 _*_

import time

print(time.ctime(time.time()))
print(time.asctime(time.localtime(time.time())))
print(time.asctime(time.gmtime(time.time())))