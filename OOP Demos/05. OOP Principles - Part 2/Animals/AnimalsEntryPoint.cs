﻿namespace Animals
{
    using Animals;
    using System;
    using System.Collections.Generic;

    public class AnimalsEntryPoint
    {
        // using polymorphism - pass more specific object ro a method that expects a parameter of more generic type
        public static void SayAnimalName(IAnimal animal)
        {
            //// this is anti QPC => Don't do it!
            //if (animal is Cat)
            //{
            //    var animalAsCat = animal as Cat;
            //    Console.WriteLine(animalAsCat.Purr());
            //}

            Console.WriteLine(animal.Name);
        }

        public static void Main()
        {
            // polymorphism - we use given data type through other data type (interface or parent class)
            IAnimal cat = new Cat("Dzhoni");
            IAnimal dog = new Dog("Sharo");

            Console.WriteLine(cat.Speak());
            Console.WriteLine(dog.Speak());

            // no polymorphism
            var secondCat = new Cat("Dzhinks");
            Cat thirdCat = new Cat("Fluffy");

            Console.WriteLine(secondCat.Purr());
            Console.WriteLine(thirdCat.Purr());
            // cat has no Purr() method, because it's IAnimal

            var secondDog = new Dog("Doggy");
            Dog thirdDog = new Dog("Spike");

            Console.WriteLine(secondDog.CatchBone());
            Console.WriteLine(thirdDog.CatchBone());
            // dog has no CatchBone() method, because it's IAnimal

            Console.WriteLine();

            // without polymorphism
            List<Cat> cats = new List<Cat>();
            cats.Add(secondCat);
            cats.Add(thirdCat);

            List<Dog> dogs = new List<Dog>();
            dogs.Add(secondDog);
            dogs.Add(thirdDog);

            foreach (var curCat in cats)
            {
                Console.WriteLine(curCat.Speak());
            }

            foreach (var curDog in dogs)
            {
                Console.WriteLine(curDog.Speak());
            }

            Console.WriteLine();

            // using polymorphism - mix different related types in the same collection
            List<IAnimal> animals = new List<IAnimal>();
            animals.Add(cat);
            animals.Add(secondCat);
            animals.Add(thirdCat);
            animals.Add(dog);
            animals.Add(secondDog);
            animals.Add(thirdDog);

            foreach (var curAnimal in animals)
            {
                Console.WriteLine(curAnimal.Speak());
            }

            Console.WriteLine();

            // using polymorphism - invoke abstract operations
            SayAnimalName(cat);
            SayAnimalName(secondCat);
            SayAnimalName(thirdCat);
            SayAnimalName(dog);
            SayAnimalName(secondDog);
            SayAnimalName(thirdDog);

            Console.WriteLine();

            // using polymorphism - declare a more generic field which will be initialized and "specialized" later
            IAnimal animal;
            string animalType = "Cat";
            switch (animalType)
            {
                case "Cat": { animal = new Cat("Puh"); Console.WriteLine(animal.Name); break; }
                case "Dog": { animal = new Dog("Snoop"); Console.WriteLine(animal.Name); break; }
                default:
                    break;
            }

            
        }
    }
}