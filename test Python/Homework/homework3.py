# fact(n) returns n!
# int -> int
# fact(5) = 120
def fact(n):
    if n<=0:
        return 1
    return n*fact(n-1)

# list_fact(n) returns a list as [n!, (n-1)!, (n-2)!, ..., 1]
# int -> int list
# list_fact(5) = [120, 24, 6, 2, 1]
def list_fact(n):
    lst = []
    if n<=0:
        return lst
    lst.append(fact(n))

    while n>1:
        lst.append(lst[-1]/n)
        n=n-1

    return lst

# fib(n) returns a list Fibonacci sequence [1, 1, 2, 3, 5, 8, 13, ...] composed of n element
# int -> int list
# fib(9) = [1, 1, 2, 3, 5, 8, 13, 21, 34]
def fib(n):
    if n<=0:
        return []
    if n==1:
        return [1]
    if n==2:
        return [1,1]
    
    lst = [1,1]
    n=n-2

    while n>0:
        lst.append(lst[-1]+lst[-2])
        n=n-1

    return lst


# switchHalf(lst) returns a list swtiched in the half
# a list -> a list
# switchHalf([1, 2, 5, 6, 12, 9, 1, 3]) = [12, 9, 1, 3, 1, 2, 5, 6]
def switchHalf(lst):
    length = len(lst)
    if length==1:
        return lst
    if length==2:
        return [lst[1], lst[0]]

    half = int(length/2)
    for i in range(0,half):
        tmp=lst[i]
        lst[i]=lst[half+i]
        lst[half+i]=tmp

    return lst

    


print(fact(5))
print(list_fact(5))
print(fib(2))
print(switchHalf(fib(10)))

# list_fun[1, x, x^2, x^3]
list_fun = [lambda x : 1, lambda x : x, lambda x : x**2, lambda x : x**3]
print(list_fun[3](5))
