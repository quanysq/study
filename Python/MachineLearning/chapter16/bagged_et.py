# 极端随机数
from pandas import read_csv
from sklearn.model_selection import KFold
from sklearn.model_selection import cross_val_score
from sklearn.ensemble import ExtraTreesClassifier

# 导入数据
filename = 'pima_data.csv'
names= ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
data = read_csv(filename, names=names)

# 将数据分为输入数据和输出结果
array = data.values
X = array[:, 0:8]
Y = array[:, 8]
num_folds = 10
seed = 7
kfold = KFold(n_splits=num_folds, random_state=seed, shuffle=True)
num_tree = 100
max_feature = 7
model = ExtraTreesClassifier(n_estimators=num_tree, random_state=seed, max_features=max_feature)
result = cross_val_score(model, X, Y, cv=kfold)
print(result.mean())