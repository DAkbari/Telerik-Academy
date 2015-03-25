﻿using System;

public static class AnnonymousTypes
{
    public static void Main()
    {
        var myCar = new { Color = "Red", Brand = "BMW", Speed = 180 };
        Console.WriteLine("My car is a {0} {1}.", myCar.Color, myCar.Brand);//My car is a Red BMW.
        Console.WriteLine("It runs {0} km/h.", myCar.Speed);//It runs 180 km/h.

        Console.WriteLine();

        var p = new { X = 3, Y = 5 };
        var q = new { X = 3, Y = 5 };
        Console.WriteLine(p);//{ X = 3, Y = 5 }
        Console.WriteLine(q);//{ X = 3, Y = 5 }
        Console.WriteLine(p == q); //False
        Console.WriteLine(p.Equals(q)); //True

        Console.WriteLine();

        var combined = new { P = p, Q = q };
        Console.WriteLine(combined.P.X);//3

        Console.WriteLine();

        var arr = new[]
                      {
                          new { X = 3, Y = 5 },
                          new { X = 1, Y = 2 },
                          new { X = 0, Y = 7 }
                      };
        foreach (var item in arr)
        {
            Console.WriteLine("({0}, {1})", item.X, item.Y);
            //(3, 5)
            //(1, 2)
            //(0, 7)
        }
    }
}
