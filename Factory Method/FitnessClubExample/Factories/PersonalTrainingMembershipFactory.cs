using FitnessClubExample.Products;
using FitnessClubExample.Products.Interfaces;

namespace FitnessClubExample.Factories
{
    internal class PersonalTrainingMembershipFactory : MembershipFactory
    {
        private readonly decimal _price;
        private readonly string _description;

        public PersonalTrainingMembershipFactory(decimal price, string description)
        {
            _price = price;
            _description = description;
        }

        public override IMembership GetMembership()
        {
            return new PersonalTrainingMembership(_price);
        }
    }
}
