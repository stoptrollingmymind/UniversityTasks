import numpy as np
import matplotlib.pyplot as plt


def bisection_method(a, b, f, e):
    """
    The bisection method is a root-finding method
    that applies to any continuous functions for which one knows two values with opposite signs.

    Args:
        a (double): Segment start
        b (double): End of segment
        f (function): Nonlinear equation
        e (double): Accuracy
    Returns:
        x (double): Solution of nonlinear equation
    """
    if f(a) * f(b) > 0:
        raise Exception("The scalars a and b do not bound a root")
    else:
        x = (a + b) / 2
        if np.abs(f(x)) < e:
            return x
        elif np.sign(f(a)) == np.sign(f(x)):
            return bisection_method(x, b, f, e)
        elif np.sign(f(b)) == np.sign(f(x)):
            return bisection_method(a, x, f, e)

def newtons_method(a, b, f, f_1, e):
    """
    The newton's method is a root-finding algorithm
    which produces successively better approximations to the roots (or zeroes) of a real-valued function.

    Args:
        a (double): Segment start
        b (double): End of segment
        f (function): Nonlinear equation
        f_1(function): Derivative of nonlinear equation
        e (double): Accuracy
    Returns:
        x (double): Solution of nonlinear equation
    """
    x_0 = (a + b) / 2
    xn = f(x_0)
    xn_1 = xn - (f(xn) / f_1(xn))
    while np.abs(xn_1 - xn) > e:
        xn = xn_1
        xn_1 = xn - (f(xn) / f_1(xn))
    return xn_1


def chord_method(a, b, f):
    """
    The chord method is used for finding root of the function in given interval.

    Args:
        a (double): Segment start
        b (double): End of segment
        f (function): Nonlinear equation
    Returns:
        x (double): Solution of nonlinear equation
    """
    if f(a) * f(b) >= 0:
        raise Exception("The scalars a and b do not bound a root")
    an = a
    bn = b
    for n in range(1000):
        x = an - f(an) * (bn - an) / (f(bn) - f(an))
        if f(an) * f(x) < 0:
            bn = x
        elif f(bn) * f(x) < 0:
            an = x
        elif f(x) == 0:
            return x
        else:
            raise Exception("No roots in this interval.")
    return x


if __name__ == "__main__":
    f = lambda x: x**2 - 30 * x + 10 * np.cos(x)
    f_1=lambda x: 2 * x - 30 - 10 * np.sin(x)
    e = 0.00000000001
    x = np.linspace(-10, 10, 1000)
    plt.plot(x, f(x))
    plt.show()
    a = float(input('Segment start: '))
    b = float(input('End of segment: '))
    print("Bisection method: ", bisection_method(a, b, f, e))
    print("Newton's method: ", newtons_method(a, b, f, f_1, e))
    print("Chord method: ", chord_method(a, b, f))



