using FitnessClubExample.Products;
using FitnessClubExample.Products.Interfaces;

namespace FitnessClubExample.Factories
{
    internal class GymPlusPoolMembershipFactory : MembershipFactory
    {
        private readonly decimal _price;
        private readonly string _description;

        public GymPlusPoolMembershipFactory(decimal price, string description)
        {
            _price = price;
            _description = description;
        }

        public override IMembership GetMembership()
        {
            return new GymPlusPoolMembership(_price);
        }
    }
}
