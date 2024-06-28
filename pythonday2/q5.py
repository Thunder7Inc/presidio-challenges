def luhn_check(card_number):
    card_number = card_number[::-1]
    card_number = [int(x) for x in card_number]
    doubled = [x * 2 if i % 2 == 1 else x for i, x in enumerate(card_number)]
    subtracted = [x - 9 if x > 9 else x for x in doubled]
    total = sum(subtracted)
    return total % 10 == 0

# sample test cases
print(luhn_check("4532015112830366"))  # True
print(luhn_check("4532015112830367"))  # False
print(luhn_check("453201511283036"))   # False
print(luhn_check("6011514433546201"))  # True
print(luhn_check("1234567812345670"))  # False
