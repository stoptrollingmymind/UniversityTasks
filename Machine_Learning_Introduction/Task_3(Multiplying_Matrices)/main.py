import numpy as np


def multiply_matrix(matrix_1, matrix_2):
    buf = 0
    matrix_result = []
    buf_row = []
    if matrix_1.shape[1] == matrix_2.shape[0]:
        for i in range(0, matrix_1.shape[0]):
            for j in range(0, matrix_2.shape[1]):
                for z in range(0, matrix_2.shape[0]):
                    buf = buf + matrix_1[i, z] * matrix_2[z, j]
                buf_row.append(buf)
                buf = 0
            matrix_result.append(buf_row)
            buf_row = []
        return matrix_result
    else:
        raise Exception('Такие матрицы нельзя умножать !')


if __name__ == '__main__':
    matrix_cells_1 = int(input('Введите количество столбцов в матрице 1 - '))
    matrix_rows_1 = int(input('Введите количество строк в матрице 1 - '))
    matrix_1 = (0 - (-10)) * np.random.random_sample((matrix_rows_1, matrix_cells_1))
    print('\tMATRIX1\n', matrix_1)

    matrix_cells_2 = int(input('Введите количество столбцов в матрице 2 - '))
    matrix_rows_2 = int(input('Введите количество строк в матрице 2 - '))
    matrix_2 = (0 - (-10)) * np.random.random_sample((matrix_rows_2, matrix_cells_2))
    print('\n\tMATRIX2\n', matrix_2)

    matrix_result = multiply_matrix(matrix_1, matrix_2)
    print('\n\tMATRIX_RESULT')
    for item in matrix_result:
        print(item)
