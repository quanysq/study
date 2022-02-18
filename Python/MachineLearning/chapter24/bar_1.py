from matplotlib import pyplot as plt
from collections import Counter  # Counter是一个继承了字典的类

grades = [75,0,62,100,95,89,0,55,73,82,85,77,61]
decile = lambda grade: grade//10 * 10

histogram = Counter(decile(grade) for grade in grades)
print('histogram: %s' % histogram)

plt.bar([x for x in histogram.keys()],
        histogram.values(),                     # 给每个条形设置正确的高度
        8)                                      # 每个条形的宽度设置为8

plt.axis([-5, 105, 0, 5])                       # x轴取值从-5到105,y轴取值0到5

plt.xticks([10 * i for i in range(11)])         # x轴标记为0,10,...,100
plt.ylabel('Student count')
plt.title('Exam score')
plt.show()

