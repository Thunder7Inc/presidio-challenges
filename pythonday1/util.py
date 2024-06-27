import re

def split_main_file(filename):
    try:
        with open(filename, 'r') as file:
            content = file.read()
        pattern = re.compile(r'(# Question\d+\n.*?)(?=# Question\d+|$)', re.DOTALL)
        matches = pattern.findall(content)
        for match in matches:
            question_number = re.search(r'# Question(\d+)', match).group(1)
            output_filename = f'question{question_number}.py'
            with open(output_filename, 'w') as output_file:
                output_file.write(match.strip())
            print(f'Created {output_filename}')
    except FileNotFoundError:
        print(f"File {filename} not found.")
    except Exception as e:
        print(f"An error occurred: {e}")

if __name__ == "__main__":
    split_main_file('main.py')
