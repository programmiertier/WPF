using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace EigeneKlasseIn_WpfApplication
{
    public class Kunde
    {
        public static int kundennummer;
        public Image wagen = new Image();      // WPFKlasse in normaler .cs Umgebung verwenden
                                        // entsprechendes using muss verwendet werden, in dem Fall using System.Windows.Controls;

        public Kunde()
        {
            kundennummer++;
            wagen.Source = 
                new BitmapImage(new Uri("C:\\Users\\kaffeetier\\Documents\\c#\\WPF\\EigeneKlasseIn_WpfApplication\\EigeneKlasseIn_WpfApplication\\shopping-cart.png"));
        }
    }
}
