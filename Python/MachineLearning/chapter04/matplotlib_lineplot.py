import matplotlib.pyplot as plt
import numpy as np

# 定义绘图的数据
myarray = np.array([[1, 2, 3],
                    [2, 3, 4],
                    [3, 4, 5]])

# 初始化绘图
plt.plot(myarray)

# 设定 x 轴和 y 轴
plt.xlabel('x axis')
plt.ylabel('y axis')

t = np.arange(0.0, 2.0, 0.01)
print(t)
s = 1 + np.sin(2 * np.pi * t)
fig, ax = plt.subplots()
ax.plot(t, s)
ax.set(xlabel='time(s)', ylabel='vlotage(mV)', title='About as simple as it gets, folks')
ax.grid()

# 绘图
plt.show()