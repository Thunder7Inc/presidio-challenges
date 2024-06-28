class Player:
    def __init__(self, name, score):
        self.name = name
        self.score = score

    def __repr__(self):
        return repr((self.name, self.score))

    def __lt__(self, other):
        if self.score == other.score:
            return self.name > other.name
        return self.score < other.score

    @classmethod
    def top_10_players(cls, players):
        players.sort(reverse=True)  # Sort in descending order based on custom __lt__
        return players[:10]

# sample test cases
players = [
    Player("Kiran", 20),
    Player("Ravi", 100), 
    Player("Sita", 100),
    Player("Mohan", 90), 
    Player("Gita", 90), 
    Player("Ram", 70),
    Player("Lakshmi", 80),
    Player("Arjun", 50),
    Player("Nina", 60),
    Player("Vikram", 30),
    Player("Sara", 40),
    Player("Rahul", 10),
    Player("Neha", 1),
    Player("Meera", 5),
]

print(Player.top_10_players(players))
