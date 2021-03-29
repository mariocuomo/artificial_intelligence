from datetime import date


def correctFormat(birth_date):
    if(len(birth_date)!=10):
        return False
    if(birth_date[2]!='/' or birth_date[5]!='/'):
        return False
    try:
        day = (int)(birth_date[:2])
        month = (int)(birth_date[3:5])
        year = (int)(birth_date[6:])
        
        if (year > (int)(date.today().strftime("%Y"))):
            return False

        if (year == (int)(date.today().strftime("%Y"))):
            if (month > (int)(date.today().strftime("%m"))):
                return False
        
        if (year == (int)(date.today().strftime("%Y"))):
            if (month == (int)(date.today().strftime("%m"))):
                if (day > (int)(date.today().strftime("%d"))):
                    return False


        if((day<1 and day>31) or (month<1 and month>12)):
            return False
        
        if(month==1 or month==3 or month==5 or month==7 or month==8 or month==10 or month==12):
            return day<=31

        if(month==4):
            return day<=30
        
        return day<=28
    except ValueError:
        return False
        

def calculateTheYearsOld(birth_date):
    year = (int)(birth_date[6:])
    month = (int)(birth_date[3:5])
    day = (int)(birth_date[:2])

    scrap = 0

    if ((int)(date.today().strftime("%m"))<month):
        scrap=1

    if ((int)(date.today().strftime("%m"))==month and (int)(date.today().strftime("%d"))<day):
        scrap=1

    return (int)(date.today().strftime("%Y")) - year - scrap





tmp = 'hello world!'
print(tmp)

name=input("Enter your name: ")
print("Hi", name, "nice to meet you!")

print("Write your date of birth in the format day/month/year")
print("Example: 04/12/1991, 31/02/1999")
birth_date = input("Your date: ")

while (not correctFormat(birth_date)):
    print("ERROR!")
    print("Write your date of birth in the format day/month/year")
    print("Example: 04/12/1991, 31/02/1999")
    birth_date = input("Your date: ")

print("Ok, you are",calculateTheYearsOld(birth_date),"years old!")