using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WordGenerator
{
    class Program
    {
        static int nrFiles = 10;
        static int nrWordsOnEachFile = 1000000;
        static char[] cons = new char[] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
        static char[] vowel = new char[] { 'a', 'e', 'i', 'o', 'u', 'y' };

        static void Main(string[] args)
        {
            var tl = new List<Task>();

            for (int i = 0; i < nrFiles; i++)
            {
                tl.Add(GenerateWorkds(i));
            }

            Task.WaitAll(tl.ToArray());

            Console.WriteLine("Finshed");
        }

        private static Task GenerateWorkds(int fileId)
        {
            return Task.Run(()=> {

                var file = $"file.{fileId}.dat";

                long nrOfWords = nrWordsOnEachFile;

                string[] lines = new string[nrOfWords];

                var rand = new Random(100);

                for (int idx = 0; idx < nrOfWords; idx++)
                {
                    lines[idx] = GenerateWord(rand, rand.Next(1, 20));
                }

                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(file))
                {
                    foreach (string line in lines)
                    {
                        outputFile.WriteLine(line);
                    }
                }

            });
        }

        static string GenerateWord(Random rand, int length)
        {
            if (length < 1) // do not allow words of zero length
                throw new ArgumentException("Length must be greater than 0");

            string word = string.Empty;

            if (rand.Next() % 2 == 0) // randomly choose a vowel or consonant to start the word
                word += cons[rand.Next(0, 20)];
            else
                word += vowel[rand.Next(0, 4)];

            for (int i = 1; i < length; i += 2) // the counter starts at 1 to account for the initial letter
            { // and increments by two since we append two characters per pass
                char c = cons[rand.Next(0, 20)];
                char v = vowel[rand.Next(0, 4)];

                word += c.ToString() + v.ToString();
            }

            // the word may be short a letter because of the way the for loop above is constructed
            if (word.Length < length) // we'll just append a random consonant if that's the case
                word += cons[rand.Next(0, 20)];

            return word;
        }
    }
}
