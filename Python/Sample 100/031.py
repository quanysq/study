'''
题目：
请输入星期几的第一个字母来判断一下是星期几，如果第一个字母一样，则继续判断第二个字母。

程序分析：
用情况语句比较好，如果第一个字母一样，则判断用情况语句或if语句判断第二个字母。。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

letter = input('Please enter: ')
if letter == 'S':
	letter = input('Please enter the second letter: ')
	if letter == 'a':
		print('Saturday')
	elif letter == 'u':
		print('Sunday')
	else:
		print('Data error')
elif letter == 'F':
	print('Friday')
elif letter == 'M':
	print('Monday')
elif letter == 'T':
	letter = input('Please enter the second letter: ')
	if letter == 'u':
		print('Tuesday')
	elif letter == 'h':
		print('Thursday')
	else:
		print('Data error')
elif letter == 'W':
	print('Wednesday')
else:
	print('Data error')