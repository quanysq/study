'''
题目：
时间函数举例2。

程序分析：
无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

import time

start = time.time()
for i in range(3000):
    print(i)
end = time.time()
print("takk time: %s" % (end-start))