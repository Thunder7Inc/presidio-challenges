# Question10
N = int(input("Enter total rows: "))
print(*[("*"*(2*i+1)).center(2*N-1," ") for i in range(N)],sep="\n")