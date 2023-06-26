using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    using Contracts;
    public abstract class Decoration : IDecoration
    {
        protected Decoration(int comfort, decimal price)
        {
    
        }
        public int Comfort => throw new NotImplementedException();

        public decimal Price => throw new NotImplementedException();
    }
}
