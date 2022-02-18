# 拆分-分析 boston_house_price_demo.py
# 数据理解
from pandas import read_csv
from pandas import set_option

# 1.2 导入数据
filename = "housing.csv"
names = ['CRIM', 'ZN', 'INDUS', 'CRAS', 'NOX', 'RM', 'AGE', 'DIS', 'RAD', 'TAX', 'PRTATIO', 'B', 'LSTAT', 'MEDV']
dataset = read_csv(filename, names=names, delim_whitespace=True)

# 2 理解数据
# 2.1 描述性统计 - 数据维度
print(dataset.shape)
set_option('display.width', 120)
set_option('display.max_rows', 31)
set_option('display.max_columns', 15)

# 2.1 描述性统计 - 特征属性的字段类型
print(dataset.dtypes)

# 2.1 描述性统计 - 查看最开始的 30 条记录
print(dataset.head(30))

# 2.1 描述性统计 - 描述性统计信息
set_option('precision', 1)
print(dataset.describe())