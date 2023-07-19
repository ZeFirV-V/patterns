using FitnessClubExample.Products;
using FitnessClubExample.Products.Interfaces;

namespace FitnessClubExample.Factories
{
    internal class GymMembershipFactory : MembershipFactory
    {
        private readonly decimal _price;
        private readonly string _description;

        public GymMembershipFactory(decimal price, string description)
        {
            _price = price;
            _description = description;
        }

        public override IMembership GetMembership()
        {
            return new GymMembership(_price);
        }
    }
}