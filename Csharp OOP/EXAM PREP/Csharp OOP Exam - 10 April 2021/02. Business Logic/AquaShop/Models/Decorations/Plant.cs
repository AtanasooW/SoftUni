namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int comfortForPlant = 5;
        private const int priceForPlant = 10;
        public Plant() : base(comfortForPlant, priceForPlant)
        {
        }
    }
}
