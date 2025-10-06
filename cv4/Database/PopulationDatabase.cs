using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class PopulationDatabase
    {
        private Person[] population = new Person[5];
        private int index = -1;
        public void Add(Person person)
        {
            index++;
            if (index == population.Length)
            {
                Person[] tmp = new Person[population.Length + 3];
                Array.Copy(population, tmp, population.Length);
                population = tmp;
            }
            population[index] = person;
        }

        public int Count
        {
            get
            {
                return index + 1;
            }
        }

        public int AdultCount
        {
            get
            {
                int count = 0;
                for (int i = 0; i <= index; i++)
                {
                    if (population[i].IsAdult == true) count++;
                }
                return count;
            }
        }

        public double? GetAverageAge()
        {
            if (index < 0) return null;

            int ageSum = 0;
            int peopleWithAge = 0;
            for (int i = 0; i <= index; i++)
            {
                if (population[i].Age.HasValue)
                {
                    peopleWithAge++;
                    ageSum += population[i].Age.Value;
                }
            }

            if (peopleWithAge == 0) return null;
            return (double)ageSum / (double)peopleWithAge;
        }
    }
}
