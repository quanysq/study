from pandas import read_csv

# 数据分类分布统计
filename = 'pima_data.csv'
names= ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
data = read_csv(filename, names=names)
result = data.groupby('class').size()
print(result)
result = data.groupby('class').describe()
print(result)