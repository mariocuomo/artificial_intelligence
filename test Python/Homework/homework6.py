import random

# create_row(x) returns a list as a row of a chessboard. If x is odd the row is [0, 1, 0, 1, 0, 1, 0, 1], else it is [1, 0, 1, 0, 1, 0, 1, 0]
# int -> int list
# create_row(5) = [0, 1, 0, 1, 0, 1, 0, 1]
def create_row(x):
    row = []
    if(x%2==1):
        for i in range(8):
            row.append(i%2)
    else:
        for i in range(8):
            row.append(1-(i%2))
    
    return row


# create_chessbard() returns a list of list as a chessboard where black box are signed with 1 and other with 0
# (int list) list
# create_chessbard() =
# [1, 0, 1, 0, 1, 0, 1, 0],
# [0, 1, 0, 1, 0, 1, 0, 1], 
# [1, 0, 1, 0, 1, 0, 1, 0],
# [0, 1, 0, 1, 0, 1, 0, 1],
# [1, 0, 1, 0, 1, 0, 1, 0],
# [0, 1, 0, 1, 0, 1, 0, 1],
# [1, 0, 1, 0, 1, 0, 1, 0],
# [0, 1, 0, 1, 0, 1, 0, 1]
def create_chessbard():
    chessboard=[]
    for i in range(8):
        chessboard.append(create_row(i%2))
    return chessboard

# delete_min(lst) return lst without the first occurence of the min value
# int list -> int list
# delete_min([1, 0, 1, 0, 1, 0, 1, 0]) = [1, 1, 0, 1, 0, 1, 0]
def delete_min(lst):
    lst.remove(min(lst))
    return lst

# mistery(l,n) return a list of l int elements in the range 0-10 including both limits.
# (int and int) -> int list
# mistery(5,10) = [9, 8, 7, 6, 7]
def mistery(l,n):
    result=[]
    for i in range(l):
        result.append(random.randint(0,n))
    return result

# fill_with(lst, x) return lst with all elements replaced with x
# (int list and int) -> int list
# fill_with([0, 1, 0, 1, 0, 1, 0, 1], 5) = [5, 5, 5, 5, 5, 5, 5, 5]
def fill_with(lst, x):
    return map(lambda y : x, lst)


print("create_chessbard()")
chessboard  = create_chessbard()
print(chessboard)
print("create_row(0)")
row = create_row(0)
print(row)
print("delete_min(row)")
row = delete_min(row)
print(row)
print("mistery(5,10)")
print(mistery(5,10))
print("create_row(5)")
row = create_row(5)
print(row)
print("fill_with(row, 5)")
row = fill_with(row, 5)
print(list(row))