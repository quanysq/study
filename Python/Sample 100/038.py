'''
题目：
求一个3*3矩阵主对角线元素之和。

程序分析：
利用双重for循环控制输入二维数组，再将a[i][i]累加后输出。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

a = []
sum = 0.0
for i in range(3):
	a.append([])
	for j in range(3):
		a[i].append(float(input('Enter num:\n')))
for i in range(3):
	sum += a[i][i]
print(sum)