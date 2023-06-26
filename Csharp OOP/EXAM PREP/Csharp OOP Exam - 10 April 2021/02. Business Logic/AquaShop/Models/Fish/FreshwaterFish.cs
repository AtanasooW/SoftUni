namespace AquaShop.Models.Fish
{
using System;
using System.Collections.Generic;
    public class FreshwaterFish : Fish
    {
        private const int sizeOfTheFreshwaterFish = 3;
        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            Size = sizeOfTheFreshwaterFish;
        }

        public override void Eat()
        {
            Size += sizeOfTheFreshwaterFish;
        }
    }
}
