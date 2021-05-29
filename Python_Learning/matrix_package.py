matrix_1 = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]
matrix_2 = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]


def transposition(matrix):
    for row in matrix:
        if len(row) != len(matrix):
            raise Exception('MATRIX MUST BE SQUARE')
    for i in range(len(matrix)):
        for j in range(i):
            matrix[i][j], matrix[j][i] = matrix[j][i], matrix[i][j]
    return matrix


# TODO: remake multiplying function
def multiplying(matrix_1, matrix_2):
    buf = 0
    matrix_result = []
    buf_row = []

    for i in range(0, len(matrix_1)):
        for j in range(0, len(matrix_2[0])):
            for z in range(0, len(matrix_2)):
                buf = buf + matrix_1[i, z] * matrix_2[z, j]
            buf_row.append(buf)
            buf = 0
        matrix_result.append(buf_row)
        buf_row = []
    return matrix_result

print(transposition(matrix_1))
print(multiplying(matrix_1, matrix_2))