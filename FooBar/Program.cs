// See https://aka.ms/new-console-template for more information
using System;

namespace NamaProyek
{
 class Program
   {
       static void Main(string[] args)
       {
            int n = 105;
            for (int i=1; i<=n; i++)
            {
                string output = "";
                if (i%3 == 0)
                {
                    output += "foo";
                } 
                if (i%5 == 0)
                {
                    output += "bar";
                }
                if (i % 7 == 0)
                {
                    output += "jazz";
                } 
                if (output=="")
                {
                    System.Console.WriteLine(i);
                }
                else
                {
                    System.Console.WriteLine(output);
                }
            }
            
       }
   }
}
