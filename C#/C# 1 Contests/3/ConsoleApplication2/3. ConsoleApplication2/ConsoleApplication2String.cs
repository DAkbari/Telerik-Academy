﻿// 80/100 in bgcoder
using System;
using System.Numerics;

class ConsoleApplication2String
{
    static void Main()
    {
        string input = Console.ReadLine();

        int position = 0;
        BigInteger product10 = 1;
        BigInteger productAfter10 = 1;

        while (input != "END")
        {
            if (position % 2 == 0 && input != "0")
            {
                BigInteger product = 1;
                foreach (var symbol in input)
                {
                    if (symbol != '0')
                    {
                        product *= symbol - '0';
                    }
                }

                if (position < 10)
                {
                    product10 *= product;
                }
                else //if (position >= 10)
                {
                    productAfter10 *= product;
                }
            }

            input = Console.ReadLine();
            position++;
        }

        Console.WriteLine(product10);
        if (position > 9)
        {
            Console.WriteLine(productAfter10);
        }

    }
}