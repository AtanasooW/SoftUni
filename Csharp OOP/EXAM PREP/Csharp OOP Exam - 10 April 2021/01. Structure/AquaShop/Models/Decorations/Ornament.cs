using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int comfortForOrnament = 1;
        private const int priceForOrnament = 5;
        public Ornament() : base(comfortForOrnament, priceForOrnament)
        {
        }
    }
}
