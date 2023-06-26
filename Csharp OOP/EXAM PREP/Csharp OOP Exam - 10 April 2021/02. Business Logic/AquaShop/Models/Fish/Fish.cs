namespace AquaShop.Models.Fish
{
using System;
using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private int size;
        private decimal price;

        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        public string Name
        {
            get
            {
            return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidFishName));
                }
                this.name = value;
            }
        }

        public string Species
        {
            get
            {
                return this.species;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidFishSpecies));
                }
                this.species = value;
            }
        }

        public int Size//maybe bug
        {
            get
            {
                return this.size;
            }
            protected set
            {
                this.size = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidFishPrice));
                }
                this.price = value;
            }
        }

        public abstract void Eat();
    }
}
