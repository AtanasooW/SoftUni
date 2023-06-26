namespace AquaShop.Models.Aquariums
{
using System;
using System.Collections.Generic;

    public class FreshwaterAquarium : Aquarium
    {
        private const int capacityForFreshwaterAquarium = 50;
        public FreshwaterAquarium(string name) : base(name, capacityForFreshwaterAquarium)
        {
        }
    }
}
