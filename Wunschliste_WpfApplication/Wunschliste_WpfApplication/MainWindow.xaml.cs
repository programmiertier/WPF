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
    }
}
