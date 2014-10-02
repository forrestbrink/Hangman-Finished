using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {

        static string ShowMeWord(List<char> word)  // return the string with mask and first uppercaser letter
        {
            string st = word[0].ToString().ToUpper() + " ";
            for (int i = 1; i < word.Count; i++)
            {
                st += word[i].ToString().ToLower() + " ";
            }
            return st;
        }
        static string GiveMeWord(List<char> word)
        {
            string st = "";
            for (int i = 0; i < word.Count; i++)
            {
                st += word[i].ToString().ToLower();
            }
            return st;
        }

        static void Main(string[] args)
        {
            string playerName = "";
            string[] wordsContainer = new string[] { "Apple", "Orange", "Pineapple", "Lemon", "Apricot", "Banana", "Coconut", "Durian", "Guava", "Mango", "Lychee" };
            string word = "";
            List<string> lettersGuessed = new List<string>();
            List<string> wordsGuessed = new List<string>();
            bool wordUnriddled = false;
            Random rnd = new Random();
            word = wordsContainer[rnd.Next(wordsContainer.Length - 1)];
       

            // Create hidden word
            List<char> wordHidden = new List<char>();
            for (int i = 0; i < word.Length; i++)
            {
                wordHidden.Add('_');
            }

            // say hello, ask Name, bla bla bla
            Console.WriteLine("************** HANGMAN ****************");
            Console.WriteLine("Enter your name:");
            playerName = Console.ReadLine();
            Console.WriteLine("Hello, " + playerName);
            Console.WriteLine("Guess the letters or the whole word till you guess it! Lets start!");

            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            int attemptsLeft = 5; //Number of tryies
            while (!wordUnriddled && attemptsLeft > 0)
            {
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("You have " + attemptsLeft + " attempts left");
                Console.WriteLine("The hidden word is: " + ShowMeWord(wordHidden)); // Show hidden word in current condition

                // if we have some letters already entered
                if (lettersGuessed.Count > 0)
                {
                    string st = "Letters you entered before: ";
                    for (int i = 0; i < lettersGuessed.Count; i++)
                    {
                        st += lettersGuessed[i] + " ";
                    }
                    Console.WriteLine(st);
                }
                // if we have some words already entered
                if (wordsGuessed.Count > 0)
                {
                    string st = "Words you entered before: ";
                    for (int i = 0; i < wordsGuessed.Count; i++)
                    {
                        st += wordsGuessed[i] + " ";
                    }
                    Console.WriteLine(st);
                }

                Console.WriteLine("Enter letter or word:");
                string input = Console.ReadLine();
                if (input.Length == 0) Console.WriteLine("Come'on," + playerName + ", enter something!"); // if user didnt enter anything
                else if (input.Length > 1)  //If user entered word
                {

                    if (input.ToLower() == word.ToLower()) //if used guessed word
                    {
                        wordUnriddled = true;
                    }
                    else
                    {
                        Console.WriteLine("WRONG! Try to guess letters first!");
                        wordsGuessed.Add(input);
                        attemptsLeft--;
                    }
                }

                else if (input.Length == 1) // if user entered letter
                {
                    lettersGuessed.Add(input);
                    string guessLetter = "";
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i].ToString().ToLower() == input.ToLower())  //if letter exist in the hidden word
                        {
                            wordHidden[i] = word[i];
                            guessLetter = word[i].ToString().ToLower();

                            if (GiveMeWord(wordHidden).ToLower() == word.ToLower()) // OMG he did it!
                            {
                                wordUnriddled = true;
                            }
                        }
                        else  //if letter doesnt exist in the hidden word
                        {

                        }
                    }
                    if (guessLetter.Length > 0) Console.WriteLine("Great! you guessed the letter: " + guessLetter);
                    else
                    {
                        Console.WriteLine("WRONG!");
                        attemptsLeft--;
                    }
                }
            }

            if (attemptsLeft == 0) Console.WriteLine("Sorry, you've used all you attempts. Game over, " + playerName);


            if (wordUnriddled) Console.WriteLine("Congratulations! " + playerName + ", you've guessed the word and win the game! And the word is: " + word);
            Console.WriteLine("Press any key to exit program..");
            Console.ReadKey(true);
        }
    }
}