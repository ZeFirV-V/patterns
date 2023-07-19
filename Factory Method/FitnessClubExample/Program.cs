using FitnessClubExample.Products;
using FitnessClubExample.Factories;

class Program
{
    static void Main()
    {
        Console.WriteLine(">>> Welcome. This is example Factory Method");
        Console.WriteLine(">>> Введите абонемент, который вы хотите создать");
        Console.WriteLine("> G - Gym");
        Console.WriteLine("> P - Gym + Pool");
        Console.WriteLine("> T - personal Training");
        var membershipType = Console.ReadLine();
        var membershipFactory = GetFactory(membershipType.ToLower());
        var membership = membershipFactory.GetMembership();
        Console.WriteLine(membership.Name);
        Console.WriteLine(membership.GetPrice());
    }

    private static MembershipFactory GetFactory(string membershipType)
    {
        switch(membershipType)
        {
            case "g":
                return new GymMembershipFactory(100, "Basic membership");
            case "p":
                return new GymPlusPoolMembershipFactory(200, "Good price member");
            case "t":
                return new PersonalTrainingMembershipFactory(400, "Best for professional");
            default:
                Console.WriteLine("Ввели что то не то");
                Console.WriteLine("Попробуйте снова");
                return GetFactory(Console.ReadLine());
        }
    }
}