using System;
using System.Collections.Generic;
namespace BlackJackCS
{

    // CARD CLASS WITH VALUE METHOD //

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

    //-------------------------------------------------//

    class Program
    {
        // HANDTOTAL METHOD //

        static int HandTotal(List<Card> hand)
        {
            // Body of Method below
            int total = 0;
            foreach (var card in hand)
            {
                total += card.Value();
            }
            return total;

        }

        // HIT METHOD // -- GOTTA ADD SOMETHING HERE TO STOP HITS WHEN playerHand > 21
        // ALSO DOESNT SAY WHO IS HITTING OR WHOSE HAND THE CARD IS ADDED TO //

        static void Hit(List<Card> hand, List<Card> deck)
        {
            hand.Add(deck[0]);
            Console.WriteLine($"{deck[0].Rank} of {deck[0].Suit} added to hand. The total value of the hand is {HandTotal(hand)}.");
            deck.RemoveAt(0);
        }

        // STAND METHOD //

        static void Stand(List<Card> houseHand, List<Card> playerHand, List<Card> deck)
        {
            if (HandTotal(houseHand) >= 17)
            {
                Console.WriteLine($"The total value of the House's hand is {HandTotal(houseHand)}.");
            }
            else
            {
                while (HandTotal(houseHand) < 17)
                {
                    Console.WriteLine($"The House was dealt a {deck[0].Rank} of {deck[0].Suit}.");
                    Hit(houseHand, deck);
                    Console.WriteLine($"The total value of the House's hand is {HandTotal(houseHand)}.");
                }
                Console.WriteLine($"The total value of your hand is {HandTotal(playerHand)}.");

            }

        }
        //-------------------------------------------------//

        static void Main(string[] args)
        {
            // GENERATING DECK //
            var keepPlaying = true;
            while (keepPlaying)
            {
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
                Console.WriteLine("DECK GENERATED.");

                //----------------------------------------------//

                // SHUFFLING DECK //

                var cardCount = deck.Count;
                for (var rightIndex = cardCount - 1; rightIndex >= 0; rightIndex--)
                {
                    var topCard = deck[rightIndex];

                    var leftIndex = new Random().Next(rightIndex);

                    deck[rightIndex] = deck[leftIndex];

                    deck[leftIndex] = topCard;
                }
                Console.WriteLine("DECK SHUFFLED.");

                // ------------Test-------------//
                // var counter = 0;
                // foreach (var i in deck)
                // {
                //     Console.WriteLine($"{i.Rank} of {i.Suit}");
                //     counter++;
                // }
                // Console.WriteLine(counter);

                // --------------------------------------------------------//

                // DEALING PLAYER AND HOUSE HANDS //

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
                Console.WriteLine("HANDS DEALT.");
                Console.WriteLine($"The {houseHand[1].Rank} of {houseHand[1].Suit} was the second card dealt to the House.");

                // ------------Test-------------//
                // Console.WriteLine(playerHand[0].Rank + " of " + playerHand[0].Suit + " with a value of " + playerHand[0].Value() + ", " + playerHand[1].Rank + " of " + playerHand[1].Suit + " with a value of " + playerHand[1].Value());
                // Console.WriteLine(HandTotal(playerHand));
                // Console.WriteLine(houseHand[0].Rank + " of " + houseHand[0].Suit + " with a value of " + houseHand[0].Value() + ", " + houseHand[1].Rank + " of " + houseHand[1].Suit + " with a value of " + houseHand[1].Value());
                // Console.WriteLine(HandTotal(houseHand));

                //---------------------------------------------------------//

                // SHOWING PLAYERHAND TO PLAYER AND CHECKING SCORE //            

                if (HandTotal(playerHand) > 21)
                {
                    Console.WriteLine($"You were dealt a {playerHand[0].Rank} of {playerHand[0].Suit} and a {playerHand[1].Rank} of {playerHand[1].Suit}. The total value of your hand is {HandTotal(playerHand)}.");
                    Console.WriteLine("HAND DISPLAYED.");
                    Console.WriteLine("You busted. You lose.");
                    // Console.Write("Do you want to play again? (Type Y for yes. Type N for no.) ");
                    // var playAgain = Console.ReadLine();
                    // string playAgainLowercase = playAgain.ToLower();
                    // if (playAgainLowercase == "y")
                    // {
                    //     continue;
                    // }
                    // else if (playAgainLowercase == "n")
                    // {
                    //     keepPlaying = false;
                    // }
                    // else
                    // {
                    //     Console.WriteLine("Your choice was invalid. Ending the game.");
                    //     keepPlaying = false;
                    // }
                }
                else if (HandTotal(houseHand) > 21)
                {
                    Console.WriteLine($"You were dealt a {playerHand[0].Rank} of {playerHand[0].Suit} and a {playerHand[1].Rank} of {playerHand[1].Suit}. The total value of your hand is {HandTotal(playerHand)}.");
                    Console.WriteLine("HAND DISPLAYED.");
                    Console.WriteLine("The House busted. You win.");
                    // Console.Write("Do you want to play again? (Type Y for yes. Type N for no.) ");
                    // var playAgain = Console.ReadLine();
                    // string playAgainLowercase = playAgain.ToLower();
                    // if (playAgainLowercase == "y")
                    // {
                    //     continue;
                    // }
                    // else if (playAgainLowercase == "n")
                    // {
                    //     keepPlaying = false;
                    // }
                    // else
                    // {
                    //     Console.WriteLine("Your choice was invalid. Ending the game.");
                    //     keepPlaying = false;
                    // }
                }
                else if (HandTotal(playerHand) <= 21)
                {
                    Console.WriteLine($"You were dealt a {playerHand[0].Rank} of {playerHand[0].Suit} and a {playerHand[1].Rank} of {playerHand[1].Suit}. The total value of your hand is {HandTotal(playerHand)}.");
                    Console.WriteLine("HAND DISPLAYED.");
                    Console.Write("Hit or Stand? (Type H for hit. Type S for stand) ");
                    var playerMove = Console.ReadLine();
                    string playerMoveLowercase = playerMove.ToLower();
                    if (playerMoveLowercase == "s")
                    {
                        Stand(houseHand, playerHand, deck);
                    }
                    else
                    {
                        while (playerMoveLowercase == "h")
                        {
                            Hit(playerHand, deck);
                            Console.Write("Hit again or Stand? (Type H for hit. Type S for stand) ");
                            playerMove = Console.ReadLine();
                            playerMoveLowercase = playerMove.ToLower();
                            if (HandTotal(playerHand) > 21)
                            {
                                break;
                            }
                        }
                        Stand(houseHand, playerHand, deck);

                    }

                    //---------------------CALCULATING SCORE--------------------//                    
                    //----------------------------------------------------------//
                    if (HandTotal(playerHand) > 21)
                    {
                        Console.WriteLine("You busted. You lose.");
                        // Console.Write("Do you want to play again? (Type Y for yes. Type N for no.) ");
                        // var playAgain = Console.ReadLine();
                        // string playAgainLowercase = playAgain.ToLower();
                        // if (playAgainLowercase == "y")
                        // {
                        //     continue;
                        // }
                        // else if (playAgainLowercase == "n")
                        // {
                        //     keepPlaying = false;
                        // }
                        // else
                        // {
                        //     Console.WriteLine("Your choice was invalid. Ending the game.");
                        //     keepPlaying = false;
                        // }
                    }
                    else if (HandTotal(houseHand) > 21)
                    {
                        Console.WriteLine("The House busted. You win.");
                        // Console.Write("Do you want to play again? (Type Y for yes. Type N for no.) ");
                        // var playAgain = Console.ReadLine();
                        // string playAgainLowercase = playAgain.ToLower();
                        // if (playAgainLowercase == "y")
                        // {
                        //     continue;
                        // }
                        // else if (playAgainLowercase == "n")
                        // {
                        //     keepPlaying = false;
                        // }
                        // else
                        // {
                        //     Console.WriteLine("Your choice was invalid. Ending the game.");
                        //     keepPlaying = false;
                        // }
                    }
                    else if (HandTotal(playerHand) == HandTotal(houseHand))
                    {
                        // Console.WriteLine($"The total value of your hand is {HandTotal(playerHand)}.");
                        // Console.WriteLine($"The total value of the House's hand is {HandTotal(houseHand)}.");
                        Console.WriteLine("Tie goes to the dealer! You lose.");

                    }
                    else if (HandTotal(playerHand) > HandTotal(houseHand))
                    {
                        // Console.WriteLine($"The total value of your hand is {HandTotal(playerHand)}.");
                        // Console.WriteLine($"The total value of the House's hand is {HandTotal(houseHand)}.");
                        Console.WriteLine("You win!");

                    }
                    else if (HandTotal(playerHand) < HandTotal(houseHand))
                    {
                        // Console.WriteLine($"The total value of your hand is {HandTotal(playerHand)}.");
                        // Console.WriteLine($"The total value of the House's hand is {HandTotal(houseHand)}.");
                        Console.WriteLine("You lose.");
                    }
                }

                //GAME OVER. DISPLAYING RESTART OPTION//

                Console.WriteLine("GAME OVER. RESTART OPTION BEING DISPLAYED");

                Console.Write("Do you want to play again? (Type Y and press Enter for yes. Type N and press Enter for no.) ");
                var playAgain2 = Console.ReadLine();
                string playAgain2Lowercase = playAgain2.ToLower();
                if (playAgain2Lowercase == "y")
                {
                    continue;
                }
                else if (playAgain2Lowercase == "n")
                {
                    keepPlaying = false;
                }
                else
                {
                    Console.WriteLine("Your choice was invalid. Ending the game.");
                    keepPlaying = false;
                }
            }
            Console.WriteLine("Goodbye.");
        }
    }
}
