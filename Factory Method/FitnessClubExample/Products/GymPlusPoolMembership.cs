using FitnessClubExample.Products.Interfaces;

namespace FitnessClubExample.Products
{
    internal class GymPlusPoolMembership : IMembership
    {
        private readonly string _name;
        private readonly decimal _price;

        public GymPlusPoolMembership(decimal price)
        {
            _name = "Gym + pool membership";
            _price = price;
        }

        public string Name => _name;
        public string Description { get; set; }
        public decimal GetPrice() => _price;
    }
}
