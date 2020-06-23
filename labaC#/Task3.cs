using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp5
{
    public class Task3
    {
        public static int Calculate(LinkedList<int> a)
        {
            LinkedList<int> positive = new LinkedList<int>();
            LinkedList<int> negative = new LinkedList<int>();

            for (int i = 0; i < a.GetLenght(); i++)
            {
                if (a[i] < 0)
                {
                    negative.Add(a[i]);
                }

                if (a[i] > 0)
                {
                    positive.Add(a[i]);
                }
            }

            positive.Reverse();

            int k = positive.GetLenght() < negative.GetLenght() ? positive.GetLenght() : negative.GetLenght();

            int sum = 0;

            for (int i = 0; i < k; i++)
            {
                sum += positive[i] * negative[i];
            }

            return sum;
        }
    }
}