'''
题目：
输入一个奇数，然后判断最少几个 9 除于该数的结果为整数。

程序分析：
999999 / 13 = 76923。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

zi = int(input('input a number: '))
n1 = 1
c9 = 1
m9 = 9
sum = 9
while n1 != 0:
	if sum % zi == 0:
		n1 = 0
	else:
		m9 *= 10
		sum += m9
		c9 += 1
print('%d 个 9 可以被 %d 整除 : %d' % (c9, zi, sum))
r = sum / zi
print('%d / %d = %d' % (sum, zi, r))