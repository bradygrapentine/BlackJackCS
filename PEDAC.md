P: Build a blackjack application (in C#) that lets the user play blackjack
against the "House" (which is just the computer) that determines a winner
with a truncated set of rules.

General Rules:
The game should be played with a standard deck of playing cards (52).
The house should be dealt two cards, hidden from the player until the house reveals its hand.
The player should be dealt two cards, visible to the player.
The player should have a chance to hit (i.e. be dealt another card) until they decide to stop or they bust (i.e. their total is over 21). At which point they lose regardless of the dealer's hand.
When the player stands, the house reveals its hand and hits (i.e. draw cards) until they have 17 or more.
If dealer goes over 21 the dealer loses.
The player should have two choices: "Hit" and "Stand."
Consider Aces to be worth 11, never 1.
The app should display the winner. For this mode, the winner is who is closer to a blackjack (21) without going over.
Ties go to the DEALER
There should be an option to play again. This should start a new game with a new full deck of 52 shuffled cards and new empty hands for the dealer and the player.

E:

1. Player is dealt an Ace and a 10, and Dealer is
   dealt an Ace and a 6. Player stands. Dealer stands.
   Player Wins.
2. Player is dealt an Ace and a 10, and Dealer is
   dealt an Ace and a 5. Player stands. Dealer hits
   and is dealt a 5. Dealer Stands. The Dealer and
   Player's hands are equal, so the Dealer Wins.
3. Player is dealt an Ace and a 10, and Dealer is
   dealt an Ace and a 5. Player stands. Dealer hits
   and is dealt a 4. Dealer Stands. Player Wins.
4. Player is dealt an Ace and a 10, and Dealer is
   dealt an Ace and a 5. Player stands. Dealer hits
   and is dealt a 6. Dealer Busts. Player Wins.
5. Player is dealt an Ace and a 6, and Dealer is
   dealt an Ace and a 6. Player hits and is dealt a 5.
   Player Busts. Dealer Wins.
6. Player is dealt an ace and a 4, and Dealer is
   dealt an Ace and a 9. Player hits and is dealt a 3.
   Player Stands. Dealer Stands. Dealer Wins.

D:
Cards - Instances of the Card Class
(each instance has a suit property and face property)
Deck - A list of cards with 52 Elements
Dealer Hand - List of Cards
Player Hand - List of Cards

A:
User Starts Application in the Console
Generate Deck of Cards, using Getters and Setters
Shuffle Deck of Cards
Deal Two Cards to the House and Remove Cards from Deck
Deal Two Cards to the Player and Remove Cards from Deck
Assign Values to Cards (2-10, 10 for Face Cards, 11 for Aces), and calculate the total for the Player and House Hands
Enable Players to Hit or Stand

1. If Hit is Selected, Another Card is Dealt to the Player's Hand
   a) Calculate total for Player's Hand
   i) If the total is over 21, display busted to the console
   b) Give Player the option to Hit or Stand again
   i) If the total is over 21, display busted to the console
2. If Stand is Selected, the computer will hit and add cards to the Dealer hand
   if and only if the total for the Dealer's hand is less than 17
   a) Display 'Dealer Busted, Player Wins' if the dealer hand goes higher than 21
   b) Display 'Computer Stands' if the dealer hand is less than or equal to 21
   If the Computer and Player Stand, Compare the totals of the dealer and player hands
3. if Dealer Hand total > Player Hand total, display computer wins
4. if Player Hand total > Dealer Hand total, display Player wins
5. if Dealer Hand total = Player Hand total, display 'It's a tie, computer wins'
   Ask the user if they'd like to play again
6. If they say no, close the application
7. if they say yes, start this algorithm from the beginning
