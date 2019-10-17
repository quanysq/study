'''
题目：
反向输出一个链表。

程序分析：
无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

ptr = []
for i in range(5):
	num = int(input('%d Please input a number: ' % i))
	ptr.append(num)
	
print(ptr)
ptr.reverse()
print(ptr)