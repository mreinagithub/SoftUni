﻿namespace DefiningClasses
{
    using System;
    using System.Reflection;

    public class Startup
    {
        static void Main()
        {
            Type personType = typeof(Person);
            ConstructorInfo emptyCtor = personType.GetConstructor(new Type[] { });
            ConstructorInfo ageCtor = personType.GetConstructor(new[] { typeof(int) });
            ConstructorInfo nameAgeCtor = personType.GetConstructor(new[] { typeof(string), typeof(int) });

            bool swapped = false;
            if (nameAgeCtor == null)
            {
                nameAgeCtor = personType.GetConstructor(new[] { typeof(int), typeof(string) });
                swapped = true;
            }

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
            Person personWithAge = (Person)ageCtor.Invoke(new object[] { age });

            Person personWithAgeAndName = swapped ?
                                          personWithAgeAndName = (Person)nameAgeCtor.Invoke(new object[] { age, name })
                                          :
                                          personWithAgeAndName = (Person)nameAgeCtor.Invoke(new object[] { name, age });


            Console.WriteLine($"{basePerson.name} {basePerson.age}");
            Console.WriteLine($"{personWithAge.name} {personWithAge.age}");
            Console.WriteLine($"{personWithAgeAndName.name} {personWithAgeAndName.age}");
        }
    }
}
