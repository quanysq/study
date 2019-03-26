'''
题目：
输出指定格式的日期。

程序分析：
使用 datetime 模块。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

import datetime

if __name__ == '__main__':
	# 输出今日日期，格式为 dd/mm/yyyy。更多选项可以查看 strftime() 方法
	print(datetime.date.today().strftime('%d/%m/%Y'))
	
	# 创建日期对象
	myBirthDate = datetime.date(1980,1,2)
	print(myBirthDate.strftime('%d/%m/%Y'))
	
	# 日期算术运算
	myBirthDate = myBirthDate + datetime.timedelta(days=1)
	print(myBirthDate.strftime('%d/%m/%Y'))
	
	# 日期替换
	myBirthDate = myBirthDate.replace(year=myBirthDate.year+1)
	print(myBirthDate.strftime('%d/%m/%Y'))