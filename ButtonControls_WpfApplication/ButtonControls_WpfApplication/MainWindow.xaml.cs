﻿using System;
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

namespace ButtonControls_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            /*Button knopf2 = new Button();
            Grid.SetRow(knopf2, 1);
            Grid.SetColumn(knopf2, 0);
            gritty.Children.Add(knopf2);    */

           
        }

        // das ist der Eventhandler, eine Methode, eine Adresse, die vom Delegaten aufgerufen wird
        public void simple_gelickt(object sender, RoutedEventArgs e)    // EventArgs würde nur den Klick annehmen und nichts weiter machen
        {
            label_simple.Content = "Simple wurde geklickt";
        }

        public void toggle_geklickt(object sender, RoutedEventArgs e)
        {
            label_toggle.Content = "Toggle wurde geklickt";
            
        }

        public void toggle_checked(object sender, RoutedEventArgs e)
        {
            label_checked.Content = "Knopf ist aktiv";
            label_unchecked.Content = "";
            Image bildchen = new Image();
            bildchen.Source = new BitmapImage(new Uri("C:\\Users\\Zimmermann\\Desktop\\smiley.jpg"));
            togglebutton.Content = bildchen;
        }

        public void toggle_unchecked(object sender, RoutedEventArgs e)
        {
            label_unchecked.Content = "Knopf ist nicht aktiv";
            label_checked.Content = "";
            Image bildchen = new Image();
            bildchen.Source = new BitmapImage(new Uri("C:\\Users\\Zimmermann\\Desktop\\traurig.jpg"));
            togglebutton.Content = bildchen;
            
        }

        public void repeat_geklickt(object sender, RoutedEventArgs e)    // EventArgs würde nur den Klick annehmen und nichts weiter machen
        {
            label_repeat.Content = "Repeat wurde geklickt";
            
        }

        public void butt(object sender, RoutedEventArgs e)
        {
            togglebutton.Content = "ᕙ(⇀‸↼‶)ᕗ";
        }
    }
}
