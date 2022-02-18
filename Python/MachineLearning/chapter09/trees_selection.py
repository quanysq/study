# 通过决策树（极度随机树）计算特征的重要性
from pandas import read_csv
from sklearn.ensemble import ExtraTreesClassifier

# 导入数据
filename='pima_data.csv'
names= ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
data = read_csv(filename, names=names)

# 将数据分为输入数据和输出结果
array = data.values
X = array[:, 0:8]
Y = array[:, 8]

# 特征选定
model = ExtraTreesClassifier()
fit = model.fit(X, Y)
print(fit.feature_importances_)
print(fit.n_features_)

# My
# 结合 SelectFromModel 选特征
from sklearn.feature_selection import SelectFromModel
feature = SelectFromModel(model, prefit=True)
X_new = feature.transform(X)
print(X_new.shape)
'''
X_new[:5, :] # 5 行数据
X_new[5:, :] # (总行数 - 5) 行数据
'''
print(X_new[:5, :])

