using System;

namespace ImmutablePropertiesWithInit
{
    /// <summary>
    /// C#9 init
    /// </summary>

    // To make immutable properties without using  constructor


    //To make immutable properties


    //Before c#9
    class Employee
    {
        public string Name { get; }
        public string Surname { get; }


        //We can set this properties by using constructor
        public Employee(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }


    //With C#9

    class Boss
    {
        public string Name { get; init; }
        public string Surname { get; init; }
    }


    class Program
    {
        static void Main(string[] args)
        {

            //Before C#9
            //We can initialize these properties with constructor

            //We can't use object initializer
            Employee employee = new Employee("Murat", "Arslan");

            //With C#9
            //we can use object initializer any more
            Boss boss = new Boss { Name = "Murat", Surname = "Arslan" };

            //You do not need to use all init-only properties
            Boss boss1 = new Boss { Name = "Murat" };

            Console.ReadLine();
        }
    }
}
