using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Spieler_WpfApplication
{
    
    class Spieler
    {
        public static int laufende;
        public Image spieler = new Image();
        public int rueckennummer;
        public int row, column;

        public Spieler()
        {
            rueckennummer = laufende++;
            spieler.Source =
                new BitmapImage(new Uri("C:\\Users\\Zimmermann\\Documents\\C#\\WPF\\Spieler_WpfApplication\\Spieler_WpfApplication\\spieler.png"));

            switch(rueckennummer)
            {
                case 1:
                    row = 0;
                    column = 1;
                    break;
                case 2:
                    row = 1;
                    column = 1;
                    break;
                case 3:
                    row = 1;
                    column = 2;
                    break;
                case 4:
                    row = 1;
                    column = 3;
                    break;
                case 5:
                    row = 2;
                    column = 0;
                    break;
                case 6:
                    row = 2;
                    column = 1;
                    break;
                case 7:
                    row = 2;
                    column = 2;
                    break;
                case 8:
                    row = 2;
                    column = 3;
                    break;
                case 9:
                    row = 3;
                    column = 1;
                    break;
                case 10:
                    row = 3;
                    column = 2;
                    break;
                case 11:
                    row = 3;
                    column = 3;
                    break;
            }
        }
    }
}
