# 通过 joblib 序列化和反序列化机器学习的模型
from pandas import read_csv
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LogisticRegression
from joblib import dump
from joblib import load

# 导入数据
filename = 'pima_data.csv'
names= ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
data = read_csv(filename, names=names)

# 将数据分为输入数据和输出结果
array = data.values
X = array[:, 0:8]
Y = array[:, 8]

# 分离数据
test_size = 0.33
seed = 4
X_train, X_test, Y_train, Y_test = train_test_split(X, Y, test_size=test_size, random_state=seed)

# 训练模型
model = LogisticRegression(max_iter=200)
model.fit(X_train, Y_train)

# 保存模型
model_file = 'finalized_model_joblib.sav'
with open(model_file, 'wb') as model_f:
    dump(model, model_f)

# 加载模型
with open(model_file, 'rb') as model_f:
    loaded_model = load(model_f)
result = loaded_model.score(X_test, Y_test)
print("算法评估结果： %.3f%%" % (result * 100))