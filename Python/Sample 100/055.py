'''
题目：
学习使用按位取反~。

程序分析：
~0=1; ~1=0; 
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

a = 234
b = ~a
print('The a\'s 1 complement is %d' % b)
a = ~a
print('The a\'s 2 complement is %d' % a)