import random

class CowAndBullGame:
    def __init__(self, word):
        self.word = word.lower()
        self.score = 0

    def guess(self, guess_word):
        guess_word = guess_word.lower()
        if len(guess_word) != len(self.word):
            raise ValueError("Guess word length does not match the word length.")
        cow = 0
        bull = 0
        for i in range(len(self.word)):
            if self.word[i] == guess_word[i]:
                cow += 1
            elif guess_word[i] in self.word:
                bull += 1
        if cow == len(self.word):
            self.score += 1
        return cow, bull

    def get_score(self):
        return self.score

    def __str__(self) -> str:
        return f"Word: {self.word}, Score: {self.score}"

class GameMenu:
    def __init__(self):
        self.words = ["python", "java", "kotlin", "javascript"]
        self.play_game()

    def play_game(self):
        print("Welcome to Cow and Bull Game")
        while True:
            print("1. Start Game\n2. Exit Game")
            try:
                choice = int(input("Enter your choice: "))
            except ValueError:
                print("Please enter a valid number.")
                continue

            if choice == 1:
                self.start_game()
            elif choice == 2:
                print("Exiting Game")
                break
            else:
                print("Invalid Choice")

    def start_game(self):
        word = random.choice(self.words)
        game = CowAndBullGame(word)
        while True:
            guess_word = input("Enter your guess word: ")
            try:
                cow, bull = game.guess(guess_word)
                print(f"Cow: {cow}, Bull: {bull}")
                if cow == len(word):
                    print(f"Congratulations! You have guessed the word in {game.get_score()} attempts.")
                    break
            except ValueError as e:
                print(e)

# Run the game
GameMenu()
