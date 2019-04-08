'''
题目：
画图，学用circle画圆形。　　　

程序分析：
无
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

# from TKinter import *
import tkinter as tk

window = tk.Tk()            #主窗口
window.title('my window')   #窗口标题
window.geometry('800x600')

canvas = tk.Canvas(window, bg='yellow', height=600, width=800)
#canvas.pack(expand = YES, fill = BOTH)
canvas.pack()
k = 1 
j = 1
for i in range(0,26):
	canvas.create_oval(310 - k, 250 - k, 310 + k, 250 + k, width=1)
	k += j
	j += 0.3
	
window.mainloop()