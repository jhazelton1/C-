using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    class Hangman
    {

        private string[] words;
        
        private List<string[]> hangman = new List<string[]>
            {
                new string[] { "_", "_", "_", "_", "_", "_", "_", "_", "_", "_" },
                new string[] { "|", " ", " ", " ", " ", " ", " ", " ", "|", " " },
                new string[] { "|", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                new string[] { "|", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                new string[] { "|", " ", " ", " ", " ", " ", " ", " ", " ", " " }
            };

        public string[] WORDS
        {
            get
            {
                return words;
            }
        }

        public Hangman(string file)
        {
            this.words = LoadWords(file);
        }

        private string[] LoadWords(string file)
        {
            return System.IO.File.ReadAllLines(file);
        }

        public string HangmanToString()
        {
            return this.hangman.Aggregate("", (acc, c) => acc += String.Join("", c) + "\n");
        }

        public string FilterHangmanWord(string word, List<char> correctGuesses)
        {
            return String.Join("", word.Select(i => correctGuesses.Contains(i) ? i : '*'));
        }

        public void Wrong(int i)
        {
            if (i == 1)
            {
                this.hangman[2][8] = "O";
            }
            else if (i == 2)
            {
                this.hangman[3][8] = "|";
            }
            else if (i == 3)
            {
                this.hangman[3][7] = "/";
            }
            else if (i == 4)
            {
                this.hangman[3][9] = "\\";
            }
            else if (i == 5)
            {
                this.hangman[4][7] = "/";
            }
            else
            {
                this.hangman[4][9] = "\\";
            }

            WriteWrongOutput(i);
        }

        public void WriteWrongOutput(int guesses)
        {

            Console.WriteLine("\nIncorrect");
            Console.WriteLine("Incorrect Guesses: " + guesses);
            Console.WriteLine("Guesses Remaining: " + (6 - guesses));
            Console.WriteLine(HangmanToString());
            Console.WriteLine();
        }

        public void Run()
        {
            int random = new Random().Next(0, this.words.Length);

            string wordToGuess = this.words[random].ToLower();

            string incorrectGuessedLetters = "";

            bool win = false;

            List<char> wordToGuessLetters = wordToGuess.ToCharArray().ToList();
            List<char> correctGuesses = new List<char>();

            int guesses = 0;

            Console.WriteLine("Let's Play Hangman :]");

            Console.WriteLine(HangmanToString());

            Console.WriteLine("Here is Your Word: ");

            Console.WriteLine(FilterHangmanWord(wordToGuess, correctGuesses));

            while (guesses < 6)
            {
                Console.WriteLine("Incorrectly Guessed Letters: " + incorrectGuessedLetters);
                Console.WriteLine("Enter a Letter: ");
                char guess = char.ToLower(Console.ReadKey().KeyChar);


                if (char.IsLetter(guess))
                {
                    if (wordToGuessLetters.Contains(guess))
                    {
                        Console.WriteLine("\nCorrect!");
                        correctGuesses.Add(guess);
                        string word = FilterHangmanWord(wordToGuess, correctGuesses);
                        if (!word.Contains("*"))
                        {
                            win = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine(word);
                        }

                    }
                    else
                    {
                        incorrectGuessedLetters += guess + " ";
                        guesses++;
                        Wrong(guesses);
                        Console.WriteLine(FilterHangmanWord(wordToGuess, correctGuesses));
                    }
                }
                else
                {
                    incorrectGuessedLetters += guess + " ";
                    guesses++;
                    Wrong(guesses);
                    Console.WriteLine(FilterHangmanWord(wordToGuess, correctGuesses));
                }
            }


            Console.WriteLine("Game Over. You " + (win ? "Win" : "Lose"));
            Console.WriteLine("The Word was: " + wordToGuess);
            Console.WriteLine("Play Again? (Press y)");
            char input = char.ToLower(Console.ReadKey().KeyChar);

            if (input == 'y')
            {
                Console.WriteLine();
                this.hangman = new List<string[]>
            {
                new string[] { "_", "_", "_", "_", "_", "_", "_", "_", "_", "_" },
                new string[] { "|", " ", " ", " ", " ", " ", " ", " ", "|", " " },
                new string[] { "|", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                new string[] { "|", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                new string[] { "|", " ", " ", " ", " ", " ", " ", " ", " ", " " }
            };
                this.Run();
            }

        }

    }
}
