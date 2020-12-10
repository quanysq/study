# 决策树结果可视化
from pandas import read_csv
from matplotlib.image import imread
from matplotlib import pyplot
from sklearn.model_selection import train_test_split
from sklearn.tree import DecisionTreeClassifier
from sklearn.tree import export_graphviz
from sklearn.metrics import accuracy_score
import pydotplus
import os

# 导入数据
filename = 'iris.data.csv'
names = ['separ-length', 'separ-width', 'petal-length', 'petal-width', 'class']
dataset = read_csv(filename, names=names)
array = dataset.values
X = array[:, 0:4]
Y = array[:, 4]

# 分离数据集
X_train, X_test, Y_train, Y_test = train_test_split(X, Y, random_state=7, test_size=0.2)

# 决策树模型训练
model = DecisionTreeClassifier()
model.fit(X=X_train, y=Y_train)

# 决策树图形化
dot_data = export_graphviz(model, out_file=None)
graph = pydotplus.graph_from_dot_data(dot_data)
path = os.getcwd() + '/'
tree_file = path + 'iris.png'
try:
    os.remove(tree_file)
except:
    print('There is no file to be deleted.')
finally:
    graph.write(tree_file, format='png')

# 显示图像
image_data = imread(tree_file)
pyplot.imshow(image_data)
pyplot.axis('off')
pyplot.show()

# 评估算法
predictions = model.predict(X_test)
print(accuracy_score(Y_test, predictions))