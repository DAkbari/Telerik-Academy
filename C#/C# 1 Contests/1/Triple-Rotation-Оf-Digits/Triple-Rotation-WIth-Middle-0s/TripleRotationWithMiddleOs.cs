﻿/* Zeroes could also take part in the play and 
   the leading digits are lost if are in the begining of the number: 
   123400 => 400123; 123004 => 4123; 123000 => 123  */

using System;

class TripleRotationWithMiddleOs
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        if (0 < number && number < 10)
        {
            Console.WriteLine(number);
        }
        else if (9 < number && number < 100)
        {
            if (number % 10 != 0)
            {
                Console.WriteLine("{0}{1}", number % 10, number / 10);
            }
            else
            {
                Console.WriteLine(number / 10);
            }
        }
        else if (99 < number && number < 1000)
        {
            Console.WriteLine(number);
        }
        else
        {
            int firstDigits = number / 1000;
            int last3Digits = number % 1000;
            int digit1 = last3Digits / 100;
            int digit2 = last3Digits / 10 % 10;
            int digit3 = last3Digits % 10;
            
            if (digit1 == 0)
            {
                if (digit2 == 0)
                {
                    if (digit3 == 0)
                    {
                        Console.WriteLine(firstDigits);
                    }
                    else
                    {
                        Console.WriteLine("{0}{1}", digit3, firstDigits);
                    }
                }
                else
                {
                    Console.WriteLine("{0}{1}{2}", digit2, digit3, firstDigits);
                }
            }
            else
            {
                Console.WriteLine("{0}{1}{2}{3}", digit1, digit2, digit3, firstDigits);
            }
        }
    }
}