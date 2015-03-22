﻿namespace CatSystem
{
    using System;
    using System.Collections.Generic;

    public class CatSystemStart
    {
        public static void ChangeCatName(Cat cat)
        {
            cat.Name = "Johny";
        }

        public static void Main()
        {
            // create two instances of Owner
            var peshoOwner = new Owner("Pesho", "Ivanov");
            var goshoOwner = new Owner("Gosho", "Petrov");

            //// if get and set are not private => the property Age can be appropriated and changed/edited: 
            //var age = peshoOwner.Age;
            //peshoOwner.Age = 11;

            peshoOwner.IncreaseAge();
            Console.WriteLine(peshoOwner.Age);  //1

            Console.WriteLine(peshoOwner.FullName); // Pesho Ivanov

            var cat = new Cat(CatColor.White);
            //whiteCat.Owner = peshoOwner;
            var anotherCat = new Cat(CatColor.Black);
            var yetAnotherCat = new Cat(CatColor.Brown);

            peshoOwner.AddCat(cat, "Dzhinks");
            peshoOwner.AddCat(anotherCat, "Silvestar");

            // this will cause Unhandled Exception: System.NullReferenceException: Object reference not set to an instance of an object. => Line 25 in Owner.cs
            Console.WriteLine(peshoOwner.AllCats);  //Dzhinks, Silvestar

            // print static property
            Console.WriteLine(Cat.NumberOfLegs);    //4

            // print the result from a static method WhatDoesTheCatSay()
            Console.WriteLine(Cat.WhatDoesTheCatSay()); //Mew!

            // invoke the static method PrintCat() in static class Printer
            Printer.PrintCat(cat);  //Dzhinks 0

            // changing cat's name, because it's reference data type 
            ChangeCatName(anotherCat);
            Console.WriteLine(anotherCat.Name); //Johny

            // example fot using structure
            var point = new Point();
            point.X = 4.5m;
            point.Y = 18.9m;
            Console.WriteLine(point.GetCoordinates());  // 4.5, 18.9 

            // using generics
            //// don't work because int is not Animal
            //var intList = new GenericList<int>();
            //intList.Add(1);
            //intList.Add(2);

            //// don't work because string is not Animal
            //var strList = new GenericList<string>();
            //strList.Add("1");
            //strList.Add("2");

            var catList = new GenericList<Cat>();
            catList.Add(new Cat(CatColor.Brown));

            var myList = new GenericList<Animal>();
            var anotherMyList = new GenericList<Dog>();

            // example using generic method
            var value = GetString<int>(5);      // works if T can be struct
            //var value = GetString(5);         // this works too if T can be struct 
            var anotherValie = GetString<bool>(true); // works if T can be struct
            //var kitten = GetString<Cat>(new Cat(CatColor.Brown));   // works if T can be class
            //var kitten = GetString(new Cat(CatColor.Brown));        // works too if T can be class

            // example for generic method T Min<T>(T first, T second) where T : IComparable<T>
            var min = Min<int>(5, 6);
            Console.WriteLine(min); //5
        }


        // generic method, which expects T to be a structure
        public static string GetString<T>(T element)
        //  public static string GetString<T>(T element) where T : struct
        {
            return element.ToString();
        }

        //// don't do that
        //// but in this case ususally generic will invoke first
        //public static string GetString(object element)
        //{
        //    return element.ToString();
        //}

        public static T Min<T>(T first, T second) where T : IComparable<T>
        {
            if (first.CompareTo(second) <= 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

    }
}