import numpy as np
import pandas as pd
myarray = np.array([[1, 2, 3], [2, 3, 4], [3, 4, 5]])
rowindex = ['row1', 'row2', 'row3']
colname= ['col1', 'col2', 'col3']
mydataframe = pd.DataFrame(data=myarray, index=rowindex, columns=colname)
print(mydataframe)
print('访问 col3 的数据：')
print(mydataframe['col3'])
print(mydataframe.col3) # output: Name: col3, dtype: int32