import math
import numpy
from matplotlib import pyplot

x = []
y = []

# заповнити масив елементами
def createArr(f):    
    for item in f:
        item = item.replace(',','.')
        x.append(float(item.partition('\t')[0]))
        y.append(float(item.partition('\t')[2]))
       
    return x, y


# ---------- Діаграма розсіювання ---------------
def scatter(x, y):
    
    pyplot.scatter(x, y, edgecolor = 'k', alpha = 0.5)
    pyplot.title("Діаграма розсіювання")
    pyplot.xlabel("Час, проведений у супермаркеті")
    pyplot.ylabel("Сума покупки")
    pyplot.show()


# ---------- Центр ваги і коваріація ---------------
# середнє значення
def average(arr):
    numerator = 0
    
    for i in range(len(arr)):
        numerator += arr[i]
        
    ave = numerator / len(arr)
    
    return ave

# центр ваги
def CenterOfGravity(x, y):
    Xave = average(x)
    Yave = average(y)

    print("Центр ваги: G(", round(Xave, 3), ",", round(Yave, 3), ")")
    
    fileOutput.write("Центр ваги: G(")
    fileOutput.write(str(round(Xave, 3)))
    fileOutput.write(", ")
    fileOutput.write(str(round(Yave, 2)))
    fileOutput.write(")")
    fileOutput.write('\n')
    
    
# коваріація
def cov(x, y, flag):
    Xave = average(x)
    Yave = average(y)
    sumXY = 0
    
    for i in range(len(x)):
        sumXY += x[i] * y[i]
    
    Cov = 1 / len(x) * sumXY - Xave * Yave
    
    if flag == True:
        print("Коваріація: cov =", round(Cov, 3))
        
        fileOutput.write("Коваріація: cov = ")
        fileOutput.write(str(round(Cov, 3)))
        fileOutput.write('\n\n')
    else:
        return Cov


# ---------- Лінія регресії ---------------
# дисперсія
def Var(arr):
    Xave = average(arr)
    sumX = 0
    
    for i in range(len(arr)):
        sumX += math.pow(arr[i], 2)
        
    dis = 1 / len(arr) * sumX - math.pow(Xave, 2)
    return dis

# лінія регресії
def regression(x, y):
    
    # y = b1x + b0
    b1 = cov(x, y, False) / Var(x)
    
    Xave = average(x)
    Yave = average(y)
    
    b0 = Yave - b1 * Xave
    
    print("Лінія регресії: y =", round(b1, 3), "* x", round(b0, 3))
    
    fileOutput.write("Лінія регресії: y = ")
    fileOutput.write(str(round(b1, 3)))
    fileOutput.write("* x ")
    fileOutput.write(str(round(b0, 3)))
    fileOutput.write('\n')
    
    #тренд
    if b1 > 0:
        print("Тренд є позитивним")
        fileOutput.write("Тренд є позитивним")
        fileOutput.write('\n\n')
    elif b1 < 0:
        print("Тренд є негативним")  
        fileOutput.write("Тренд є негативним")
        fileOutput.write('\n\n') 
    
    # побудова
    y1 = []
    for x1 in x:
        res = b1 * x1 + b0
        y1.append(res)

    pyplot.plot(x, y1, color = 'lawngreen', label = 'Лінія регресії', linewidth = 2)
    
    pyplot.scatter(x, y, edgecolor = 'k', alpha = 0.5)
    pyplot.title("Діаграма розсіювання")
    pyplot.xlabel("Час, проведений у супермаркеті")
    pyplot.ylabel("Сума покупки")
    pyplot.legend()
    
    pyplot.show()


# ---------- Коефіцієнт кореляції ---------------
def correlation(x, y):
    sx = math.sqrt(Var(x))
    sy = math.sqrt(Var(y))

    r = cov(x, y, False) / (sx * sy)
    
    print("Коефіцієнт кореляції:", round(r, 3))
    
    fileOutput.write("Коефіцієнт кореляції: ")
    fileOutput.write(str(round(r, 3)))
    fileOutput.write('\n\n') 
    print()
    
    # висновки щодо значення коефіцієна кореляції
    r0 = math.sqrt(3) / 2
    if r == 1 or r == -1:
        print("Точки лежать на лінії регресії")
        fileOutput.write("Точки лежать на лінії регресії")
        fileOutput.write('\n') 
    elif r > r0 or r < r0:
        print("Між даними існує сильна лінійна залежність")
        fileOutput.write("Між даними існує сильна лінійна залежність")
        fileOutput.write('\n')
    elif r == 0:
        print("Дані лінійно незалежні")
        fileOutput.write("Дані лінійно незалежні")
        fileOutput.write('\n\n')
    else:
        print("Між даними існує слабка лінійна залежність")
        fileOutput.write("Між даними існує слабка лінійна залежність")
        fileOutput.write('\n')
        
    if r < 0:
        print("Залежність є негативною")
        fileOutput.write("Залежність є негативною")
        fileOutput.write('\n\n')
    elif r > 0:
        print("Залежність є позитивною")
        fileOutput.write("Залежність є позитивною")
        fileOutput.write('\n\n')
        

# ---------- Основні функції ---------------
def func(file):
    x, y = createArr(file)
    
    scatter(x, y)
    
    CenterOfGravity(x, y)
    print()
    
    cov(x, y, True)
    print()
    
    regression(x, y)
    print()
    
    correlation(x, y)
    
def mainf():
    print("Введіть значення кількості елементів у вхідному файлі (10/100):")
    n = int(input())

    if n == 10:
        file = open('e:/UNI/2 курс/YOPI/lab_3/task_03_data/input_10.txt').read().split('\n')[1:]
        func(file)
    elif n == 100:
        file = open('e:/UNI/2 курс/YOPI/lab_3/task_03_data/input_100.txt').read().split('\n')[1:]
        func(file)
    
    
fileOutput = open('e:/UNI/2 курс/YOPI/lab_3/output.txt', 'w')
mainf()
fileOutput.close()