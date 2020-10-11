import matplotlib.pyplot as plt
import numpy as np


real_function = lambda x, y: 1/(x+2*y)


def k_1_rk4(x, y, h):
    k = real_function(x + h/2, y + h/2 * real_function(x, y))
    return k


def k_2_rk4(x, y, h):
    k = real_function(x + h/2, y + h/2 * k_1_rk4(x, y, h))
    return k


def k_3_rk4(x, y, h):
    k = real_function(x + h, y + h * k_2_rk4(x, y, h))
    return k


def run_kut_4(x, h, first_y):
    y_list = [first_y]
    for i in range(1, np.size(x)):
        y_list.append(y_list[i-1] + h / 6 * (real_function(x[i-1], y_list[i-1])
                            + 2 * k_1_rk4(x[i-1], y_list[i-1], h) + 2 * k_2_rk4(x[i-1], y_list[i-1], h)
                         + k_3_rk4(x[i-1], y_list[i-1], h)))
    return y_list


def addams_4(x, h, first_y):
    y_list = [first_y]
    y_list.append(y_list[0] + h * real_function(x[0], y_list[0]))
    y_list.append(y_list[1] + h * real_function(x[1], y_list[1]))
    y_list.append(y_list[2] + h * real_function(x[2], y_list[2]))
    for i in range(4, np.size(x)):
        y_list.append(y_list[i-1] + h/24*(55*real_function(x[i-1], y_list[i-1])-59*real_function(x[i-2], y_list[i-2])
                         + 37*real_function(x[i-3], y_list[i-3]) - 9 * real_function(x[i-4], y_list[i-4])))
    return y_list


def addams_3(x, h, first_y):
    y_list = [first_y]
    y_list.append(y_list[0] + h * real_function(x[0], y_list[0]))
    y_list.append(y_list[1] + h * real_function(x[1], y_list[1]))
    for i in range(3, np.size(x)):
        y_list.append(y_list[i-1] + h/12*(23*real_function(x[i-1], y_list[i-1]) - 16*real_function(x[i-2], y_list[i-2])
                           + 5*real_function(x[i-3], y_list[i-3])))
    return y_list


def euler_method(x, h, first_y):
    y_list = [first_y]
    for i in range(1, np.size(x)):
        y_list.append(y_list[i-1] + h * real_function(x[i], y_list[i-1]))
    return y_list


def euler_modificated(x, h, first_y):
    y_list = [first_y]
    for i in range(1, np.size(x)):
        y_list.append(y_list[i-1] + h * real_function(x[i-1]+h/2, y_list[i-1]
                                                      + h/2 * real_function(x[i-1], y_list[i-1])))
    return y_list


def euler_recount(x, h, first_y):
    y_list = [first_y]
    for i in range(1, np.size(x)):
        y_list.append(y_list[i-1] + h / 2 * (real_function(x[i-1], y_list[i-1])
                                 + real_function(x[i-1] + h, y_list[i-1] + h * real_function(x[i-1], y_list[i-1]))))
    return y_list


def euler_central(x, h, first_y):
    y_list = [first_y]
    y_list.append(y_list[0] + h * real_function(x[0], y_list[0]))
    for i in range(2, np.size(x)):
        y_list.append(y_list[i-2] + 2 * h * real_function(x[i-1], y_list[i-1]))
    return y_list


def draw_num_method(foo, interval_start, interval_end, str_method: str):
    h = [0.1, 0.05, 0.01]
    for i in range(0, np.size(h)):
        steps = int((interval_end - interval_start) / h[i])
        x = np.linspace(interval_start, interval_end, steps)
        y = foo(x, h[i], interval_start)
        plt.plot(x, y, label= h[i])
        plt.title(str_method)
    plt.legend()
    plt.show()

if __name__ == '__main__':
    draw_num_method(addams_3, -1.0, 1.0, 'addams_3')
    draw_num_method(addams_4, -1.0, 1.0, 'addams_4')
    draw_num_method(run_kut_4, -1.0, 1.0, 'run_kut_4')
    draw_num_method(euler_method, -1.0, 1.0, 'euler_method')
    draw_num_method(euler_modificated, -1.0, 1.0, 'euler_modificated')
    draw_num_method(euler_recount, -1.0, 1.0, 'euler_recount')
    draw_num_method(euler_central, -1.0, 1.0, 'euler_central')

