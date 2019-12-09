'''
题目：
字符串日期转换为易读的日期格式。

程序分析：
无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

from dateutil import parser
dt = parser.parse("Aug 28 2015 12:00AM")
print(dt)

# Need to install dateutil library first 