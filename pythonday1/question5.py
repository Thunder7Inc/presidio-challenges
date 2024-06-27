# Question5
class InvalidInputError(Exception):
    pass

def validate_name(name):
    if not name.isalpha():
        raise InvalidInputError("Name should only contain alphabets.")

def validate_age(age):
    if not age.isdigit() or not (0 < int(age) < 120):
        raise InvalidInputError("Age should be a number between 1 and 119.")

def validate_dob(dob):
    from datetime import datetime
    try:
        datetime.strptime(dob, "%Y-%m-%d")
    except ValueError:
        raise InvalidInputError("Date of Birth should be in YYYY-MM-DD format.")

def validate_phone(phone):
    if not phone.isdigit() or len(phone) != 10:
        raise InvalidInputError("Phone number should be a 10-digit number.")

def get_user_input():
    try:
        name = input("Enter your name: ")
        validate_name(name)
        
        age = input("Enter your age: ")
        validate_age(age)
        
        dob = input("Enter your DOB (YYYY-MM-DD): ")
        validate_dob(dob)
        
        phone = input("Enter your phone: ")
        validate_phone(phone)
        
        print(f"{name} is of age {age} born on {dob} contact at {phone}")
    except InvalidInputError as e:
        print(f"Invalid input: {e}")
    except Exception as e:
        print(f"An unexpected error occurred: {e}")

get_user_input()