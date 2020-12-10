# 分离数据集
from pandas import read_csv
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LogisticRegression

# 导入数据
filename='pima_data.csv'
names= ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
data = read_csv(filename, names=names)

# 将数据分为输入数据和输出结果
array = data.values
X = array[:, 0:8]
Y = array[:, 8]
test_size = 0.33
seed = 4
X_train, X_test, Y_train, Y_test = train_test_split(X, Y, test_size=test_size, random_state=seed)
model = LogisticRegression(max_iter=200)
model.fit(X_train, Y_train)
result = model.score(X_test, Y_test)
print("算法评估结果：%0.3f%%" % (result * 100))

# My
import numpy as np
preresult = model.predict(X_test)
Y_test_ravel = Y_test.ravel()  # 将多维数组转换为一维数组
cv = np.mean(Y_test_ravel == preresult)
print(cv)