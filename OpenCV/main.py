import cv2
                                                            # Mask?

image = cv2.imread("fight_club.jpg")                     # Downloading image
b, g, r = cv2.split(image)
cv2.imshow('Green image', g)                       # Showing green image (a)

clone1 = g.copy()
clone2 = g.copy()      # Cloning green image (b)

maximum = g[..., 1].max()
minimum = g[..., 1].min()                       # Finding max and min values of green image (c)

thresh = (maximum - minimum) / 2

dimensions = clone1.shape

height1 = clone1.shape[0]
width1 = clone1.shape[1]

for i in range(0, width1):
    for j in range(0, height1):
        clone1[j, i] = thresh            # Editing pixels values to thresh (d)

height2 = clone2.shape[0]
width2 = clone2.shape[1]

for i in range(0, width2):
    for j in range(0, height2):
        clone2[j, i] = 0

cv2.compare(g, clone1, cv2.CMP_GE, clone2)                  # (e)

difference = cv2.subtract(g, thresh/2, g, clone2)   # Subtracting image and showing results (f)
cv2.imshow('Difference', difference)

cv2.waitKey(0)

