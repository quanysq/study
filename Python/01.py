#提示用户进行输入
integer1 = input('Please input integer: ')
integer1 = int(integer1)
integer2 = input('Please input integer again: ')
integer2 = int(integer2)
if integer1 > integer2:
    print ('%d > %d' %(integer1, integer2))
else:
    print ('%d <= %d' %(integer1, integer2))



