using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_HSP_B4
{
    public class rund
    {
        double durchmesser, länge, dichte;
        double fläche, volumen;
        double gewicht;
        double[] flächenträgheitsmoment;
        public rund(double dichte, double durchmesser, double länge2)
        {
            this.durchmesser = durchmesser;
            this.dichte = dichte;
            this.länge = länge2;
            fläche = calculateFläche();
            volumen = calculateVolumen();
            gewicht = calculateGewicht();
            flächenträgheitsmoment = calculateFlächenträgheitsmoment();

        }

        public double calculateFläche()
        {
            return Math.PI * durchmesser;
        }
        public double calculateVolumen()
        {
            return Math.PI * durchmesser * länge;
        }
        public double calculateGewicht()
        {
            return volumen * dichte;
        }
        public double[] calculateFlächenträgheitsmoment()
        {
            double[] momente = new double[5];
            momente[0] = Math.PI * Math.Pow(durchmesser / 2, 4) / 4;
            momente[1] = Math.PI * Math.Pow(durchmesser / 2, 4) / 4;
            momente[2] = 0;
            momente[3] = Math.PI * Math.Pow(durchmesser / 2, 4) / 2;
            momente[4] = ((Math.PI * 5) / 4) * Math.Pow(durchmesser / 2 ,4);
            return momente;
        }

        public List<double> getInformation()
        {
            List<double> infos = new List<double>();
            infos.Add(fläche);
            infos.Add(volumen / 1000);
            infos.Add(gewicht / 100000);
            foreach (double m in flächenträgheitsmoment)
            {
                infos.Add(m);
            }
            return infos;
        }
    }
}
