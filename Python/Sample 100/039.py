'''
题目：
有一个已经排好序的数组。现输入一个数，要求按原来的规律将它插入数组中。

程序分析：
首先判断此数是否大于最后一个数，然后再考虑插入中间的数的情况，插入后此元素之后的数，依次后移一个位置。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

a = [1,4,6,9,13,16,19,28,40,100,0]
print('Before ordering:')
for i in range(len(a)):
	print(a[i], end=" ")
print('')
number = int(input('Insert a number:'))
end = a[9]
if number > end:
	a[10] = number
else:
	for i in range(10):
		if a[i] > number:
			temp1 = a[i]
			a[i] = number
			for j in range(i+1, 11):
				temp2 = a[j]
				a[j] = temp1
				temp1 = temp2
			break
print('After ordering:')
for i in range(11):
	print(a[i],end=' ')