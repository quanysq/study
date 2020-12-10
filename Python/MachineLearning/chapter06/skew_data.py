from pandas import read_csv

# 计算数据的高斯偏离
filename = 'pima_data.csv'
names= ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
data = read_csv(filename, names=names)
result = data.skew()
# result = data.skew(axis=0)
print(result)


