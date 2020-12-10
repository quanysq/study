from pandas import read_csv
from pandas import set_option

# 显示数据的相关性
filename = 'pima_data.csv'
names= ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
data = read_csv(filename, names=names)
set_option('display.width', 100)

# 设置数据的精确度
set_option('precision', 2)

result = data.corr(method='pearson')
print('pearson')
print(result)
'''
# 自已加着玩
result = data.corr(method='kendall')
print('kendall')
print(result)

result = data.corr(method='spearman')
print('spearman')
print(result)
'''