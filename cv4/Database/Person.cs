using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Person
    {
        public string Name { get; set; }

        private int? age;
        public int? Age {
            get
            {
                return age;
            }
            set 
            {
                if (value < 0 || value > 150)
                {
                    value = null;
                }
                
                this.age = value;
            }
        }
        public bool? IsAdult
        {
            get
            {
                if (this.Age == null) return null;
                return this.Age >= 18;
            }
        }


        public GenderEnum? Gender {  get; set; }


        public override string ToString()
        {
            return $"{this.Name}, {this.Age}, {this.Gender}";
        }

    }
}
