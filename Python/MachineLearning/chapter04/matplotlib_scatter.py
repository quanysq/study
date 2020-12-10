import matplotlib.pyplot as plt
import numpy as np
'''
# 定义绘图的数据
myarray1 = np.array([1, 2, 3])
myarray2 = np.array([11, 21, 31])

# 初始化绘图
plt.scatter(myarray1, myarray2)

# 设定 x 轴和 y 轴
plt.xlabel('x axis')
plt.ylabel('y axis')

# 绘图
plt.show()
'''
# Fixing random state for reproducibility
np.random.seed(19680801)
N = 100
r0 = 0.6
x = 0.9 * np.random.rand(N)
y = 0.9 * np.random.rand(N)
area = (20 * np.random.rand(N))**2  # 0 to 10 point radii
c = np.sqrt(area)
r = np.sqrt(x ** 2 + y ** 2)
area1 = np.ma.masked_where(r < r0, area)  # 意思是 area1 是所有 r 值小于 0.6 的 area 的集合
area2 = np.ma.masked_where(r >= r0, area)
plt.scatter(x, y, s=area1, marker='^', c=c)
plt.scatter(x, y, s=area2, marker='o', c=c)
# Show the boundary between the regions:
theta = np.arange(0, np.pi / 2, 0.01)  # 在给定间隔内返回均匀间隔的值
plt.plot(r0 * np.cos(theta), r0 * np.sin(theta))
plt.show()