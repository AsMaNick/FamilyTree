import sys
import os
import codecs
import msvcrt

def getLines(file : str) -> int:
    res = 0
    f = codecs.open(file, "r", "utf_8_sig")
    for line in f:
        res += 1
    f.close()
    return res

total = 0

all = []

for file in os.listdir("./"):
    if (len(file) >= 12 and file[-12:] == ".Designer.cs"):
        continue
    if len(file) >= 3 and file[-3:] == ".cs":
        lines = getLines(file)
        all.append([lines, file])
        total += lines

all = sorted(all)
all = reversed(all)
for row in all:
    print(row[1], row[0])
print("total:", total)

while True:
    if msvcrt.kbhit():
        break