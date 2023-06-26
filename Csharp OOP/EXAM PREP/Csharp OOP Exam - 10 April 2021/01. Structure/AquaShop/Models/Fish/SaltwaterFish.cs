using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        public const int sizeforSaltfish = 5;
        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
        }
    }
}
