from pandas import read_csv

# 显示数据的前 10 行
filename = 'pima_data.csv'
names= ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
data = read_csv(filename, names=names)
peek = data.head(10)
print(peek)