//#define version1
#define version2
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Autre;

namespace InjectionServiceApp
{
    internal class Program
    {
        //Inverse of control Container
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerable<int> numbers2 = new List<int>{1,2,3,4,5,6,7,8,9 };

            numbers.Enumerer();
          
        }
    }
 
}

namespace Autre
{
    static public class IEnumerableExtension
    {
        static public void Enumerer(this IEnumerable<int> ints)
        {
            foreach (var item in ints)
                Console.WriteLine(item);
        }
    }
}

