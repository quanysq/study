import numpy as np
import pandas as pd
myarray = np.array([1, 2, 3])
index = ['a', 'b', 'c']
myseries = pd.Series(myarray, index=index)
print(myseries)
print('Series 中的第一个元素：')
print(myseries[0])
print('Series 中的 c index 元素：')
print(myseries['c'])