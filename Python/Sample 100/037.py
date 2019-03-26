'''
题目：
对10个数进行排序。

程序分析：
可以利用选择法，即从后9个比较过程中，选择一个最小的与第一个元素交换，下次类推，即用第二个元素与后8个进行比较，并进行交换。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

if __name__ == '__main__':
	N = 10
	print('Please enter 10 numbers: \n')
	l = []
	for i in range(N):
		l.append(int(input('Enter a number:\n')))
	print('')
	for i in range(N):
		print(l[i])
	print('')
	
	for i in range(N-1):
		min = i
		for j in range(i+1,N):
			if l[min] > l[j]:
				min = j
		l[i],l[min] = l[min],l[i]
	print('After ordering:')
	for i in range(N):
		print(l[i])