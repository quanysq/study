'''
题目：
两个变量值互换。

程序分析：
无
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

def exchange(a,b):
	a,b = b,a
	return (a,b)
	
x = 10
y = 20
print('x = %d, y = %d' % (x,y))
x,y = exchange(x,y)
print('x = %d, y = %d' % (x,y))