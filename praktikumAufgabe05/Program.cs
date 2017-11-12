using System;
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
            Console.WriteLine();
            Console.WriteLine("Berechnung der Zahl PI:");
            double pi = Pi(1000000);
            Console.WriteLine($"Pi: {pi} vs. {Math.PI} = {pi-Math.PI}");

            Console.ReadLine();
        }


        //Diese Funktion gibt den Absolutwert einer Gleitkommazahl zurück
        static double Absolutwert(double x)
        {
            //Wenn Zahl negativ, invertiere sie
            if (x<0)
            {
                x = -x;
            }

            return x;
        }

     //Diese Funktion berechnet die Fakultaet einer Zahl
        static int Fakultaet(int n)
        {
            int ergebnis = 1;

            for(int i=1; i<=n; i++)
            {
                ergebnis *= i;
            }

            return ergebnis;
        }

       //Diese Funktion berechnet die Quadratwurzel einer Zahl nach dem Heron-Verfahren
        static double WurzelHeron(double x)
        {
            double wurzel=1; //Startwert x0

            //Schleife, läuft bis das berechnete Ergebnis von realen Wert nur noch weniger als 1*10^-12 abweicht
            while ((x - wurzel * wurzel) > 1E-12 || (x - wurzel * wurzel) < - 1e-12)
            {
                wurzel = ((double)1 / 2) * (wurzel + x / wurzel);
            }

            return wurzel;
        }

        //Diese Funktion berechnet die Zahl Pi aus einer Menge an Zufallszahlen
        static double Pi(int anzahlWuerfe)
        {
            //initialisieren des Zufallsgenerators
            Random zufall = new Random();

            double pi;
            double x;
            double y;
            int ausserhalb = 0;
            int innerhalb = 0;

            for (int i=0; i<anzahlWuerfe; i++)
            {
                //berechnen von zwei Zufallszahlen
                x = zufall.NextDouble();
                y = zufall.NextDouble();

                //bestimmen ob Koordinaten der Zufallszahlen innerhalb/außerhalb des Einheitskreises sind
                //(per Pythagoras)
                if (WurzelHeron(x * x + y * y) <= 1)
                    innerhalb++;
                else
                    ausserhalb++;
            }
            //bestimmen des Verhältnisses von Zahlen innerhalb zu Gesammtmenge, multiplizieren mit 4 um auf Pi zu kommen
            pi = (double)innerhalb / (innerhalb + ausserhalb)*4;
            return pi;
        }
    }
}
