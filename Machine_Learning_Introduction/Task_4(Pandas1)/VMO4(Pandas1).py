import pandas as pd
import matplotlib.pyplot as plt
import numpy as np

# first part starts
IBM = pd.read_csv('IBM.csv', sep=';')
compressed_IBM = IBM.groupby(np.arange(len(IBM)) // 4).sum()   # month = 4 weeks
IBM_months = compressed_IBM.drop(compressed_IBM.columns[[0, 1, 2, 3]], axis=1)
IBM_months.plot.bar()
plt.title('Avarage months trade volume')
plt.show()
# first part ends

# second part starts
compressed_IBM = IBM.groupby(np.arange(len(IBM)) // 42).mean() # year = 42 weeks
IBM_years = compressed_IBM.drop(compressed_IBM.columns[[0, 1, 2, 4]], axis=1)
print(IBM_years)
# second part ends