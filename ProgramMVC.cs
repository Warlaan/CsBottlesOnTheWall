using System;
using System.Collections.Generic;

namespace CsBottlesOnTheWallMVC
{
    class Program
    {
        public static void Run()
        {
            var model = new StockModel();
            var view = new StockView(model);
            var controller = new StockController(model);

            while(true)
            {
                controller.Update();
            }
        }
    }

    public enum ChangeType
    {
        Consuming,
        Consumed,
        Restocking,
        Restocked
    }

    struct StockData
    {
        public int BottleCount;
    }

    class StockModel
    {
        int maxBottleCount;
        int bottleCount;

        public StockModel(int maxBottleCount = 99)
        {
            this.maxBottleCount = maxBottleCount;
            bottleCount = maxBottleCount;
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
            BottleCountChanging?.Invoke(ChangeType.Restocking, new StockData{BottleCount = bottleCount});
            bottleCount = maxBottleCount;
            BottleCountChanging?.Invoke(ChangeType.Restocked, new StockData{BottleCount = bottleCount});
        }

        public void ConsumeBottle()
        {
            BottleCountChanging?.Invoke(ChangeType.Consuming, new StockData{BottleCount = bottleCount});
            bottleCount--;
            BottleCountChanging?.Invoke(ChangeType.Consumed, new StockData{BottleCount = bottleCount});
        }

        public event Action<ChangeType, StockData> BottleCountChanging;
    }

    class StockView
    {
        public StockView(StockModel model)
        {   
            model.BottleCountChanging += Display;
        }

        string GetBottleText(int count)
        {
            switch(count)
            {
                case 0:
                    return "No more bottles";
                
                case 1:
                    return "1 bottle";
                
                default:
                    return $"{count} bottles";
            }
        }

        void Display(ChangeType changeType, StockData data)
        {
            var bottleText = GetBottleText(data.BottleCount);

            switch(changeType)
            {
                case ChangeType.Consuming:
                    Console.WriteLine($"{bottleText} of beer on the wall, {bottleText} of beer.");
                    return;

                case ChangeType.Consumed:
                    Console.WriteLine($"Take one down and pass it around, {bottleText} of beer.");
                    return;

                case ChangeType.Restocked:
                    Console.WriteLine($"Go to the store and buy some more, {bottleText} of beer on the wall.");
                    return;

                case ChangeType.Restocking:
                default:
                    return;
            }
        }
    }

    class StockController
    {
        StockModel model;
        int repetitions = 99;

        public StockController(StockModel model)
        {
            this.model = model;
        }

        public void Update()
        {
            if (repetitions > 0)
            {
                model.ConsumeBottle();
                repetitions--;
            }
            else
            {
                model.Restock();
                repetitions = 99;
            }
        }
    }
}





