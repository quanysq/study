'''
题目：
列表使用实例。

程序分析：
无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

#list
#Create a new list
testList = [10086, "中国移动", [1,2,3,4]]

#Access the list length
print(len(testList))

#Go go the list end
print(testList[1:])

#Add a new element into the list
testList.append('i\' new here')
print(len(testList))
print(testList[-1])

#Pop the last element
print(testList.pop(1))
print(len(testList))
print(testList)

#list comprehension
matrix = [[1,2,3],[4,5,6],[7,8,9]]
print(matrix)
print(matrix[1])
col2 = [row[1] for row in matrix] #get a column from a matrix
print(col2)
col2even = [row[1] for row in matrix if row[1]%2 == 0] #filter odd item
print(col2even)