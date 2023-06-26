namespace AquaShop.Models.Aquariums
{
using System;
using System.Collections.Generic;
    using Decorations.Contracts;
    using Fish.Contracts;
    using Contracts;
    using Utilities.Messages;
    using System.Linq;
    using System.Text;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        //private int comfort;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Decorations = new List<IDecoration>();
            this.Fish = new List<IFish>();
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
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public int Comfort
        {
            get
            {
                return decorations.Sum(x => x.Comfort);
            }
        }

        public ICollection<IDecoration> Decorations
        {
            get
            {
                return this.decorations;
            }
            private set
            {
                this.decorations = value;
            }
        }

        public ICollection<IFish> Fish
        {
            get
            {
                return this.fish;
            }
            private set
            {
                this.fish = value;
            }
        }

        public void AddDecoration(IDecoration decoration)
        => this.Decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (this.Capacity == this.Fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var item in Fish)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (this.Fish.Count < 1)
            {
                sb.AppendLine($"Fish: none");
            }
            else
            {
                sb.AppendLine($"Fish: {String.Join(", ", Fish.Select(x => x.Name))}");
            }
            
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString().Trim();

        }

        public bool RemoveFish(IFish fish)
        => this.Fish.Remove(fish);
    }
}
