using System;
using System.Collections.Generic;

namespace CsBottlesOnTheWallFunctionalIterator
{
    class Program
    {
        public static void Run()
        {
            foreach(var line in Lines())
            {
                Console.WriteLine(line);
            }
        }

        static IEnumerable<string> Lines() 
        {
            while(true)
            {
                for (var bottleCount = 99; bottleCount > 0; bottleCount--)
                    foreach (var Line in GetVerseLines(bottleCount)) 
                        yield return Line;

                yield return GetRefrain(99);
            }
        }

        static string GetDetails(int bottleCount) => 
            bottleCount switch
            {
                0 => "No more bottles",
                1 => "1 bottle",
                _ => $"{bottleCount} bottles"
            };

        static string[] GetVerseLines(int bottleCount) => 
            new[] {  
                $"{GetDetails(bottleCount)} of beer on the wall, {GetDetails(bottleCount)} of beer.", 
                $"Take one down and pass it around, {GetDetails(bottleCount - 1)} of beer." 
            };

        static string GetRefrain(int bottleCount) => 
            $"Go to the store and buy some more, {GetDetails(bottleCount)} of beer on the wall.";
    }
}





