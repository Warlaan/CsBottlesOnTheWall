using System;
using System.Collections.Generic;

namespace CsBottlesOnTheWallOOP
{
    class Program
    {
        public static void Run()
        {
            var stock = new Stock();

            while(true)
            {
                while (!stock.Depleted)
                {
                    Console.WriteLine(stock.FirstVerse);
                    stock.ConsumeBottle();
                    Console.WriteLine(stock.SecondVerse);
                }

                stock.Restock();
                Console.WriteLine(stock.Refrain);
            }
        }
    }

    class Stock
    {
        int maxBottleCount;
        int bottleCount;

        public Stock(int maxBottleCount = 99)
        {
            this.maxBottleCount = maxBottleCount;
            bottleCount = maxBottleCount;
        }

        string Details 
        {
            get
            {
                switch(bottleCount)
                {
                    case 0: return "No more bottles";
                    case 1: return "1 bottle";
                    default: return $"{bottleCount} bottles";
                }
            }
        }

        public bool Depleted
        {
            get
            {
                return bottleCount <= 0;
            }
        }

        public void Restock()
        {
            bottleCount = maxBottleCount;
        }

        public void ConsumeBottle()
        {
            bottleCount--;
        }

        public string FirstVerse
        {
            get
            {
                return $"{Details} of beer on the wall, {Details} of beer.";
            }
        }

        public string SecondVerse
        {
            get
            {
                return $"Take one down and pass it around, {Details} of beer.";
            }
        }

        public string Refrain
        {
            get
            {
                return $"Go to the store and buy some more, {Details} of beer on the wall.";
            } 
        }
    }
}





