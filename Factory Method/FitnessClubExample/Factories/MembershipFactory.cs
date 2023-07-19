using FitnessClubExample.Products.Interfaces;

namespace FitnessClubExample.Factories
{
    internal abstract class MembershipFactory
    {
        public abstract IMembership GetMembership();
    }
}
