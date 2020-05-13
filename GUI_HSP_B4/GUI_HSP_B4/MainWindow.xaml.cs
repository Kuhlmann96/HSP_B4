using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_HSP_B4
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var item = formen.SelectedItem as TreeViewItem;
            String form = item.Header.ToString();


            var matItem = treemat.SelectedItem as TreeViewItem;
            String mat = matItem.Header.ToString();
            double dichte = 1;
            switch (mat)
            {
                case "Stahl":
                    dichte = 0.785;
                    break;
                case "Aluminium":
                    dichte = 0.270;
                    break;
                case "Edelstahl":
                    dichte = 0.790;
                    break;
            }



            List<double> infos = null;
            switch (form)
            {

                case "Rechteck":
                    double höhe = Double.Parse(param1Wert.Text);
                    double breite = Double.Parse(param2Wert.Text);
                    double wandstärke = Double.Parse(wandstärkeWert.Text);
                    double länge = Double.Parse(längeWert.Text);
                    Rechteck r = new Rechteck(dichte, höhe, breite, wandstärke, länge);
                    infos = r.getInformation();
                    break;
                case "Vierkant":
                    Vierkant v = new Vierkant(dichte);
                    break;
                case "Kreis":
                    Kreis k = new Kreis(dichte);
                    break;
                case "Rund":
                    Rund ru = new Rund(dichte);
                    break;
                case "T":
                    T t = new T(dichte);
                    break;

            }

            flächeWert.Content = String.Format("{0:0.00}", infos.ElementAt(0));
            volumenWert.Content = String.Format("{0:0.00}", infos.ElementAt(1));
            gewichtWert.Content = String.Format("{0:0.00}", infos.ElementAt(2));
            IyWert.Content = String.Format("{0:0.00}", infos.ElementAt(3));
            IzWert.Content = String.Format("{0:0.00}", infos.ElementAt(4));
            IyzWert.Content = String.Format("{0:0.00}", infos.ElementAt(5));
            IpWert.Content = String.Format("{0:0.00}", infos.ElementAt(6));
            IyyWert.Content = String.Format("{0:0.00}", infos.ElementAt(7));
        }

        private void SelectionChanged(object sender, RoutedEventArgs e)
        {
            var tree = sender as TreeView;
            var item = tree.SelectedItem as TreeViewItem;
            String itemString = item.Header.ToString();
            objekt.Content = itemString;
            BitmapImage image = new BitmapImage(new Uri(@"/GUI_HSP_B4;component/Bilder/"+itemString+".PNG", UriKind.Relative));
            bild.Source = image;

            switch(itemString)
            {
                case "Rechteck":
                    param1Text.Content = "H:";
                    param2Text.Content = "B:";
                    param1Text.Visibility = Visibility.Visible;
                    param1Wert.Visibility = Visibility.Visible;
                    param2Text.Visibility = Visibility.Visible;
                    param2Wert.Visibility = Visibility.Visible;
                    break;
                case "Kreis":
                    param1Text.Content = "D:";
                    param1Text.Visibility = Visibility.Visible;
                    param1Wert.Visibility = Visibility.Visible;
                    param2Text.Visibility = Visibility.Hidden;
                    param2Wert.Visibility = Visibility.Hidden;
                    break;

            }

        }
    }
}
