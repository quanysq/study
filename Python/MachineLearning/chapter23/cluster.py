# 聚类分析 KMean
from pandas import read_csv
from sklearn.cluster import KMeans
from sklearn.decomposition import PCA
from sklearn.preprocessing import scale
from sklearn.preprocessing import StandardScaler
from matplotlib import pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
import numpy as np
from sklearn import metrics

# 导入数据
filename = 'wine.data'
names = ['class', 'Alcohol', 'MalicAcid', 'Ash', 'AlclinityOfAsh',
         'Magnesium', 'TotalPhenols', 'Flavanoids', 'NonfiayanoidPhenols',
         'Proanthocyanins', 'ColorIntensiyt', 'Hue', '0D280/0D315', 'Proline']
dataset = read_csv(filename, names=names)
dataset['class'] = dataset['class'].replace(to_replace=[1, 2, 3], value=[0, 1, 2])
array = dataset.values
X = array[:, 1:13]
Y = array[:, 0]

# 数据降维
pca = PCA(n_components=3)
X_scale = StandardScaler().fit_transform(X)
X_reduce = pca.fit_transform(scale(X_scale))

# 模型训练
model = KMeans(n_clusters=3)
model.fit(X_reduce)
lables = model.labels_
# print(lables)

# 输出模型的准确度
print('%.3f    %.3f    %.3f    %.3f    %.3f    %.3f' % (
    metrics.homogeneity_score(Y, lables),
    metrics.completeness_score(Y, lables),
    metrics.v_measure_score(Y, lables),
    metrics.adjusted_rand_score(Y, lables),
    metrics.adjusted_mutual_info_score(Y, lables),
    metrics.silhouette_score(X_reduce, lables)))

# 绘制模型的分布图
fig = plt.figure()
ax = Axes3D(fig, rect=[0, 0, .95, 1], elev=48, azim=134)
ax.scatter(X_reduce[:, 0], X_reduce[:, 1], X_reduce[:, 2], c=lables.astype(np.float))
plt.show()