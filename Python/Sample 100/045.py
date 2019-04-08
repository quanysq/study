'''
题目：
统计 1 到 100 之和。

程序分析：
无
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

tmp = 0
for i in range(1,101):
	tmp += i
print('The sum is %d' % tmp)