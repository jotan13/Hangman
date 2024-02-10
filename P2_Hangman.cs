using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Project
{
    internal class Project2
    {
        static void stickmanDrawing(int choice)
        {
            if (choice == 6)
            {
                Console.Write("------\n" +
                              "|\n" +
                              "|\n" +
                              "|\n" +
                              "|\n" +
                              "------\n");

            }
            if (choice == 5)
            {
                Console.Write("------\n" +
                              "|   O\n" +
                              "|\n" +
                              "|\n" +
                              "|\n" +
                              "------\n");
            }
            if (choice == 4)
            {
                Console.Write("------\n" +
                              "|   O\n" +
                              "|   |\n" +
                              "|\n" +
                              "|\n" +
                              "------\n");
            }
            if (choice == 3)
            {
                Console.Write("------\n" +
                              "|   O\n" +
                              "|  /|\n" +
                              "|\n" +
                              "|\n" +
                              "------\n");
            }
            if (choice == 2)
            {
                Console.Write("------\n" +
                              "|   O\n" +
                              "|  /|\\ \n" +
                              "|\n" +
                              "|\n" +
                              "------\n");
            }
            if (choice == 1)
            {
                Console.Write("------\n" +
                              "|   O\n" +
                              "|  /|\\ \n" +
                              "|  / \n" +
                              "|\n" +
                              "------\n");
            }
            if (choice == 0)
            {
                Console.Write("------\n" +
                              "|   O\n" +
                              "|  /|\\ \n" +
                              "|  / \\ \n" +
                              "|\n" +
                              "------\n");
            }
        }
        static void Main(string[] args)
        {
            //Step 1: Initialise random word
            string[] words = { "potato", "kevin", "chair", "computer", "pie", "elephant", 
                                "guitar", "sam", "adventure", "chocolate", "watermelon", "butterfly"};
            Random random = new Random();
            string randomWord = words[random.Next(words.Length)];
            char[] selectedWord = randomWord.ToCharArray();
            char[] guessedLetters = new char[selectedWord.Length];
            int attemptsLeft = 6;

            Console.WriteLine("888                                                           \r\n888                                                           \r\n888                                                           \r\n88888b.  8888b. 88888b.  .d88b. 88888b.d88b.  8888b. 88888b.  \r\n888 \"88b    \"88b888 \"88bd88P\"88b888 \"888 \"88b    \"88b888 \"88b \r\n888  888.d888888888  888888  888888  888  888.d888888888  888 \r\n888  888888  888888  888Y88b 888888  888  888888  888888  888 \r\n888  888\"Y888888888  888 \"Y88888888  888  888\"Y888888888  888 \r\n                             888                              \r\n                        Y8b d88P                              \r\n                         \"Y88P\"              ");
            Console.WriteLine("\n\nWelcome to Hangman! You have " + attemptsLeft + " guesses.\n");

            for (int i = 0; i < guessedLetters.Length; i++)
            {
                guessedLetters[i] = '_';
            }

            //Game loop
            while (attemptsLeft != 0)
            {
                stickmanDrawing(attemptsLeft);
                Console.WriteLine("\nCurrent word: " + new string(guessedLetters));
                Console.Write("Guess a letter: ");

                char guess = char.ToLower(Console.ReadKey().KeyChar);

                bool correctGuess = false;
                Console.WriteLine();

                for (int i = 0; i < selectedWord.Length; i++)
                {
                    if (guess == selectedWord[i])
                    {
                        guessedLetters[i] = guess;
                        correctGuess = true;
                        stickmanDrawing(attemptsLeft);
                    }
                }
                if (!correctGuess)
                {
                    attemptsLeft--;
                    stickmanDrawing(attemptsLeft);
                    if (attemptsLeft == 0)
                    {
                        Console.WriteLine("You lost, The word was " + randomWord);
                        return;
                    }
                    Console.WriteLine("Guesses left: " + attemptsLeft);
                }

                if (new string(guessedLetters) == randomWord)
                {
                    Console.WriteLine("You won! The word was " + randomWord);
                    return;
                }
            }
        }
    }
}
