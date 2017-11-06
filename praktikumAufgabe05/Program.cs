﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktikumAufgabe05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wurzelberechnung mit dem Heronverfahren:");
            for (double d = 0; d <= 100; d += 10)
            {
                Console.WriteLine($"{d,4}  | {WurzelHeron(d),8:F5} | {Math.Sqrt(d),8:F5} |{ Math.Sqrt(d) - WurzelHeron(d)}");
            }
            Console.WriteLine();
            Console.WriteLine("Fakultätsberechnung:");
            for (int i = 0; i < 18; i++)
            {
                Console.WriteLine($"{i,2} | {Fakultaet(i)}");
            }
            //Console.WriteLine();
            //Console.WriteLine("Berechnung der Zahl PI:");
            //double pi = Pi(1000000);
            //Console.WriteLine($"Pi: {pi} vs. {Math.PI} = {pi‐Math.PI}");

            Console.ReadLine();
        }

        //Diese Funktion gibt den Absolutwert einer Gleitkommazahl zurück
        static double Absolutwert(double x)
        {
            if (x<0)
            {
                x = -x;
            }

            return x;
        }

     
        static int Fakultaet(int n)
        {
            int ergebnis = 1;

            for(int i=1; i<=n; i++)
            {
                ergebnis *= i;
            }

            return ergebnis;
        }

        //Unfinished!!!!!!!!!!!!!!!!!!!!!
        static double WurzelHeron(double x)
        {
            double wurzel=1;
            while ((x - wurzel * wurzel) > 1E-12 || (x - wurzel * wurzel) < - 1e-12)
            {
                wurzel = ((double)1 / 2) * (wurzel + x / wurzel);
            }

            return wurzel;
        }
    }
}
