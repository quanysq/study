'''
题目：
有一分数序列：2/1，3/2，5/3，8/5，13/8，21/13...求出这个数列的前20项之和。

程序分析：
请抓住分子与分母的变化规律。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

from functools import reduce
# Method 1
a = 2.0
b = 1.0
s = 0.0
for n in range(1,21):
	s += a / b
	t = a
	a = a + b
	b = t
print(s)
print('')

# Mehtod 2
c = 2.0
d = 1.0
x = 0.0
for n in range(1,21):
	x += c / d
	d,c = c, c+d
print(x)
print('')

# Mehtod 3
e = 2.0
f = 1.0
l = []
l.append(e / f)
for n in range(1,20):
	f,e = e,e+f
	l.append(e/f)
print(reduce(lambda x,y: x+y,l))