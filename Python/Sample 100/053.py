'''
题目：
学习使用按位异或 ^ 。

程序分析：
0^0=0; 0^1=1; 1^0=1; 1^1=0
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

a = 0o77
b = a ^ 3
print('a ^ b is %d' % b)
b ^= 7
print('a ^ b is %d' % b)