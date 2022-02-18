# 拆分-分析 boston_house_price_demo.py
# 特征选择
from pandas import read_csv
from sklearn.feature_selection import SelectKBest
from sklearn.feature_selection import f_regression
from numpy import set_printoptions

# 1.2 导入数据
filename = "housing.csv"
names = ['CRIM', 'ZN', 'INDUS', 'CRAS', 'NOX', 'RM', 'AGE', 'DIS', 'RAD', 'TAX', 'PRTATIO', 'B', 'LSTAT', 'MEDV']
dataset = read_csv(filename, names=names, delim_whitespace=True)

# 根据与标签的相关性过滤特征
array = dataset.values
X = array[:, 0:13]
Y = array[:, 13]

test = SelectKBest(score_func=f_regression, k=4)
fit = test.fit(X, Y)
set_printoptions(precision=3)
print(fit.scores_)
features = fit.transform(X)
print(features)

X_new = fit.get_support(indices=False)
print(X_new)




