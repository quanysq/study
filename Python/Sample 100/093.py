'''
题目：
时间函数举例3。

程序分析：
无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

import time

start = time.clock()
for i in range(10000):
    print(i)
end = time.clock()
print("different is %6.3f" % (end - start))