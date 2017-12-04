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

namespace Wunschliste_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double summe;
        public MainWindow()
        {
            InitializeComponent();
            dieListBox.AddHandler(ListBox.MouseDownEvent, new MouseButtonEventHandler(ListBox_MouseDown), true);
        }

        private void ListBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // MessageBox.Show("ausgewählt wurde " + (dieListBox.SelectedItem as Kram).bezeichnung);   // welches Item geklickt wurde
                                                                                                    // dieListBox.SelectedItem.ToString() sagt halt nur Kram
            Kram wunsch = dieListBox.SelectedItem as Kram;
            DataObject data = new DataObject(wunsch); // oder (typeof(Kram), wunsch), statt Kram wunsch = dieListBox.SelectedItem as Kram;
            DragDrop.DoDragDrop(dieListBox, data, DragDropEffects.Copy);
        }

        private void Canvas_DragEnter(object sender, DragEventArgs e)   //wird beim "Betreten" des Feldes wunschzettel aktiv
        {
            wunschzettel.Background = Brushes.Magenta;
        }

        private void Canvas_DragLeave(object sender, DragEventArgs e)   //wird beim "Verlassen" des Feldes wunschzettel aktiv
        {
            wunschzettel.Background = Brushes.LightSeaGreen;
        }

        private void wunschzettel_DragOver(object sender, DragEventArgs e)     //wird konstant ausgeführt, solange der Mauszeiger darüber ist
        {
            int elemente = wunschzettel.Children.Count;
            Kram kopie = (Kram)e.Data.GetData(typeof(Kram));
            //   Canvas wunschliste = e.Source as Canvas;
            Point p = e.GetPosition(wunschzettel);
            label.Content = p.X.ToString() + " : " + p.Y.ToString();
            //   Ellipse el = new Ellipse { Width = 5, Height = 5, Fill = Brushes.Black };
            ContentControl cc = new ContentControl();
            cc.Content = kopie;
            Canvas.SetLeft(cc, p.X);
            Canvas.SetTop(cc, p.Y);
            wunschzettel.Children.Add(cc);
            if (wunschzettel.Children.Count > 1)
                wunschzettel.Children.RemoveAt(elemente - 1);
        }

        private void wunschzettel_Drop(object sender, DragEventArgs e)
        {
            // MessageBox.Show(sender.ToString());     // zeigt an, wer hier der sender ist
            Kram kopie = (Kram)e.Data.GetData(typeof(Kram));
            Canvas canvas = e.Source as Canvas;
            Point p = e.GetPosition(wunschzettel);          // hier sehe ich, wo die Maus beim Drop steht

            ContentControl cc = new ContentControl();
            cc.Content = kopie;                       // hier mache ich mir für den Canvas eine Kopie mit dem Inhalt dessen, was beim Drag&Drop mitgeschickt wurde 

            Canvas.SetLeft(cc, p.X);                  // hier setze ich die Kopie auf den X-Anteil (Koordinate) von p
            Canvas.SetTop(cc, p.Y);
            wunschzettel.Children.Add(cc);            // hier wird der kopierte Inhalt hinzugefügt

            summe += kopie.preis;                     // zählt den Gesamtpreis zusammen  
            label.Content = summe.ToString();
        }
    }
}
