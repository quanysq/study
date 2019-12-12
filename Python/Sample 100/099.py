'''
题目：
有两个磁盘文件A和B,各存放一行字母,要求把这两个文件中的信息合并(按字母顺序排列), 输出到一个新文件C中。

程序分析：无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

import string

file1 = "d:\\test1.txt"
file2 = "d:\\test2.txt"
file3 = "d:\\test3.txt"

fp = open(file1)
a = fp.read()
fp.close()

fp = open(file2)
b = fp.read()
fp.close()

fp = open(file3, "w")
l = list(a+b)
l.sort()
s = ''
s = s.join(l)
fp.write(s)
fp.close()