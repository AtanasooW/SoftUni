using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int comfortForDecoration = 5;
        private const int priceForDecoration = 10;
        public Plant() : base(comfortForDecoration, priceForDecoration)
        {
        }
    }
}
