steps = 1000000


def rectangle_method(start: float, end: float, case, f):
    """
    Calculates the integral sum by dividing it into rectangles equal in x
    and summing it up, taking the left vertical side of the rectangle with height f(x)
    as the value of the function

        Parameters:
            start (float): start point
            end (float): end point (float number)
            case: rectangle method (string variable)
            f: function under integral
        Return:
            sum(float): square under function
    """

    step = abs(end - start) / steps
    x = start
    sum = 0

    if case == 'left':
        while x < end:
            sum = sum + f(x) * step
            x = x + step
    elif case == 'right':
        while x < end:
            x = x + step
            sum = sum + f(x) * step
    elif case == 'middle':
        while x < end:
            x = (x + step) / 2
            sum = sum + f(x) * step
    else:
        raise ValueError('Choose one of the rectangle method: left, right or middle')

    return sum


def trapezium_method(start: float, end: float, f):
    """
    Calculates the integral sum by dividing it into trapezium equal in x
    and summing it up, taking the avarage value between previous point's value and next point's value by
    vertical side of the function

        Parameters:
            start (float): start point
            end (float): end point (float number)
            f: function under integral
        Return:
            sum(float): square under function
    """
    step = abs(end - start) / steps
    x = start
    sum = 0
    while x < end:
        sum = sum + (f(x - step) + f(x)) / 2 * step
        x = x + step
    return sum


def simpsons_rule(start: float, end: float, f):
    """
    Calculates the integral sum by simpsons rule. Simpson's Rule is a numerical method that approximates
    the value of a definite integral by using quadratic functions.

        Parameters:
            start (float): start point
            end (float): end point (float number)
            f: function under integral
        Return:
            sum(float): square under function
    """
    step = abs(end - start) / steps
    sum1 = 0
    sum2 = 0
    for i in range(1, int(steps / 2)):
        sum1 = sum1 + f(step * (2 * i - 1))
    for i in range(1, int(steps / 2 - 1)):
        sum2 = sum2 + f(step * (2 * i))

    sum = step / 3 * (f(start) + 4 * sum1 + 2 * sum2 + f(end))
    return sum