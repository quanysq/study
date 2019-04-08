'''
题目：
画图，学用line画直线。

程序分析：
无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

import tkinter as tk

window = tk.Tk()            #主窗口
window.title('my window')   #窗口标题
window.geometry('300x300')

canvas = tk.Canvas(window, bg='green', height=300, width=300)
# canvas.pack(extend=yes, fill=both)
canvas.pack()
x0 = 263
y0 = 263
y1 = 275
x1 = 275
for i in range(19):
	canvas.create_line(x0,y0,x0,y1, width=1,fill='red')
	x0 = x0 - 5
	y0 = y0 - 5
	x1 = x1 + 5
	y1 = y1 + 5
	
x0 = 263
y1 = 275
y0 = 263
for i in range(21):
	canvas.create_line(x0,y0,x0,y1,fill = 'red')
	x0 += 5
	y0 += 5
	y1 += 5
 
window.mainloop()