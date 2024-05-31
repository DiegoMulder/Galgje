using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> astroWords = new List<string>
        {
            "aarde", "astronaut", "asteroïde", "atmosfeer", "zwartegat",
            "komeet", "constellatie", "kosmos", "melkweg", "zwaartekracht",
            "jupiter", "lander", "lichtjaar", "mars", "mercurius",
            "meteoriet", "melkwegstelsel", "neptunus", "nasa", "nevel",
            "baan", "planetoïde", "planeten", "pluto", "quasar",
            "raket", "ruimte", "ruimteschip", "satelliet", "saturnus",
            "schorpioen", "ruimtewandeling", "ruimteshuttle", "sterren", "sterrenbeeld",
            "telescoop", "ufo", "uranus", "venus", "piloot",
            "dierenriem", "zonsverduistering", "zwartegat", "astronomie", "exoplaneet",
            "zon", "maan", "ruimtevaart", "ruimtestation", "oerknal"
        };

        List<string> dinoWords = new List<string>
        {
            "tyrannosaurus", "triceratops", "velociraptor", "brachiosaurus", "stegosaurus",
            "allosaurus", "diplodocus", "spinosaurus", "ankylosaurus", "iguanodon",
            "pachycephalosaurus", "parasaurolophus", "apatosaurus", "carnotaurus", "giganotosaurus",
            "therizinosaurus", "troodon", "coelophysis", "gallimimus", "oviraptor",
            "sauroposeidon", "pteranodon", "ceratosaurus", "euoplocephalus", "kentrosaurus",
            "maiasaura", "microraptor", "monolophosaurus", "sinoceratops", "styracosaurus",
            "dilophosaurus", "edmontosaurus", "herrerasaurus", "lambeosaurus", "megalosaurus",
            "protoceratops", "quetzalcoatlus", "tarchia", "utahraptor", "yutyrannus",
            "archeopteryx", "dreadnoughtus", "eoraptor", "hypsilophodon", "jobaria",
            "lesothosaurus", "mosasaurus", "ornithomimus", "raptor", "zuniceratops"
        };

        Random random = new Random();
        int score = 0;
        bool playAgain = true;

        while (playAgain)
        {
            Console.Clear();
            Console.WriteLine("Welkom bij Galgje!");
            Console.WriteLine("Kies een categorie:");
            Console.WriteLine("1. Astro Galgje");
            Console.WriteLine("2. Dino Galgje");
            Console.Write("Maak je keuze (1 of 2): ");

            string choice = Console.ReadLine();
            List<string> selectedWords = null;

            if (choice == "1")
            {
                selectedWords = astroWords;
                Console.WriteLine("Je hebt gekozen voor Astro Galgje!");
            }
            else if (choice == "2")
            {
                selectedWords = dinoWords;
                Console.WriteLine("Je hebt gekozen voor Dino Galgje!");
            }
            else
            {
                Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                continue;
            }

            Console.ReadKey();

            string secretWord = selectedWords[random.Next(selectedWords.Count)];
            char[] guessedWord = new string('_', secretWord.Length).ToCharArray();
            List<char> incorrectGuesses = new List<char>();

            int attempts = 10;
            bool isWordGuessed = false;

            while (attempts > 0 && !isWordGuessed)
            {
                Console.Clear();
                Console.WriteLine("Galgje");
                Console.WriteLine("Woord: " + new string(guessedWord));
                Console.WriteLine("Foute gokjes: " + string.Join(", ", incorrectGuesses));
                Console.WriteLine("Pogingen over: " + attempts);
                Console.Write("Raad een letter: ");

                string input = Console.ReadLine().ToLower();
                if (input.Length != 1 || !char.IsLetter(input[0]))
                {
                    Console.WriteLine("Ongeldige invoer. Voer een enkele letter in.");
                    Console.ReadKey();
                    continue;
                }

                char guess = input[0];

                if (secretWord.Contains(guess))
                {
                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        if (secretWord[i] == guess)
                        {
                            guessedWord[i] = guess;
                        }
                    }
                }
                else
                {
                    if (!incorrectGuesses.Contains(guess))
                    {
                        incorrectGuesses.Add(guess);
                        attempts--;
                    }
                    else
                    {
                        Console.WriteLine("Je hebt deze letter al geprobeerd. Probeer een andere.");
                        Console.ReadKey();
                    }
                }

                if (new string(guessedWord) == secretWord)
                {
                    isWordGuessed = true;
                }
            }

            Console.Clear();
            if (isWordGuessed)
            {
                score += 10;
                Console.WriteLine("Gefeliciteerd! Je hebt het woord geraden: " + secretWord);
                Console.WriteLine("Je huidige score is: " + score);
            }
            else
            {
                playAgain = false;
                Console.WriteLine("Je hebt verloren. Het woord was: " + secretWord);
                Console.WriteLine("Je eindscore is: " + score);
            }

            if (playAgain)
            {
                bool validResponse = false;
                while (!validResponse)
                {
                    Console.WriteLine("Wil je nog een keer spelen? (ja/nee)");
                    string response = Console.ReadLine().ToLower();
                    if (response == "ja")
                    {
                        validResponse = true;
                    }
                    else if (response == "nee")
                    {
                        validResponse = true;
                        playAgain = false;
                        Console.WriteLine("Dank je voor het spelen! Je eindscore is: " + score);
                    }
                    else
                    {
                        Console.WriteLine("Ongeldige invoer. Voer 'ja' of 'nee' in.");
                        Console.Clear();
                    }
                }
            }
        }
    }
}
