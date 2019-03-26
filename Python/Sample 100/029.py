'''
题目：
给一个不多于5位的正整数，
要求：一、求它是几位数，二、逆序打印出各位数字。

程序分析：
学会分解出每一位数。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

x = int(input('Please enter one number: \n'))
a = int(x / 10000)
b = int(x % 10000 / 1000)
c = int(x % 1000 / 100)
d = int(x % 100 / 10)
e = int(x % 10)

if a != 0:
	print('5 位数：', e,d,c,b,a)
elif b != 0:
	print('4 位数：', e,d,c,b)
elif c != 0:
	print('3 位数：', e,d,c)
elif d != 0:
	print('2 位数：', e,d)
else:
	print('1 位数：', e)