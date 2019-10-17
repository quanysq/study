'''
题目：
八进制转换为十进制

程序分析：
无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

while True:
	n = 0
	p = input('input a octal number: ')
	if p == 'Q':
		break
	else:
		for i in range(len(p)):
			n = n * 8 + ord(p[i]) - ord('0')
		print(n)