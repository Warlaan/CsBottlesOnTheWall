using System;

namespace CsBottlesOnTheWallFunctional
{
    class Program
    {
        public static void Run()
        {
            var bottleCount = 99;
            while (true)
            {
                var (newBottleCount, lines) = HandleBottleCount(bottleCount);
                Console.WriteLine(String.Join("/n", lines));
                bottleCount = newBottleCount;
            }
        }

        static (int, string[]) HandleBottleCount(int bottleCount) => 
            bottleCount switch
            {
                0 => (99, GetRefrain(99)),
                _ => (bottleCount - 1, GetVerse(bottleCount))
            };

        static string GetDetails(int bottleCount) => 
            bottleCount switch
            {
                0 => "No more bottles",
                1 => "1 bottle",
                _ => $"{bottleCount} bottles"
            };

        static string[] GetVerse(int bottleCount) => 
            new[] {  
                $"{GetDetails(bottleCount)} of beer on the wall, {GetDetails(bottleCount)} of beer.", 
                $"Take one down and pass it around, {GetDetails(bottleCount - 1)} of beer." 
            };

        static string[] GetRefrain(int bottleCount) => 
            new[] {
                $"Go to the store and buy some more, {GetDetails(bottleCount)} of beer on the wall."
            };
    }
}





