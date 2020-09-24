import matplotlib.pyplot as plt


delta_x = 0.1
y = 0
x = -1
list_x1 = []
list_y1 = []
list_x1.insert(0, x)
list_y1.insert(0, y)
x = x + delta_x
y = y + delta_x / (x + 2 * y)
list_x1.insert(1, x)
list_y1.insert(1, y)

for i in range(2, 21):
    x = x + delta_x
    x = round(x, 3)
    y = list_y1[i-2] + 2*delta_x/(list_x1[i-1]+2*list_y1[i-1])
    y = round(y, 3)
    list_x1.insert(i, x)
    list_y1.insert(i, y)
print(str(list_x1), '\n', str(list_y1))
plt.plot(list_x1, list_y1)
plt.show()

y = 0
x = -1
list_x2 = []
list_y2 = []
list_x2.insert(0, x)
list_y2.insert(0, y)

for i in range(1, 21):
    x = x + delta_x
    x = round(x, 3)
    y = list_y2[i-1] + delta_x / ((list_x2[i-1]+delta_x/2) + 2 * (list_y2[i-1] +
                                                                  delta_x / 2 / (list_y2[i-1] * 2+list_x2[i-1])))
    y = round(y, 3)
    list_x2.insert(i, x)
    list_y2.insert(i, y)

y = 0
x = -1
list_x2 = []
list_y2 = []
list_x2.insert(0, x)
list_y2.insert(0, y)

for i in range(1, 21):
    x = x + delta_x
    x = round(x, 3)
    y = list_y2[i-1] + delta_x / ((list_x2[i-1]+delta_x/2) + 2 * (list_y2[i-1] +
                                                                  delta_x / 2 / (list_y2[i-1] * 2+list_x2[i-1])))
    y = round(y, 3)
    list_x2.insert(i, x)
    list_y2.insert(i, y)

y = 0
x = -1
list_x3 = []
list_y3 = []
list_x3.insert(0, x)
list_y3.insert(0, y)

for i in range(1, 21):
    x = x + delta_x
    x = round(x, 3)
    y = list_y3[i-1] + delta_x / ((list_x3[i-1]+delta_x/2) + 2 * (list_y3[i-1] +
                                                                  delta_x / 2 / (list_y3[i-1] * 2+list_x3[i-1])))
    y = round(y, 3)
    list_x3.insert(i, x)
    list_y3.insert(i, y)


print(str(list_x1), '\n', str(list_y1))
plt.plot(list_x1, list_y1)
plt.show()
plt.plot(list_x2, list_y2)
plt.show()
plt.plot(list_x3, list_y3)
plt.show()
