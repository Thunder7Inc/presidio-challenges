# Merge the Tools!
def merge_the_tools(string, k):
    # your code goes here
    n=len(string)
    for i in range(0,n,k):
        substr=string[i:i+k]
        output=""
        for ch in substr:
            if ch not in output:
                output+=ch
        print(output)

def swap_case(s):
    x=''
    for i in s:
        if i == i.upper():
            x+=i.lower()
        else:
            x+=i.upper()
    return x


def split_and_join(line):
    # write your code here
    return '-'.join(line.split(' '))


def print_full_name(first, last):
    # Write your code here
    print(f"Hello {first} {last}! You just delved into python.")


def mutate_string(string, position, character):
    l=list(string)
    l[position]=character
    return ''.join(l)

# collections.Counter()
# A counter is a container that stores elements as dictionary keys, and their counts are stored as dictionary values.

from collections import Counter
no_of_shoes=int(input())
shoes=Counter(list(map(int, input().split())))

no_of_customer=int(input())
amount=0

for i in range(no_of_customer):
    require_size, require_money = map(int, input().split())

    for key, value in Counter(shoes.items()):
        if require_size==key:
            amount+=require_money
            shoes[key]=shoes[key]-1
            if shoes[key]==0:
                del shoes[key]
print(amount)


# Arithmetic Operators
if __name__ == '__main__':
    a = int(input())
    b = int(input())
    print(a+b)
    print(a-b)
    print(a*b)


# Company Logo
if __name__ == '__main__':
    s = sorted(input())
    d=Counter(s).most_common(3)
    for i in d:
        print(f'{i[0]} {i[1]}')

# Python: Division
if __name__ == '__main__':
    a = int(input())
    b = int(input())
    print(a//b)
    print(a/b)


# loop
if __name__ == '__main__':
    n = int(input())
    for i in range(n):
        print(i*i)


# leap year
def is_leap(year):
    if (year%4==0 and year%100!=0) or (year%400==0):
        return True
    else:
        return False

# Print Function
if __name__ == '__main__':
    n = int(input())
    ans=''
    for i in range(1, n+1):
        ans+=str(i)
    print(ans)    

# List Comprehensions
if __name__ == '__main__':
    x = int(input())
    y = int(input())
    z = int(input())
    n = int(input())
    print([[i,j,k] for i in range(x+1) for j in range(y+1) for k in range(z+1) if(i+j+k!=n)])
