import tkinter
from tkinter import *
widget = Label(None, text='This is my first Gui!!!') #创建一个label
widget.pack(expand=YES, fill=BOTH) #参数表示当父窗口扩展时小组件也扩展
widget.mainloop()
