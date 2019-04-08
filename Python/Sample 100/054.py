'''
题目：
取一个整数a从右端开始的4~7位。

程序分析：可以这样考虑： 
(1)先使a右移4位。 
(2)设置一个低4位全为1,其余全为0的数。可用~(~0<<4) 
(3)将上面二者进行&运算。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

a = int(input('input a number: '))
b = a >> 4
print('b is %d' % b)
c = ~(~0 << 4)
print('c is %d' % c)
d = b & c
print('%o\t%o' % (a,d))