'''
题目：
古典问题：有一对兔子，从出生后第3个月起每个月都生一对兔子，小兔子长到第三个月后每个月又生一对兔子，假如兔子都不死，问每个月的兔子总数为多少？

程序分析：
兔子的规律为数列1,1,2,3,5,8,13,21....
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

f1 = 1
f2 = 1
for i in range(1,22):
	print('%40d %40d' % (f1, f2), end=' ')
	if (i % 3) == 0:
		print('')
	f1 = f1 + f2
	f2 = f1 + f2