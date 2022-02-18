from matplotlib import pyplot as plt

variance = [1,2,4,8,16,32,64,128,256]
bias_squared = [256,128,64,32,16,8,4,2,1]
total_error = [x+y for x,y in zip(variance, bias_squared)]
xs = [i for i,_ in enumerate(variance)]
print('xs: %s' % xs)

# 可以多次调用plt.plot以便在同一个图上显示多个序列
plt.plot(xs, variance, 'g-', label='variance')              # 绿色实线
plt.plot(xs, bias_squared, 'r-.', label='bias^2')           # 红色点虚线
plt.plot(xs, total_error, 'b:', label='total error')        # 蓝色点线

# 因为已经对每个序列都指派了标记，所以可以自由地布置图例
# loc=9指的是“顶部中央”
plt.legend(loc=9)
plt.xlabel('Model responsibility')
plt.title('Deviation variance trade off chart')
plt.show()