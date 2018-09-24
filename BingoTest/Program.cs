using System;
using System.Collections.Generic;
using System.Linq;

namespace BingoTest
{
    public static class Program
    {
        /// <summary>
        /// Mains program.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <exception cref="ArgumentOutOfRangeException">input - Invalid input length. The length must between 1-25.</exception>
        public static void Main(string[] args)
        {
            Console.WriteLine("Bingo Game!");
            Console.WriteLine("Please announce lucky number between 1 - 25.");

            bool isWinning = false;
            int maximumAnnounce = 25;
            int initAnnounce = 0;
            int[] announceNumber = new int[maximumAnnounce];
            // check if still not win and not reach the maximum number will continue playing
            while (isWinning != true && initAnnounce != maximumAnnounce)
            {
                try
                {
                    Console.WriteLine($"Enter your announce number : {initAnnounce + 1}");
                    int input = int.Parse(Console.ReadLine());
                    if (input > 25 || input < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(input), "Invalid input length. The length must between 1-25.");
                    }
                    if (announceNumber.Contains(input))
                    {
                        throw new ArgumentException("Please don't enter duplicate number.", nameof(input));
                    }

                    announceNumber[initAnnounce] = input;
                    if (initAnnounce >= 4)
                    {
                        isWinning = CheckIsBingo(announceNumber);
                        if (isWinning)
                        {
                            Console.WriteLine("You won!!!");
                            break;
                        }
                    }
                    initAnnounce++;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch
                {
                    Console.WriteLine("Please enter valid number.");
                }
            }

            if (!isWinning)
            {
                Console.WriteLine("You loose!!...");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// Checks the is won.
        /// </summary>
        /// <param name="luckyNumberList">The lucky number list.</param>
        /// <returns>true if bingo</returns>
        private static bool CheckIsBingo(int[] luckyNumberList)
        {
            // get all pattern
            List<int[]> propPattern = GetProbabilityPattern();

            bool result = false;
            foreach (var prop in propPattern)
            {
                // compare number to check if bingo
                result = prop.All(luckyNumberList.Contains);
                if (result)
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the probability pattern.
        /// </summary>
        /// <returns>list of possibility</returns>
        private static List<int[]> GetProbabilityPattern()
        {
            return new List<int[]>
            {
                new[] {1,2,3,4,5},
                new[] {6,7,8,9,10},
                new[] {11,12,13,14,15},
                new[] {16,17,18,19,20},
                new[] {20,22,23,24,25},
                new[] {1,6,11,16,21},
                new[] {2,7,12,17,22},
                new[] {3,8,13,18,23},
                new[] {4,9,14,19,24},
                new[] {5,10,15,20,25},
                new[] {1,7,13,19,25},
                new[] {21,17,13,9,5}
            };
        }
    }
}
