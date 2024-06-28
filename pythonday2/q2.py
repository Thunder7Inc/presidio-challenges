from math import isqrt

is_prime = lambda x: all(x % i != 0 for i in range(2, isqrt(x) + 1))

def prime_numbers(n):
    numbers = [i for i in range(2, n + 1) if is_prime(i)]
    return numbers

# sample test cases
n = 10
print(prime_numbers(n))  # [2, 3, 5, 7]

n = 20
print(prime_numbers(n))  # [2, 3, 5, 7, 11, 13, 17, 19]
