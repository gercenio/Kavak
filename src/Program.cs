using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var item = "ball";
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            #region # INPUT
            var example = @"“hit” shows up 3 times, but it's a forbidden word.

“ball” shows up 2 times (and it's the only word that shows up 2 times), therefore this is the most frequent word.

Have in mind that the words in the paragraph don’t distinguish upper case from lower case and the accentuation is ignored.

For example, “ball” and “BALL” are the same word.";
            #endregion

            int endIndex = example.IndexOf("\r");
            while (endIndex != -1)
            {
                
                if (1 <= example.Substring(0, endIndex).Length 
                    && example.Substring(0, endIndex).Length <= 1000 
                    && !regexItem.IsMatch(example))
                {
                    DisplayScreen(example, item);
                }
                example = example.Substring(endIndex + 2, example.Length - (endIndex + 2));
                endIndex = example.IndexOf("\r");
            }

            #region # Example 2

            var texto = "We buy on day 2 at $1 and sell on day 5 at $6 with a profit of $5.";
            var lista = new char[texto.Length];
            for (int i = 0, j = 0; i < texto.Length; i++) if (!char.IsDigit(texto[i]) || (i == 0 || texto[i] != texto[i - 1])) lista[j++] = texto[i];
            Console.WriteLine(new string(lista));

            #endregion

        }

        public static void DisplayScreen(string input, string findItem) 
        {
            bool b = input.Contains(findItem.ToLower());
            Console.WriteLine("'{0}' is in the string '{1}': {2}",
                            findItem, input, b);
            if (b)
            {
                int index = input.IndexOf(findItem);
                if (index >= 0)
                    Console.WriteLine("'{0} begins at character position {1}",
                                  findItem, index + 1);
            }
        }
    }
}
