#fact(n)=n!
def fact(n):
    if(n<=1):
        return 1
    else:
        return n*fact(n-1)

#min_list(n)=min value in n
def min_list(n):
    if(len(n)==1):
        return n[0]
    else:
        return min(n[0], min_list(n[1:]))

#min(a,b)= a if a<b
def min(a,b):
    if(a<b):
        return a
    else:
        return b
#is_integer(a)= true if (int)a is correct
def is_integer(n):
    try:
        (int)(n)
        return True
    except ValueError:
        return False

#all_lements_satisfy (a,p)= true if p(a[i])=true
def all_lements_satisfy(a,p):
    if(len(a)==0):
        return True
    else:
        return p(a[0]) and all_lements_satisfy(a[1:],p)

def is_odd(x):
    return x%2!=0


my_list = []
n=input("Write a number: ")
try:
    print("fact(",n,")=",fact((int)(n)))
except ValueError:
    print("It is not a number")

print("Write five number")

for i in range(1,6):
    print("Write number",i,":")
    n=input()
    while(not is_integer(n)):
        print("Write a number!")
        print("Write number",i,":")
        n=input()
    my_list.append((int)(n))

print("min_list(",my_list,")=",min_list(my_list))
if(all_lements_satisfy(my_list,is_odd)):
    print("All numbers are odd")
else:
    print("Not all numbers are odd")

my_list.clear()
print("Write five number")

for i in range(1,6):
    print("Write number",i,":")
    n=input()
    while(not is_integer(n)):
        print("Write a number!")
        print("Write number",i,":")
        n=input()
    my_list.append((int)(n))


new_lst = list(filter(is_odd, my_list))
print("min_list filtered with odd values using list(filter(is_odd, my_list))",new_lst)
new_lst.clear()
new_lst = list(filter(lambda x: x%2!=0, my_list))
print("min_list filtered with odd values using list(filter(lambda x: x%2!=0, my_list))",new_lst)





