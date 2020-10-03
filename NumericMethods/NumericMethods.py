import matplotlib.pyplot as plt
import numpy as np


first_y = 0
interval_start = -1
interval_end = 1
h = 0.01
steps = int((interval_end - interval_start)/h + 1)


def real_function(x, y):
    return 1 / (x + 2 * y)


def add_1_rk4(x, y):
    k = real_function(x + h/2, y + h/2 * real_function(x, y))
    return k


def add_2_rk4(x, y):
    k = real_function(x + h/2, y + h/2 * add_1_rk4(x, y))
    return k


def add_3_rk4(x, y):
    k = real_function(x + h, y + h * add_2_rk4(x, y))
    return  k


def run_kut_4(x, y):
    y_next = y + h / 6 * (real_function(x, y) + 2 * add_1_rk4(x, y) + 2 * add_2_rk4(x, y) + add_3_rk4(x, y))
    return y_next


def addams_4(x, y, x_1, y_1, x_2, y_2, x_3, y_3):
    y_next = y + h/24*(55*real_function(x, y)-59*real_function(x_1, y_1) + 37*real_function(x_2, y_2) -
                   9 * real_function(x_3, y_3))
    return y_next


def addams_3(x, y, x_1, y_1, x_2, y_2):
    y_next = y + h/12*(23*real_function(x, y) - 16*real_function(x_1, y_1) +5*real_function(x_2, y_2))
    return y_next


def eulers_method(x, y):
    y_next = y + h * real_function(x, y)
    return y_next


def improved_eulers_method_1(x, y):
    y_next = y + h * real_function(x+h/2, y + h/2 * real_function(x, y))
    return y_next


def improved_eulers_method_2(x, y):
    y_next = y + h / 2 * (real_function(x, y) + real_function(x + h, y + h * real_function(x, y)))
    return y_next


def improved_eulers_method_3(x, y, y_previous):
    y_next = y_previous + 2 * h * real_function(x, y)
    return y_next


def list_y_function(foo, list_x, y: float = first_y):
    list_y = [y]

    if foo == improved_eulers_method_3:
        y = eulers_method(list_x[0], list_y[0])
        list_y.append(y)
        for i in range(2, steps):
            y = foo(list_x[i - 1], list_y[i - 1], list_y[i - 2])
            list_y.append(y)
    elif foo == addams_3:
        y = eulers_method(list_x[0], list_y[0])
        list_y.append(y)
        y = eulers_method(list_x[1], list_y[1])
        list_y.append(y)
        for i in range(3, steps):
            y = foo(list_x[i - 1], list_y[i - 1], list_x[i - 2], list_y[i - 2], list_x[i - 3], list_y[i - 3])
            list_y.append(y)
        print(len(list_y))
    elif foo == addams_4:
        y = eulers_method(list_x[0], list_y[0])
        list_y.append(y)
        y = eulers_method(list_x[1], list_y[1])
        list_y.append(y)
        y = eulers_method(list_x[2], list_y[2])
        list_y.append(y)
        for i in range(4, steps):
            y = foo(list_x[i - 1], list_y[i - 1], list_x[i - 2], list_y[i - 2], list_x[i - 2], list_y[i - 3],
                    list_x[i-4], list_y[i-4])
            list_y.append(y)
    else:
        for i in range(1, steps):
            y = foo(list_x[i-1], list_y[i-1])
            list_y.append(y)

    return list_y


def render_drawing_num_methods():
    x = np.linspace(interval_start, interval_end, steps)
    print(len(x))
    y = list_y_function(run_kut_4, x)
    y1 = list_y_function(addams_3, x)
    y2 = list_y_function(addams_4, x)

    plt.plot(x, y, label='run_kut_4')
    plt.plot(x, y1, label='addams_3')
    plt.plot(x, y2, label='addams_4')

    plt.legend()
    plt.show()


if __name__ == '__main__':
    render_drawing_num_methods()
