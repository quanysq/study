# 分类准确度
from pandas import read_csv
from sklearn.model_selection import KFold
from sklearn.model_selection import cross_val_score
from sklearn.linear_model import LogisticRegression

# 导入数据
filename='pima_data.csv'
names= ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
data = read_csv(filename, names=names)

# 将数据分为输入数据和输出结果
array = data.values
X = array[:, 0:8]
Y = array[:, 8]
num_folds = 10
seed = 7
kfold = KFold(n_splits=num_folds, random_state=seed, shuffle=True)
model = LogisticRegression(max_iter=200)
result = cross_val_score(model, X, Y, cv=kfold)
print("算法评估结果准确度： %.3f (%.3f)" % (result.mean(), result.std()))

# My
# 另一种写法
model.fit(X, Y)

# make class predictions for the testing set
y_pred_class = model.predict(X)

# calculate accuracy
from sklearn.metrics import accuracy_score
print(accuracy_score(Y, y_pred_class))