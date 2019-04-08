'''
题目：
求输入数字的平方，如果平方运算后小于 50 则退出。

程序分析：
无
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

TURE = 1
FALSE = 0
def SQ(x):
	return x * x
	
print('如果平方运算后小于 50，程序将停止运行')
again = 1
while again:
	num = int(input('Please enter a number: '))
	total = SQ(num)
	print('运算结果为：%d' % total)
	if total >= 50:
		again = TURE
	else:
		again = FALSE