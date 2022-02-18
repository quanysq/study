# 拆分-分析 boston_house_price_demo.py
# 特征选择
from pandas import read_csv
from sklearn.decomposition import PCA
from numpy import set_printoptions

# 1.2 导入数据
filename = "housing.csv"
names = ['CRIM', 'ZN', 'INDUS', 'CRAS', 'NOX', 'RM', 'AGE', 'DIS', 'RAD', 'TAX', 'PRTATIO', 'B', 'LSTAT', 'MEDV']
dataset = read_csv(filename, names=names, delim_whitespace=True)

# 根据与标签的相关性过滤特征
array = dataset.values
X = array[:, 0:13]
Y = array[:, 13]

pca = PCA(n_components=4)
fit = pca.fit(X, Y)
print("解释方差：%s" % fit.explained_variance_ratio_)
print(fit.components_)

newX = pca.transform(X)
print(newX[:5, :])
