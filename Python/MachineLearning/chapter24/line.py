# 展示某种趋势可以使用线图
# 线图可以清楚的展示某种事物的趋势
from matplotlib import pyplot as plt

years = [1967, 1977, 1987, 1997, 2007, 2017]
gdp = [728.82, 1749.38, 2729.73, 9616.04, 35521.82, 122377.00]

# 指定字体
plt.rcParams['font.sans-serif'] = ['SimHei']

# 创建一份线图，x轴是年份，y轴是gdp
plt.plot(years, gdp, color='red', marker='o', linestyle='solid')

# 添加一个标题
plt.title('China GDP')

# 给y轴加标记
plt.ylabel('US $100 million')
plt.show()