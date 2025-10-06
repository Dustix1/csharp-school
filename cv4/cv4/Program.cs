using Database;

namespace cv4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person()
            {
                Name = "Jan",
                Age = 36,
                Gender = GenderEnum.Male,
            };

            Person p2 = new Person()
            {
                Name = "Erik",
                Age = 7,
                Gender = GenderEnum.Male
            };

            Person p3 = new Person()
            {
                Name = "Ondra",
                Gender = GenderEnum.Male
            };

            Person p4 = new Person()
            {
                Name = "Ellie",
                Age = 24,
                Gender = GenderEnum.Female
            };

            PopulationDatabase pd = new PopulationDatabase();
            pd.Add(p1);
            pd.Add(p2);
            pd.Add(p3);
            pd.Add(p4);

            Console.WriteLine(pd.Count);
            Console.WriteLine(pd.AdultCount);
            Console.WriteLine(pd.GetAverageAge());
        }
    }
}
