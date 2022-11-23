import math
from sympy import *

def factorial(n):
    if n == 1 or n == 0:
        return 1
    else:
        return n * factorial(n - 1)
    
def C(n, k):
    c = factorial(n) / (factorial(k) * factorial(n - k))
    return c

def X(n, m, p):
    q = 1 - p
    
    x = (m - n * p) / math.sqrt(n * p * q)
    return x

def Fi_Gauss_local(x):
    exp = math.e
    f = math.pow(exp, - math.pow(x, 2) / 2) / math.sqrt(2 * math.pi)
    return f

def integerK(Kmin, Kmax):
    i = int(Kmin)
    k = Kmin
    while i <= Kmax:
        if i >= Kmin:
            k = i
        
        i += 1  
        
    return k

def Fi_Gauss_integral(X):
    x = Symbol('x')
    expr = (1 / math.sqrt(2 * math.pi)) * integrate((exp(-(x ** 2) / 2)), (x, 0, x))
    
    if X > 5:
        result = 0.5
    elif X < -5:
        result = -0.5
    else:
        result = expr.evalf(subs={x: X})
    
    return result
     
def task_1():
    print("Завдання 1")
    print()
    
    print("Умова:")
    print("Ймовірність знаходження в кожному прибулому потязі вагонів на дане призначення 0,2. Визначити ймовірність того, що в трьох із п’яти потягів, які прибувають протягом однієї години, будуть вагони на дане призначення.")
    print()
    
    total = 5
    selected = 3
    p = 0.2
    
    P = C(5, 3) * math.pow(p, selected) * math.pow(1 - p, total - selected)
    print("Відповідь:", round(P, 3))  
    print("-------------------------------------------------------")
    print()
    
def task_2():
    print("Завдання 2")
    print()
    
    print("Умова:")
    print("Знайти ймовірність того, що в п’яти незалежних випробуваннях подія А відбудеться: а) рівно 4 рази; б) не менше 4 разів, якщо в кожному випробуванні ймовірність появи події становить 0,8.")
    print()
    
    total = 5
    selected = 4 # 4 або не менше 4 разів
    p = 0.8
    
    P4 = C(5, 4) * math.pow(p, selected) * math.pow(1 - p, total - selected)
    P5 = C(5, 5) * math.pow(p, selected + 1) * math.pow(1 - p, total - (selected + 1))
    P45 = P4 + P5
    
    print("Відповідь:")
    print("а)", round(P4, 3))
    print("б)", round(P45, 3))  
    print("-------------------------------------------------------")
    print()
    
def task_3_4_8_9(task, total, selected, p):
    if task == 3:
        print("Завдання 3")
        print()
        
        print("Умова:")
        print("На кондитерській фабриці 20% всіх цукерок складають льодяники. Знайти ймовірність того, що серед 400 вибраних навмання цукерок буде рівно 80 льодяників.")
    elif task == 4:
        print("Завдання 4")
        print()
        
        print("Умова:")
        print("На автомобільному заводі у звичному режимі роботи з конвеєра сходить 100000 автомобілів. Ймовірність бракованого автомобіля дорівнює 0,0001. Знайти ймовірність того, що з конвеєра зійшло 5 бракованих автомобілів.")
    elif task == 8:
        print("Завдання 8")
        print()
        
        print("Умова:")
        print("Яка ймовірність того, що при 10000 незалежних киданнях монети герб випаде 5000 разів?")
    elif task == 9:
        print("Завдання 9")
        print()
        
        print("Умова:")
        print("Фірма відправила на базу 1000 якісних виробів. Ймовірність того, що вироби в дорозі пошкодяться дорівнює 0,002. Знайти ймовірність того, що на базу прибуде 5 пошкоджених виробів.")
    print()
    
    x = X(total, selected, p)
    f = Fi_Gauss_local(x)
    
    P = f / math.sqrt(total * p * (1 - p))
    print("Відповідь:", round(P, 3))  
    print("-------------------------------------------------------")
    print()
    
def task_5_7(task, total, min, max, p):
    if task == 5:
        print("Завдання 5")
        print()
        
        print("Умова:")
        print("Ймовірність того, що пара взуття, яка взята навмання з виготовленої партії виявиться вищого ґатунку дорівнює 0,4. Чому дорівнює ймовірність того, що серед 600 пар, які поступили на контроль, виявиться від 228 до 252 пар взуття вищого ґатунку?")
    elif task == 7:
        print("Завдання 7")
        print()
        
        print("Умова:")
        print("Завод випускає в середньому 4% нестандартних виробів. Яка ймовірність того, що число нестандартних виробів у партії з 4000 штук не більше 170?")
    print()
    
    Xmin = X(total, min, p)
    Xmax = X(total, max, p)
    
    fiMin = Fi_Gauss_integral(Xmin)
    fiMax = Fi_Gauss_integral(Xmax)
    
    P = fiMax - fiMin
    print("Відповідь:", round(P, 3))  
    print("-------------------------------------------------------")
    print()
    
def task_6():
    print("Завдання 6")
    print()
    
    print("Умова:")
    print("Банк обслуговує 100 клієнтів, від кожного з яких може надійти вимога на проведення фінансової операції на наступний день з ймовірністю 0,4. Знайти найімовірніше число вимог клієнтів кожного дня, та його ймовірність.")
    print()
    
    total = 100
    p = 0.4
    
    q = 1 - p
    
    Kmin = total * p - q
    Kmax = total * p + p 
    
    k = integerK(Kmin, Kmax)  
        
    x = X(100, k, 0.4)
    f = Fi_Gauss_local(x)
    
    P = f / math.sqrt(total * p * (1 - p))
    print("Відповідь:", round(P, 3))  
    print("-------------------------------------------------------")
    print()
    
def task_10():
    print("Завдання 10")
    print()
    
    print("Умова:")
    print("Нехай ймовірність того, що грошовий приймальник автомату при опусканні монети скидає неправильно дорівнює 0,03. Знайти найімовірніше число випадків правильної роботи автомату, якщо буде кинуто 150 монет.")
    print()
    
    total = 150
    p = 0.03
    
    # оскільки дано імовірність неправильної роботи, то імовірність правильної роботи:
    p = 1 - p       
    
    q = 1 - p
    
    Kmin = total * p - q
    Kmax = total * p + p 
    
    k = integerK(Kmin, Kmax)  
    
    print("Відповідь:", k)  
    print("-------------------------------------------------------")
    print()

def mainf():
    task_1()
    
    task_2()
    
    task_3_4_8_9(3, 400, 80, 0.2) 
    
    task_3_4_8_9(4, 100000, 5, 0.0001) 
    
    task_5_7(5, 600, 228, 252, 0.4)
    
    task_6()
    
    task_5_7(7, 4000, 1, 170, 0.04)
    
    task_3_4_8_9(8, 10000, 5000, 0.5)
     
    task_3_4_8_9(9, 1000, 5, 0.002)
    
    task_10()

mainf()