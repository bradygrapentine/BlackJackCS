using System;
using System.Collections.Generic;
namespace BlackJackCS
{

    // CARD CLASS //

    class Card
    {
        public string Rank;
        public string Suit;

        public int Value()
        {
            int rankAsInteger;
            var isThisGoodInput = int.TryParse(Rank, out rankAsInteger);
            if (isThisGoodInput)
            {
                return rankAsInteger;
            }
            else if (Rank == "King" || Rank == "Queen" || Rank == "Jack")
            {
                return 10;
            }
            else
            {
                return 11;
            }
        }
        public Card(string newRank, string newSuit)
        {
            Rank = newRank;
            Suit = newSuit;
        }
    }

    class Program
    {
        // HANDTOTAL METHOD //

        static int HandTotal(List<Card> hand)
        {
            int total = 0;
            foreach (var card in hand)
            {
                total += card.Value();
            }
            return total;

        }

        // HIT METHOD //
        static void Hit(List<Card> playerHand, List<Card> deck, List<Card> houseHand)
        {
            playerHand.Add(deck[0]);
            Console.WriteLine($"The {deck[0].Rank} of {deck[0].Suit} was added to your hand.");
            Console.WriteLine($"The total value of your hand is {HandTotal(playerHand)}.");
            Console.WriteLine();
            deck.RemoveAt(0);
        }

        // STAND METHOD //
        static void Stand(List<Card> houseHand, List<Card> playerHand, List<Card> deck)
        {
            Console.WriteLine("REVEALING HOUSE HAND:");
            Console.WriteLine($"The House was dealt the {houseHand[0].Rank} of {houseHand[0].Suit} and the {houseHand[1].Rank} of {houseHand[1].Suit}.");
            Console.WriteLine($"The total value of the House's hand is {HandTotal(houseHand)}.");
            Console.WriteLine();
            while (HandTotal(houseHand) < 17)
            {
                houseHand.Add(deck[0]);
                Console.WriteLine($"The {deck[0].Rank} of {deck[0].Suit} was added to the House's hand.");
                Console.WriteLine($"The new total value of the House's hand is {HandTotal(houseHand)}.");
                Console.WriteLine();
                deck.RemoveAt(0);
            }
        }

        static void Main(string[] args)
        {
            // GENERATING DECK //
            var keepPlaying = true;
            while (keepPlaying)
            {
                Console.WriteLine();
                Console.WriteLine("GENERATING DECK");
                var deck = new List<Card>();
                var suits = new List<string>() { "Clubs", "Diamonds", "Hearts", "Spades" };
                var ranks = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
                foreach (var suit in suits)
                {
                    foreach (var rank in ranks)
                    {
                        var card = new Card(rank, suit);
                        deck.Add(card);
                    }
                }

                // SHUFFLING DECK //
                Console.WriteLine("SHUFFLING DECK");
                var cardCount = deck.Count;
                for (var rightIndex = cardCount - 1; rightIndex >= 0; rightIndex--)
                {
                    var topCard = deck[rightIndex];

                    var leftIndex = new Random().Next(rightIndex);

                    deck[rightIndex] = deck[leftIndex];

                    deck[leftIndex] = topCard;
                }

                // DEALING PLAYER AND HOUSE HANDS //
                Console.WriteLine("DEALING HANDS");
                Console.WriteLine();
                var playerHand = new List<Card>();
                var houseHand = new List<Card>();
                for (var index2 = 0; index2 < 4; index2++)
                {
                    if (index2 % 2 == 0)
                    {
                        playerHand.Add(deck[0]);
                        deck.RemoveAt(0);
                    }
                    else
                    {
                        houseHand.Add(deck[0]);
                        deck.RemoveAt(0);
                    }
                }

                // SHOWING PLAYERHAND TO PLAYER, CHECKING SCORE, AND SHOWING SECOND CARD IN THE HOUSE'S HAND TO PLAYER //
                Console.WriteLine("DISPLAYING PLAYER HAND:");
                Console.WriteLine($"You were dealt the {playerHand[0].Rank} of {playerHand[0].Suit} and the {playerHand[1].Rank} of {playerHand[1].Suit}.");
                Console.WriteLine($"The total value of your hand is {HandTotal(playerHand)}.");
                Console.WriteLine();
                Console.WriteLine($"The {houseHand[1].Rank} of {houseHand[1].Suit} was the second card dealt to the House.");
                Console.WriteLine();
                if (HandTotal(playerHand) < 22)
                {
                    Console.WriteLine("Hit or Stand?");
                    Console.Write("(Press H then press Enter to hit. Press any key (or none at all) then Press Enter to stand.) ");
                    var playerMove = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    while (playerMove == "h")
                    {
                        Hit(playerHand, deck, houseHand);
                        if (HandTotal(playerHand) < 22)
                        {
                            Console.WriteLine("Hit or Stand?");
                            Console.Write("(Press H then press Enter to hit. Press any key (or none at all) then Press Enter to stand.) ");
                            playerMove = Console.ReadLine().ToLower();
                            Console.WriteLine();
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (HandTotal(playerHand) < 22)
                    {
                        Stand(houseHand, playerHand, deck);
                    }
                }

                //---------------------CALCULATING SCORE--------------------//      
                if (HandTotal(playerHand) > 21)
                {
                    Console.WriteLine("You busted. You lose.");
                    Console.WriteLine();
                }
                else if (HandTotal(houseHand) > 21)
                {
                    Console.WriteLine("The House busted. You win!");
                    Console.WriteLine();
                }
                else if (HandTotal(playerHand) == HandTotal(houseHand))
                {
                    Console.WriteLine($"Player Hand Total: {HandTotal(playerHand)}");
                    Console.WriteLine($"House Hand Total: {HandTotal(houseHand)}");         
                    Console.WriteLine("Tie goes to the House! You lose.");
                    Console.WriteLine();
                }
                else if (HandTotal(playerHand) > HandTotal(houseHand))
                {
                    Console.WriteLine($"Player Hand Total: {HandTotal(playerHand)}");
                    Console.WriteLine($"House Hand Total: {HandTotal(houseHand)}");         
                    Console.WriteLine("You win!");
                    Console.WriteLine();
                }
                else if (HandTotal(playerHand) < HandTotal(houseHand))
                {
                    Console.WriteLine($"Player Hand Total: {HandTotal(playerHand)}");
                    Console.WriteLine($"House Hand Total: {HandTotal(houseHand)}");               
                    Console.WriteLine("You lose.");
                    Console.WriteLine();
                }
                Console.WriteLine("GAME OVER");
                Console.WriteLine();
                Console.WriteLine("Do you want to play again?");
                Console.Write("(Press Y then press Enter for yes. Press any key (or none at all) then press Enter for no.) ");
                var playAgain = Console.ReadLine().ToLower();
                if (playAgain == "y")
                {
                    continue;
                }
                else
                {
                    keepPlaying = false;
                }
                Console.WriteLine();
                Console.WriteLine("Thanks for playing.");
                Console.WriteLine();
            }
        }
    }
}
