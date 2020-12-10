from numpy import loadtxt

# 使用 NumPy 导入 CSV 数据
filename = 'pima_data.csv'
with open(filename, 'rt') as raw_data:
    data = loadtxt(raw_data, delimiter=',')
    print(data.shape)