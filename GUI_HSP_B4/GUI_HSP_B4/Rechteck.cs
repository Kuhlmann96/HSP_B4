using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GUI_HSP_B4
{
    public class Rechteck
    {
        double höhe, breite, länge, wandstärke, dichte;
        double fläche, volumen;
        double gewicht;
        double[] flächenträgheitsmoment;
        public Rechteck(double dichte, double höhe, double breite, double wandstärke, double länge)
        {
            this.höhe = höhe;
            this.breite = breite;
            this.wandstärke = wandstärke;
            this.dichte = dichte;
            this.länge = länge;
            fläche = calculateFläche();
            volumen = calculateVolumen();
            gewicht = calculateGewicht();
            flächenträgheitsmoment = calculateFlächenträgheitsmoment();
           
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

        public List<double> getInformation()
        {
            List<double> infos = new List<double>();
            infos.Add(fläche);
            infos.Add(volumen / 1000);
            infos.Add(gewicht / 100000);
            foreach(double m in flächenträgheitsmoment)
            {
                infos.Add(m);
            }
            return infos;
        }
    }
}
