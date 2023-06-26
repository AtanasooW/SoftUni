namespace AquaShop.Models.Fish
{
using System;
using System.Collections.Generic;
    public class SaltwaterFish : Fish
    {
        private const int sizeOfTheSaltwaterFish = 5;
        private const int increasesSizeOfTheSaltwaterFish = 2;

        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            Size = sizeOfTheSaltwaterFish;
        }

        public override void Eat()
        {
            Size += increasesSizeOfTheSaltwaterFish;
        }
    }
}
