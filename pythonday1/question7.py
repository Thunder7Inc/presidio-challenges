# Question7
def is_prime(N):
    if N<=1:
        return False
    for i in range(2,int(N**0.5)+1):
        if N%i==0:
            return False
    return True
primes = filter(is_prime,list(map(int,input().split())))
print(sum(primes)/len(primes))