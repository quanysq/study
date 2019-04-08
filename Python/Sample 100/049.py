'''
题目：
使用lambda来创建匿名函数。

程序分析：
无
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

MAXMNM = lambda x,y: (x > y) * x + (x < y) * y
MINMNM = lambda x,y: (x > y) * y + (x < y) * x

a = 10
b = 20
print('The largar one is %d' % MAXMNM(a,b))
print('The lower one is %d' % MINMNM(a,b))