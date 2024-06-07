using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLogic;
using DeckLogic;

public enum CardValue
{
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace
}

public enum Suit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}

class Program
{
    static void Main(string[] args)
    {
        GameLogic();   
    }

    static void GameLogic()
	{
        Console.WriteLine("Welkom bij het Hoger-Lager kaartspel!");
        Console.Write("Voer je naam in: ");
        string playerName = Console.ReadLine();

        while (true)
        {
            PlayGame(playerName);
            Console.WriteLine("Druk op Esc om het spel te verlaten, of op een andere toets om opnieuw te spelen.");

            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }

    static void PlayGame(string playerName)
    {
        Deck deck = new Deck();
        int score = 0;
        Card previousCard = deck.DrawCard();

        while (deck.CardsRemaining > 0)
        {
            Console.Clear();
            Console.WriteLine($"De huidige kaart is {previousCard}");
            string guess = GetValidGuess();

            Card nextCard = deck.DrawCard();
            Console.WriteLine($"De volgende kaart is {nextCard}");

            if ((guess.Equals("H", StringComparison.OrdinalIgnoreCase) && nextCard.Value > previousCard.Value) ||
                (guess.Equals("L", StringComparison.OrdinalIgnoreCase) && nextCard.Value < previousCard.Value))
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }

            previousCard = nextCard;

            Console.WriteLine($"Score: {score}");
            Console.WriteLine("Druk op een toets om verder te gaan, of op Esc om te stoppen.");

            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                break;
            }
        }

        Console.Clear();
        Console.WriteLine($"{playerName}, je hebt een score van {score} behaald.");
    }

    static string GetValidGuess()
    {
        while (true)
        {
            Console.Write("Denk je dat de volgende kaart hoger of lager is (H/L)? ");
            string guess = Console.ReadLine();

            if (guess.Equals("H", StringComparison.OrdinalIgnoreCase) || guess.Equals("L", StringComparison.OrdinalIgnoreCase))
            {
                return guess;
            }
            else
            {
                Console.WriteLine("Ongeldige invoer. Voer H of L in.");
            }
        }
    }
}
