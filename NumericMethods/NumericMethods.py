import matplotlib.pyplot as plt
import numpy as np

interval_start = -1
interval_end = 1
delta_x = 0.1
steps = int((interval_end - interval_start)/delta_x+1)


def real_function(x, y):
    return 1 / (x + 2 * y)


def eulers_method(x_previous, y_previous):
    y = y_previous + delta_x * real_function(x_previous, y_previous)
    return y


def improved_eulers_method_1(x_previous, y_previous):
    y = y_previous + delta_x * real_function(x_previous+delta_x/2, y_previous + delta_x/2
                                             * real_function(x_previous,y_previous))
    return y


def improved_eulers_method_2(x_previous, y_previous):
    y = y_previous + delta_x / 2 * (real_function(x_previous, y_previous) +
            real_function(x_previous + delta_x, y_previous + delta_x * real_function(x_previous, y_previous)))
    return y


def improved_eulers_method_3(x_previous, y_previous, y_previous_previous):
    y = y_previous_previous + 2 * delta_x * real_function(x_previous, y_previous)
    return y


def list_y_function(foo, list_x, y: float = 0):
    list_y = []
    list_y.append(y)

    if foo == improved_eulers_method_3:
        y = y + delta_x * real_function(interval_start, y)
        list_y.append(y)
        for i in range(2, steps):
            y = foo(list_x[i-1], list_y[i-1], list_y[i-2])
            list_y.append(y)

    else:
        for i in range(1, steps):
            y = foo(list_x[i - 1], list_y[i - 1])
            list_y.append(y)

    return list_y


def render_drawing_num_methods():
    x = np.linspace(interval_start, interval_end, steps)

    y = list_y_function(eulers_method, x)
    plt.plot(x, y, label='eulers_method')

    y = list_y_function(improved_eulers_method_1, x)
    plt.plot(x, y, label='improved_eulers_method_1')

    y = list_y_function(improved_eulers_method_2, x)
    plt.plot(x, y, label='improved_eulers_method_2')

    y = list_y_function(improved_eulers_method_3, x)
    plt.plot(x, y, label='improved_eulers_method_3')

    plt.legend()
    plt.show()


if __name__ == '__main__':
    render_drawing_num_methods()
