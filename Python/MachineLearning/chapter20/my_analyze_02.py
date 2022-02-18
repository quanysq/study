# 拆分-分析 boston_house_price_demo.py
# 数据可视化
from pandas import read_csv
from pandas import set_option
from matplotlib import pyplot
from pandas.plotting import scatter_matrix
import numpy as np

# 1.2 导入数据
filename = "housing.csv"
names = ['CRIM', 'ZN', 'INDUS', 'CRAS', 'NOX', 'RM', 'AGE', 'DIS', 'RAD', 'TAX', 'PRTATIO', 'B', 'LSTAT', 'MEDV']
dataset = read_csv(filename, names=names, delim_whitespace=True)

set_option('display.width', 120)
set_option('display.max_rows', 31)
set_option('display.max_columns', 15)

# 数据可视化
set_option('precision', 2)
data_corr = dataset.corr(method='pearson')
print(data_corr)

# 2.2 数据可视化 - 单一特征图表 - 直方图
dataset.hist(sharex=False, sharey=False, xlabelsize=1, ylabelsize=1)

# 2.2 数据可视化 - 单一特征图表 - 密度图
dataset.plot(kind='density', subplots=True, layout=(4 ,4), sharex=False, fontsize=1)

# 2.2 数据可视化 - 单一特征图表 - 箱线图
dataset.plot(kind='box', subplots=True, layout=(4, 4), sharex=False, sharey = False, fontsize=8)

# 2.2 数据可视化 - 多重数据图表 - 散点矩阵图
scatter_matrix(dataset)

# 2.2 数据可视化 - 多重数据图表 - 相关矩阵图
fig = pyplot.figure()
ax = fig.add_subplot(111)
cax = ax.matshow(data_corr, vmin=-1, vmax=1, interpolation='none')
fig.colorbar(cax)
ticks = np.arange(0, 14, 1)
ax.set_xticks(ticks)
ax.set_yticks(ticks)
ax.set_xticklabels(names)
ax.set_yticklabels(names)

for (i, j), z in np.ndenumerate(data_corr):
    ax.text(j, i, '{:0.2f}'.format(z), ha='center', va='center')
'''
https://stackoverflow.com/questions/20998083/show-the-values-in-the-grid-using-matplotlib
Show the values in the grid using matplotlib
'''

'''
mat = np.arange(1, 10).reshape(3, 3)
pyplot.matshow(mat, cmap=pyplot.cm.BrBG)
for i in range(mat.shape[0]):
    for j in range(mat.shape[1]):
        pyplot.text(x=j, y=i, s=mat[i, j])
'''
pyplot.show()