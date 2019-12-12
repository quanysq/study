'''
题目：
从键盘输入一些字符，逐个把它们写到磁盘文件上，直到输入一个 # 为止。

程序分析：
无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

from sys import stdout
filename = input("input a file name: ")
fp = open(filename, "w")
ch = input("input strings: \n")
while ch != "#":
    fp.write(ch)
    stdout.write(ch)
    ch = input("\n")
fp.close()
