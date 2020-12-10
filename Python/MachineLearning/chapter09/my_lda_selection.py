# 通过线性判别分析（LDA）类库对数据进行降维
from pandas import read_csv
import numpy as np
from sklearn.discriminant_analysis import LinearDiscriminantAnalysis

# 导入数据
filename='pima_data.csv'
names= ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
data = read_csv(filename, names=names)

# 将数据分为输入数据和输出结果
array = data.values
X = array[:, 0:8]
Y = array[:, 8]

# 特征选定
n_class = len(np.unique(Y))
print(n_class)
lda = LinearDiscriminantAnalysis(n_components=1)  # 不大于 n_class 的数量
lda.fit(X, Y)
lda_X = lda.transform(X)
print(lda_X)
print('截距: %s' % lda.intercept_)
print('系数: %s' % lda.coef_)
print('各维度的方差值占总方差值的比例: %s' % lda.explained_variance_ratio_)
print('各维度的方差值之和占总方差值的比例: %f' % np.sum(lda.explained_variance_ratio_))

'''
似乎不怎么好用？
'''