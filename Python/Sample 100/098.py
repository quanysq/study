'''
题目：
从键盘输入一个字符串，将小写字母全部转换成大写字母，然后输出到一个磁盘文件"test"中保存。

程序分析：
无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

file = "d:\\pythontest.txt"
fp = open(file, "w")
string = input("please input a string: \n")
string = string.upper()
fp.write(string)
fp = open(file, "r")
print(fp.read())
fp.close()