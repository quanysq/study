'''
题目：
按逗号分隔列表。

程序分析：
无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

L = [1,2,3,4,5]
sl = ','.join(str(n) for n in L)
print(sl)