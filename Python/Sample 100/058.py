'''
题目：
画图，学用rectangle画方形。

程序分析：
rectangle(int left, int top, int right, int bottom)
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

import tkinter as tk

window = tk.Tk()            #主窗口
window.title('my window')   #窗口标题
window.geometry('400x400')

canvas = tk.Canvas(window, bg='yellow', height=400, width=400)
x0 = 263
y0 = 263
y1 = 275
x1 = 275
for i in range(19):
	canvas.create_rectangle(x0,y0,x1,y1)
	x0 -= 5
	y0 -= 5
	x1 += 5
	y1 += 5
canvas.pack()
window.mainloop()