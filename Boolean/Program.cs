// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        bool isRainy = true;
        bool isSunny = false;
        bool isWindy = false;

        bool needUmbrella = UseUmbrella(isRainy, isSunny, isWindy);
        System.Console.WriteLine("Apakah perlu payung? " + needUmbrella);

        int a = 10;
        int b = 20;
        int max = Max(a,b);
        System.Console.WriteLine("a = "+a+" dan b = "+b+" maka angka terbesar adalah "+max);
    }

    static bool UseUmbrella (bool rainy, bool sunny, bool windy)
    {
        // 1. Short-Circuit Evaluation --> evaluasi lebih cepat

        // cek hujan atau tidak --> OR
        bool isRainyToday = rainy || sunny;

        // butuh payung kalau pas hujan saja dan tidak berangin --> AND
        // kalau berangin payung tidak akan efektif --> NOT
        return !windy && isRainyToday;

        // 2. Non-Short-Circuiting Logical Operators (& and |)
        return !windy & (rainy | sunny);
    }

    static int Max (int a, int b)
    {
        // 3. Conditional Operator

        return (a > b) ? a : b;

        // sama saja dengan

        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        };
    }
}