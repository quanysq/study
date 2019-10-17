'''
题目：
编写input()和output()函数输入，输出5个学生的数据记录。

程序分析：
无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

N = 3
student = []
for i in range(5):
	student.append(['','',[]])
	
def input_stu(stu):
	for i in range(N):
		stu[i][0] = input('input student num: ')
		stu[i][1] = input('input student name: ')
		for j in range(3):
			stu[j][2].append(int(input('score: ')))
			
def ouput_stu(stu):
	for i in range(N):
		print('%-6s%-10s' % (stu[i][0], stu[i][1]))
		for j in range(3):
			print('%-8d' % stu[i][2][j])
			
input_stu(student)
print(student)
ouput_stu(student)