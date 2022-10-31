#from cgitb import reset
import math
import numpy
from matplotlib import pyplot

arr = [] # масив оцінок
arrf = [] 

# заповнити масив елементами
def createArr(f, arr):    
    for item in f:
        arr.append(int(item))
    
    arr = sorted(arr)
    
    return arr  

# --------------- Персентилі --------------
# номер елемента
def percTH(arr, k):
    p = k / 100 * (len(arr) + 1)
    
    return p # номер

def percentile(arr, k):
    pn = percTH(arr, k)
    x = math.modf(pn) # 0 - дробова частина; 1 - ціла частина
    if x[1] != 0:
        p = arr[int(x[1]) - 1] + x[0] * (arr[int(x[1])] - arr[int(x[1]) - 1])
    
        return p # значення

# -------------- Середнє квадратичне відхилення --------------
def frequency(arr):
    global arrf
    arrR = [] # масив повторюваних значень
    
    for el in arr:
        flag = False                 # визначити оцінку, як ту, яка ще не повторювалась
        f = 0                        # частота
        
        if len(arrR) != 0: 
            for i in arrR:
                if el == i:          # якщо оцінка співпадає з тією, що вже була
                    flag = True      # визначити її як вже враховану
        
        if flag == False:            # якщо такої оцінки ще не було
            for el1 in arr:          # шукати частоту
                if el == el1:
                    f += 1
                        
            arrf.extend([[el, f]])   # заповнити масив оцінками і їх частотами
            arrR.append(el)          # внести оброблену оцінку в масив повторюваних значень
            
    return arrf

def average(arr):
    Xave = 0
    numerator = 0
    denominator = 0
    
    for i in range(len(arr)):
        numerator += arr[i][0] * arr[i][1]
        denominator += arr[i][1]
        
    Xave = numerator / denominator
    
    return Xave

def deviation(arr):
    numerator = 0
    denominator = 0

    arrf = frequency(arr)
    Xave = average(arrf)
    
    # дисперсія
    for i in range(len(arrf)):
        numerator += arrf[i][1] * math.pow(arrf[i][0] - Xave, 2)
        denominator += arrf[i][1]
        
    dis = numerator / denominator 
    
    # середнє квадратичне відхилення
    msd = math.sqrt(dis)
    print("Середнє квадратичне відхилення:", round(msd, 3))
    
    fileOutput.write("Середнє квадратичне відхилення: ")
    fileOutput.write(str(round(msd, 2)))
    fileOutput.write('\n\n')

# ------------ Шкала оцінок -------------
def lin(arr):
    print("y = a*x + b")
    print("y~ = a*x~ + b")
    
    print("Оцінка 100 лишається 100:            100 = a*100 + b")
    print("Середнє значення оцінок = 95:        95 = a*x~ + b")
    
    Xavg = average(arrf)
    x = numpy.array ([[100, 1], [Xavg, 1]])
    y = numpy.array ([[100], [95]])
    
    res = numpy.linalg.solve(x, y)
    
    print("Шкала: y =", *numpy.round(res[0], 3),"* x +", *numpy.round(res[1], 3))
    
    fileOutput.write("Шкала: y = ")
    fileOutput.write(str(*numpy.round(res[0], 3)))
    fileOutput.write(" * x + ")
    fileOutput.write(str(*numpy.round(res[1], 3)))
    fileOutput.write('\n\n')

# ---------- Діаграма стовбур-листя -----------
def createDict(arr):
    values = []
    dict_ = {}
    First = True
    curKey = -1
    
    for i in range(len(arr)):
        el = arr[i] / 10
        x = math.modf(el)
        
        if(curKey != int(x[1]) and First != True): 

            dict_[curKey] = values
            values = []
        First = False
         
        values.append(int(round(x[0], 1) * 10))        
        curKey = int(x[1])
        
    dict_[curKey] = values
    return dict_

def leaf(arr):
    dict_ = createDict(arr)
    
    print("----- Діаграма стовбур-листя ------")
    print("Ключ: 1|1 = 11")
    print()
    
    for key, value in dict_.items():
        print(key, "\t|", *value)
    
    # запис у файл
    fileOutput.write('\n')
    fileOutput.write("----- Діаграма стовбур-листя ------\n")
    fileOutput.write("Ключ: 1|1 = 11")
    fileOutput.write('\n')
    
    for key, value in dict_.items():
        fileOutput.write(str(key))
        fileOutput.write("\t|")
        for el in value:
            fileOutput.write(str(el))
            fileOutput.write(" ")
        fileOutput.write('\n')
    
    fileOutput.write('\n')
   
# ----------- Коробкова діаграма ---------------- 
def BoxDiagram(arr):
    pyplot.title("Коробковий графік")
    
    pyplot.boxplot(x = arr, 
                patch_artist  = True, # власний колір
                widths = 0.2,
                boxprops = {'color':'black','facecolor':'#69f745'}, 
                medianprops = {'linestyle':'--','color':'black'}) 

    pyplot.show()

# ---------- Основні функції ---------------
def func(file, arr):

    arr = createArr(file, arr)

    # квартиль 1, квартиль 3, персентиль 90
    q1 = percentile(arr, 25) # Q1 = P25
    print("Q1:", q1)
    fileOutput.write("Q1: ")
    fileOutput.write(str(q1))
    fileOutput.write('\n')

    q3 = percentile(arr, 75) # Q3 = P75
    print("Q3:", q3)
    fileOutput.write("Q3: ")
    fileOutput.write(str(q3))
    fileOutput.write('\n')
    
    p90 = percentile(arr, 90)
    print("P90:", p90)
    fileOutput.write("P90: ")
    fileOutput.write(str(p90))
    fileOutput.write('\n\n')   
    print()
    
    deviation(arr)
    print() 
    
    lin(arr)
    print()
    
    leaf(arr)
    print()
    
    BoxDiagram(arr)
    
def mainf():
    print("Введіть значення кількості елементів у вхідному файлі (10/100):")
    n = int(input())

    if n == 10:
        file = open('e:/UNI/2 курс/YOPI/lab_2/task_02_data/input_10.txt').read().split('\n')[1:]
        func(file, arr)
    elif n == 100:
        file = open('e:/UNI/2 курс/YOPI/lab_2/task_02_data/input_100.txt').read().split('\n')[1:]
        func(file, arr)
    
    
fileOutput = open('e:/UNI/2 курс/YOPI/lab_2/output.txt', 'w')
mainf()
fileOutput.close()