'''
题目：
某个公司采用公用电话传递数据，数据是四位的整数，在传递过程中是加密的，加密规则如下：每位数字都加上5,然后用和除以10的余数代替该数字，再将第一位和第四位交换，第二位和第三位交换。

程序分析：
无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_
from sys import stdout

a = int(input("input four numbers: "))
aa = []
aa.append(int(a % 10))
aa.append(int(a % 100 / 10))
aa.append(int(a % 1000 / 100))
aa.append(int(a / 1000))
print(aa)

for i in range(4):
    aa[i] += 5
    aa[i] %= 10
for i in range(2):
    aa[i],aa[3-i] = aa[3-i],aa[i]
for i in range(3, -1, -1):
    stdout.write(str(aa[i]))