# Dictionary Creation

# empty dictionary
my_dict = {}
print(my_dict)

# dictionary with single element
my_dict = {1: "Greetings"}
print(my_dict)

# dictionary with multiple elements
my_dict = {1: "Greetings", 2: "Universe"}
print(my_dict)

# dictionary with elements of different types
my_dict = {1: "Greetings", "Universe": 2}
print(my_dict)

# nested dictionary
my_dict = {1: {2: "Greetings"}, 3: {4: "Universe"}}
print(my_dict)

# Dictionary Indexing
my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
print(my_dict[1])  # Greetings
print(my_dict[2])  # Universe
print(my_dict[3])  # Python

# Dictionary Slicing (Not possible with colon operator)
# my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
# print(my_dict[:])  # TypeError: unhashable type: 'slice'

# Dictionary Concatenation (Not possible with plus operator)
# my_dict1 = {1: "Greetings"}
# my_dict2 = {2: "Universe"}
# print(my_dict1 + my_dict2)  # TypeError: unsupported operand type(s) for +: 'dict' and 'dict'

# Dictionary Modification
my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
print(my_dict)

# add a new key-value pair
my_dict[4] = "Java"
print(my_dict)

# update an existing key-value pair
my_dict[3] = "JavaScript"
print(my_dict)

# remove a key-value pair
del my_dict[2]
print(my_dict)

# Dictionary Methods

# clear() - Removes all the elements from the dictionary.
my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
my_dict.clear()
print(my_dict)

# copy() - Returns a shallow copy of the dictionary.
my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
my_dict_copy = my_dict.copy()
print(my_dict_copy)

# fromkeys() - Returns a new dictionary with the specified keys and values.
keys = [1, 2, 3]
values = ["Greetings", "Universe", "Python"]
my_dict = dict.fromkeys(keys, values)
print(my_dict)

# get() - Returns the value of the specified key.
my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
print(my_dict.get(1))  # Greetings
print(my_dict.get(2))  # Universe
print(my_dict.get(3))  # Python

# items() - Returns a list containing a tuple for each key-value pair.
my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
print(my_dict.items())

# keys() - Returns a list containing the dictionary's keys.
my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
print(my_dict.keys())

# pop() - Removes the element with the specified key.
my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
my_dict.pop(2)
print(my_dict)

# popitem() - Removes the last inserted key-value pair.
my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
my_dict.popitem()
print(my_dict)

# setdefault() - Returns the value of the specified key. If the key does not exist, insert the key with the specified value.
my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
print(my_dict.setdefault(1))  # Greetings
print(my_dict.setdefault(4, "Java"))  # Java
print(my_dict)

# update() - Updates the dictionary with the specified key-value pairs.
my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
my_dict_update = {4: "Java", 5: "JavaScript"}
my_dict.update(my_dict_update)
print(my_dict)

# values() - Returns a list of all the values in the dictionary.
my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
print(my_dict.values())

# Dictionary Comprehension

# Create a dictionary with numbers as keys and their squares as values.
my_dict = {x: x ** 2 for x in range(5)}
print(my_dict)

# Create a dictionary with numbers as keys and their squares as values if the number is even.
my_dict = {x: x ** 2 for x in range(5) if x % 2 == 0}
print(my_dict)

# Nested Dictionary Comprehension

# Create a nested dictionary with numbers as keys and their squares as values.
my_dict = {x: {y: y ** 2 for y in range(5)} for x in range(5)}
print(my_dict)

# Dictionary as Function Argument
def greet(dictionary):
    for key in dictionary:
        print(key, dictionary[key])

my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
greet(my_dict)

# Dictionary as Return Value
def create_dict():
    return {1: "Greetings", 2: "Universe", 3: "Python"}

my_dict = create_dict()
print(my_dict)

# Dictionary Length
my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
print(len(my_dict))

# Dictionary Membership
my_dict = {1: "Greetings", 2: "Universe", 3: "Python"}
print(1 in my_dict)  # True
print(4 in my_dict)  # False
print(2 in my_dict)  # True
print(5 in my_dict)  # False
print(3 in my_dict)  # True
print(6 in my_dict)  # False
