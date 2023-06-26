namespace AquaShop.Models.Aquariums
{
using System;
using System.Collections.Generic;
    public class SaltwaterAquarium : Aquarium
    {
        private const int capacityForSaltwaterAquarium = 25;

        public SaltwaterAquarium(string name) : base(name, capacityForSaltwaterAquarium)
        {
        }
    }
}
