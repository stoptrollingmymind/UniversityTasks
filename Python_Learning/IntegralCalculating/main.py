import math


steps = 1000000


def left_rectangle_method(start: float, end: float, f):
    step = abs(end - start) / steps
    x = start
    sum = 0
    while x < end:
        sum = sum + f(x) * step
        x = x + step
    return sum


def trapezium_method(start: float, end: float, f):
    step = abs(end - start) / steps
    x = start
    sum = 0
    while x < end:
        sum = sum + (f(x-step) + f(x)) / 2 * step
        x = x + step
    return sum


def simpsons_method(start: float, end: float, f):
    step = abs(end - start) / steps
    sum1 = 0
    sum2 = 0
    for i in range(1, int(steps / 2)):
        sum1 = sum1 + f(step * (2 * i - 1))
    for i in range(1, int(steps / 2 - 1)):
        sum2 = sum2 + f(step * (2 * i))

    sum = step / 3 * (f(start) + 4 * sum1 + 2 * sum2 + f(end))
    return sum


def integral(start: float, end: float, calculating_method, f):
    sum = calculating_method(start, end, f)
    return sum


if __name__ == '__main__':
    print(integral(0, math.pi * 2, simpsons_method, math.cos))
    print(integral(0, math.pi * 2, trapezium_method, math.cos))
    print(integral(0, math.pi * 2, rectangle_method, math.cos))
