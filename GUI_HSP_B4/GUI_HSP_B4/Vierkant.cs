using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_HSP_B4
{

    public class Vierkant
    {
        double höhe, breite, länge, wandstärke, dichte;
        double fläche, volumen;
        double gewicht;
        double[] flächenträgheitsmoment;
        public Vierkant(double dichte)
        {
            this.dichte = dichte;
            // Eingabe
            Console.WriteLine("Breite in mm eingeben");
            breite = Double.Parse(Console.ReadLine());
            Console.WriteLine("Höhe in mm eingeben");
            höhe = Double.Parse(Console.ReadLine());
            Console.WriteLine("Länge in mm eingeben");
            länge = Double.Parse(Console.ReadLine());
            Console.WriteLine("Wandstärke in mm eingeben");
            wandstärke = Double.Parse(Console.ReadLine());
            // Berechnung
            fläche = calculateFläche();
            volumen = calculateVolumen();
            gewicht = calculateGewicht();
            flächenträgheitsmoment = calculateFlächenträgheitsmoment();
            // Ausgabe
            showInformation();
        }

        public double calculateFläche()
        {
            return höhe * breite;
        }
        public double calculateVolumen()
        {
            return (fläche - (höhe - wandstärke * 2) * (breite - wandstärke * 2)) * länge;
        }
        public double calculateGewicht()
        {
            return volumen * dichte;
        }
        public double[] calculateFlächenträgheitsmoment()
        {
            double[] momente = new double[5];
            momente[0] = Math.Pow(höhe, 3) * breite / 12;
            momente[1] = Math.Pow(breite, 3) * höhe / 12;
            momente[2] = 0;
            momente[3] = breite * höhe / 12 * (Math.Pow(höhe, 2) + Math.Pow(breite, 2));
            momente[4] = (breite * Math.Pow(höhe, 3)) / 3;
            return momente;
        }

        public void showInformation()
        {
            Console.WriteLine("Querschnittsfläche in mm² = " + String.Format("{0:0.00}", fläche));
            Console.WriteLine("Volumen in cm³ = " + String.Format("{0:0.00}", volumen / 1000));
            Console.WriteLine("Gewicht  in kg = " + String.Format("{0:0.00}", gewicht / 100000));
            double[] momente = calculateFlächenträgheitsmoment();
            Console.WriteLine("Flächenträgheitsmomente: ");
            Console.WriteLine("Iy: " + String.Format("{0:0.00}", momente[0]));
            Console.WriteLine("Iz: " + String.Format("{0:0.00}", momente[1]));
            Console.WriteLine("Iyz: " + String.Format("{0:0.00}", momente[2]));
            Console.WriteLine("Ip: " + String.Format("{0:0.00}", momente[3]));
            Console.WriteLine("Iyy: " + String.Format("{0:0.00}", momente[4]));

        }
    }
}
