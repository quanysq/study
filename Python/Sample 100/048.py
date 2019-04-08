'''
题目：
数字比较。

程序分析：
无
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

i = int(input("Please enter a number: "))
j = int(input("Please enter a number: "))
if i > j:
	print('%d 大于 %d' % (i,j))
elif i == j:
	print('%d 等于 %d' % (i,j))
elif i < j:
	print('%d 小于 %d' % (i,j))
else:
	print('unknow')