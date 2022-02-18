# 展示某些离散的项目的集合的数量变化，可以使用条形图
from matplotlib import pyplot as plt

movies = ['Movie1 ', 'Movie2', 'Movie3', 'Movie4', 'Movie5', 'Movie16']
num_oscars = [3, 3, 4, 1, 1, 3]

# 条形的默认宽度是0.8,因此我们对左侧坐标加上0.1，这样每个条形就被放置在中心了
xs = [i + 0.1 for i,_ in enumerate(movies)]

# 使用左侧坐标[xs]和高度[num_oscars]画条形图
plt.bar(xs, num_oscars)

plt.ylabel('Number of win')
plt.title('Movie of win')

# 使用电影对名字标记x轴，位置在x轴上条形的中心
plt.xticks([i for i,_ in enumerate(movies)], movies)
plt.show()