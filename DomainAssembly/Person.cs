using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainAssembly
{
    [Serializable]
    internal class Person
    {
        string Name;
        string LastName;
        int Age;

        public Person(string name, string lastname, int age)
        {
            Name = name;
            LastName = lastname;
            Age = age;
        }

        public void Print()
        {
            Console.WriteLine(Name + " " + LastName + "Age: " + Age.ToString());
            Console.WriteLine(Name + " " + LastName + "Age: " + Age.ToString());
        }
    }
}
