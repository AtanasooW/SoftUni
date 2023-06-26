namespace AquaShop.Core
{
using System;
using System.Collections.Generic;
using System.Text;
    using System.Linq;

    using Repositories.Contracts;
    using Models.Decorations.Contracts;
    using Models.Aquariums.Contracts;
    using Models.Aquariums;
    using Contracts;
    using Utilities.Messages;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Models.Fish;
    using Repositories;

    public class Controller : IController
    {
        private IRepository<IDecoration> decorationRepository;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorationRepository = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAquariumType));
            }
            this.aquariums.Add(aquarium);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidDecorationType));
            }
            this.decorationRepository.Add(decoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            IFish fish = null;
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
                if (aquarium.GetType().Name == "FreshwaterAquarium")
                {
                    aquarium.AddFish(fish);
                    return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
                else
                {
                    return String.Format(OutputMessages.UnsuitableWater);
                }
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName,fishSpecies,price);
                if (aquarium.GetType().Name == "SaltwaterAquarium")
                {
                    aquarium.AddFish(fish);
                    return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
                else
                {
                    return String.Format(OutputMessages.UnsuitableWater);
                }
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidFishType));
            }

        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal priceFromDecorations = aquarium.Decorations.Sum(x => x.Price);
            decimal priceFromFish = aquarium.Fish.Sum(x => x.Price);
            decimal allprice = priceFromDecorations + priceFromFish;
            return String.Format(OutputMessages.AquariumValue, aquariumName, allprice);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            List<IFish> list = (List<IFish>)aquarium.Fish;
            aquarium.Feed();
            List<IFish> list1 = (List<IFish>)aquarium.Fish;
            int counter = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Size == list[i].Size)
                {
                    counter++;
                }
            }
            return String.Format(OutputMessages.FishFed, counter);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            IDecoration decoration = this.decorationRepository.Models.FirstOrDefault(x => x.GetType().Name == decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            aquarium.AddDecoration(decoration);
            this.decorationRepository.Remove(decoration);
            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var item in aquariums)
            {
                sb.AppendLine(item.GetInfo());
            }
            return sb.ToString().Trim();
        }
    }
}
