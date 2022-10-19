import math
from matplotlib import pyplot

# Масив містить значення фільмів і сукупних частот
arrfF10 = []
arrfF100 = []
arrfF1000 = []

arrfF = []
arrR = []    # масив повторюваних значень
arrInt = []  # масив інтервалів
arr = []     # масив всіх елементів  

n = 0        # кількість елементів

def Cf(arrfF):
    cf = 0 # сукупна частота
    
    for i in range(len(arrfF)):
        cf += arrfF[i][1]
        arrfF[i][2] = cf

def createArr(f, arrfF):    
    data = [int(item) for item in f]

    for el in data:
        flag = False
        k = 0
        
        if len(arrR) != 0:
            for i in arrR:
                if el == i:
                    flag = True
        
        if flag == False:
            for el1 in data:
                if el == el1:
                    k += 1
                        
            arrfF.extend([[el, k, 0]])
            arrR.append(el)
    
    arrfF = sorted(arrfF)
    Cf(arrfF)
    
    return arrfF      

def MaxFrequency(arrfF):
    max = 0
    index = 0
    
    for i in range(len(arrfF)):
        if arrfF[i][1] > max:
            max = arrfF[i][1]
            index = i
    
    print("---------------------------------------------------------")
    print()
    print("Фільм з максимальною кількістю переглядів(", max, ") :", arrfF[index][0])
    print()
    
    fileOutput.write("Фільм з максимальною кількістю переглядів (")
    fileOutput.write(str(max))
    fileOutput.write("): ")
    fileOutput.write(str(index + 1))
    fileOutput.write('\n')

def FrequencyTable(arrfF):
    print("--------- Таблиця частот ----------")
    print("Елемент | Частота | Сукупна частота")
    print("--------+---------+----------------")
    
    for i in range(len(arrfF)):
        print(arrfF[i][0], "\t|", arrfF[i][1], "\t  |", arrfF[i][2])
    
    print()
    
def FrequencyTableF(arrfF):
    
    # Вивід шапки таблиці у файл
    fileOutput.write('\n')
    fileOutput.write("--------- Таблиця частот: ---------")
    fileOutput.write('\n')
    fileOutput.write("Елемент | Частота | Сукупна частота")
    fileOutput.write('\n')
    fileOutput.write("--------+---------+----------------")
    fileOutput.write('\n')
    
    for i in range(len(arrfF)):
        fileOutput.write(str(arrfF[i][0]))
        fileOutput.write("       |")
        fileOutput.write(str(arrfF[i][1]))
        fileOutput.write("        |")
        fileOutput.write(str(arrfF[i][2]))
        fileOutput.write('\n')
    
    fileOutput.write('\n')
    
def moda(arrfF):
    fmax = []
    frmax = 0

    for i in range(len(arrfF)):
        if arrfF[i][1] > frmax:
            frmax = arrfF[i][1]          
    
    for i in range(len(arrfF)):
        if arrfF[i][1] == frmax:
            fmax.append(arrfF[i][0]) 
    
    if frmax == 1:
        print("Моди немає")  
        fileOutput.write("Моди немає") 
    else:  
        print("Мода:", end = " ")  
        fileOutput.write("Мода: ") 
        for i in range(len(fmax)):
            print(fmax[i], end = " ")
            fileOutput.write(str(fmax[i]))
            
    print()
    
def median(arrfF): 
    # створити масив з усіх значень з урахуванням частот
    for i in range(len(arrfF)):
        for j in range(arrfF[i][1]):
            arr.append(arrfF[i][0])
    
    if n % 2 == 0:
        index = n // 2 - 1         
        median = (arr[index] + arr[index + 1]) // 2 
        
    else:   
        index = (n + 1) // 2 - 1                                                                                    
        median = arr[index]
        
    print("Медіана:", median)
    fileOutput.write("Медіана: ")
    fileOutput.write(str(median))
    fileOutput.write('\n')
    print()                                                                           
    
def average(arrfF):
    Xave = 0
    numerator = 0
    denominator = 0
    
    for i in range(len(arrfF)):
        numerator += arrfF[i][0] * arrfF[i][1]
        denominator += arrfF[i][1]
        
    Xave = numerator / denominator
    
    return Xave
    
def dispersion(arrfF): # Дисперсія і середнє квадратичне відхилення 
    numerator = 0
    denominator = 0
    Xave = average(arrfF)
    
    for i in range(len(arrfF)):
        numerator += arrfF[i][1] * math.pow(arrfF[i][0] - Xave, 2)
        denominator += arrfF[i][1]
        
    dis = numerator / denominator # дисперсія
    print("Дисперсія:", round(dis))
    
    fileOutput.write("Дисперсія: ")
    fileOutput.write(str(round(dis)))
    fileOutput.write('\n')
    
    msd = math.sqrt(dis)
    print("Середнє квадратичне відхилення:", round(msd))
    
    fileOutput.write("Середнє квадратичне відхилення: ")
    fileOutput.write(str(round(msd)))
    fileOutput.write('\n')
    
def MaxEl(arrfF):
    max = 0
    
    for i in range(len(arrfF)):
        if arrfF[i][0] > max:
            max = arrfF[i][0]
            
    return max
    
def histogram(arrfF):
    p = 0 # параметр для інтервалів
    interval = int(round(MaxEl(arrfF) / 25)) 
    
    # інтервали
    while (len(arrInt) <= MaxEl(arrfF) / interval + 1):
        arrInt.append(p)
        p += interval

    
    pyplot.hist(arr, arrInt, edgecolor = 'k', alpha = 0.5)
    pyplot.title("Гістограма")
    pyplot.xlabel("Фільми")
    pyplot.ylabel("Кількість переглядів")
    pyplot.show()

def func(file, arrfF):

    arrfF = createArr(file, arrfF)
    MaxFrequency(arrfF)
    
    FrequencyTable(arrfF) # Вивід таблиці 
    FrequencyTableF(arrfF) # Запис таблиці у файл

    moda(arrfF)
    fileOutput.write('\n')
    median(arrfF)
    fileOutput.write('\n')

    dispersion(arrfF)

    histogram(arrfF)

def mainf():
    print("Введіть значення кількості елементів у вхідному файлі (10/100/1000):")
    n = int(input())

    if n == 10:
        file = open('e:/UNI/2 курс/YOPI/lab_1/input/task_01_data/input_10.txt').read().split('\n')[1:]
        func(file, arrfF10)
    elif n == 100:
        file = open('e:/UNI/2 курс/YOPI/lab_1/input/task_01_data/input_100.txt').read().split('\n')[1:]
        func(file, arrfF100)
    elif n == 1000:
        file = open('e:/UNI/2 курс/YOPI/lab_1/input/task_01_data/input_1000.txt').read().split('\n')[1:]
        func(file, arrfF1000)
    
    
fileOutput = open('e:/UNI/2 курс/YOPI/lab_1/output.txt', 'w')
mainf()
fileOutput.close()