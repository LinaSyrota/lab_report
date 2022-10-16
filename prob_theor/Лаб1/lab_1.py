import math
from matplotlib import pyplot

file10 = open('e:/UNI/2 курс/YOPI/lab_1/input/task_01_data/input_10.txt')
file100 = open('e:/UNI/2 курс/YOPI/lab_1/input/task_01_data/input_100.txt')
file1000 = open('e:/UNI/2 курс/YOPI/lab_1/input/task_01_data/input_1000.txt')

f10 = file10.read().split('\n')[1:]
f100 = file100.read().split('\n')[1:]
f1000 = file1000.read().split('\n')[1:]

# Масив містить значення фільмів і сукупних частот
arrfF10 = []
arrfF100 = []
arrfF1000 = []

arrfF = []
arrInt = [] # масив інтервалів
arr = [] # масив всіх елементів

def frequency(f, arrfF):
    number = 0 # фільм
    cf = 0 # сукупна частота
    
    data = [int(item) for item in f]

    for el in data:
        number += 1
        cf += el
        arrfF.extend([[number, el, cf]])
    
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
    print("Фільм з максимальною кількістю переглядів (", max, "):", index + 1)
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
        print(i + 1, "\t|", arrfF[i][1], "\t  |", arrfF[i][2])
    
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
        fileOutput.write(str(i + 1))
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
            fmax.append(i + 1) 
    
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
    median = 0
    n = arrfF[len(arrfF) - 1][2] # в якості кількості елементів взято сукупну частоту останнього елемента
    index = 0 # індекс елемента n/2
    
    if n % 2 == 0:
        for i in range(len(arrfF)):
            if n / 2 > arrfF[i][2] and n / 2 <= arrfF[i + 1][2]:
                index = i + 1
                 
        median = (arrfF[index][0] + arrfF[index + 1][0]) / 2 
        
    else:   
        for i in range(len(arrfF)):
            if (n + 1) / 2 > arrfF[i][2] and (n + 1) / 2 <= arrfF[i + 1][2]:
                index = i + 1                                                                                       
        median = arrfF[index][0]    
        
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
    
def histogram(arrfF):
    interval = 0
    p = 1 # параметр для інтервалів
    
    if arrfF == arrfF10:
        interval = len(arrfF) / 10
    elif arrfF == arrfF100:
        interval = len(arrfF) / 20
    elif arrfF == arrfF1000:
        interval = len(arrfF) / 50
    
    # створити масив з усіх значень з урахуванням частот
    for i in range(len(arrfF)):
        for j in range(arrfF[i][1]):
            arr.append(arrfF[i][0])
    
    # інтервали
    while (len(arrInt) <= len(arrfF) / interval + 1):
        arrInt.append(p)
        p += interval

    
    pyplot.hist(arr, arrInt, edgecolor = 'k', alpha = 0.5)
    pyplot.title("Гістограма")
    pyplot.xlabel("Фільми")
    pyplot.ylabel("Кількість переглядів")
    pyplot.show()

def func(file, arrfF):

    arrfF = frequency(file, arrfF)
    MaxFrequency(arrfF)
    
    FrequencyTable(arrfF) # Вивід таблиці 
    FrequencyTableF(arrfF) # Запис таблиці у файл

    moda(arrfF)
    fileOutput.write('\n')
    median(arrfF)
    fileOutput.write('\n')

    dispersion(arrfF)

    histogram(arrfF)

fileOutput = open('e:/UNI/2 курс/YOPI/lab_1/output.txt', 'w')

print("Введіть значення кількості елементів у вхідному файлі (10/100/1000):")
n = int(input())

if n == 10:
    func(f10, arrfF10)
elif n == 100:
    func(f100, arrfF100)
elif n == 1000:
    func(f1000, arrfF1000)
    
fileOutput.close()