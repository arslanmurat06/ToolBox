using System;

namespace Records
{
    /// <summary>
    /// Records
    /// </summary>

    ////////////////////Part -1 \\\\\\\\\\\\\\\\\\\\\\\\
    //without constructor
    public record Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }


    ////////////////////Part -2 \\\\\\\\\\\\\\\\\\\\\\\\
    //with constructor and immutable properties

    public record Human
    {
        public string Name { get; init; }
        public string Surname { get; init; }

        public Human(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            ////////////////////Part -1 \\\\\\\\\\\\\\\\\\\\\\\\

            Person person = new Person { Name = "Murat", Surname = "Arslan" };

            //it has tostring itself
            Console.WriteLine(person); // => output Person { Name = Murat, Surname = Arslan }

            //we can create new record with only name different by using with keyword
            Person person1 = person with { Name = "Hasan" };
            Console.WriteLine(person1); // => output Person { Name = Hasan, Surname = Arslan }



            ////////////////////Part -2 \\\\\\\\\\\\\\\\\\\\\\\\


            Human human = new Human("Murat", "Arslan");
            Human human1 =human with { };


            //can make comparison
            Console.WriteLine(person == person1); // => false
            Console.WriteLine(human == human1); // => true

           



            Console.Read();

        }
    }
}
