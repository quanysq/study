'''
题目：
字符串排序。

程序分析：
无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

str1 = input('input string 1: ')
str2 = input('input string 2: ')
str3 = input('input string 3: ')
print(str1, str2, str3)

if str1 > str2: str1,str2 = str2,str1
if str1 > str3: str1,str3 = str3,str1
if str2 > str3: str2,str3 = str3,str2
print('after sorting:')
print(str1,str2,str3)