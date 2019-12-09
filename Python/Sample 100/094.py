'''
题目：
时间函数举例4,一个猜数游戏，判断一个人反应快慢。

程序分析：
无。
'''
# !/usr/bin/python
# _*_ coding: UTF-8 _*_

import time
import random

play_it = input("do you want to play it. ('y' or 'n')")
while play_it == 'y':
    c = input("input a character: ")
    i = random.randint(0, 2**32) % 100
    print("please input number you guess: ")
    start = time.clock()
    a = time.time()
    guess = int(input("input your guess: "))
    while guess != i:
        if guess > i:
            print("please input a little samller")
            guess = int(input("input your guess: "))
        else:
            print("please input a little bigger")
            guess = int(input("input your guess: "))
    end = time.clock()
    b = time.time()
    var = (end-start) / 18.2
    print("var is %f" % var)
    if var < 15:
        print("yor are very clever!")
    elif var < 25:
        print("yor are normal!")
    else:
        print("you are stupid")
    print("Conggradulations")
    print("The number you guess is %d" % i)
    play_it = input("do you want to play it")