# 散点图显示成对数据集的可视化关系是比较好的
from matplotlib import pyplot as plt

friends = [70,65,72,63,71,64,60,64,67]
minutes = [175,170,205,120,220,130,105,145,190]
labels = ['a','b','c','d','e','f','g','h','i']

plt.scatter(friends, minutes)

#每个点加标记
for label, friend_count, minute_count in zip(labels, friends, minutes):
    plt.annotate(label,
                 xy=(friend_count, minute_count),       # 把标记放在对应的点上
                 xytext=(5, -5),                        # 但要有轻微偏离
                 textcoords='offset points')

plt.title('Minutes and friends every day')
plt.xlabel('friends')
plt.ylabel('Minutes spent on the site')
plt.show()