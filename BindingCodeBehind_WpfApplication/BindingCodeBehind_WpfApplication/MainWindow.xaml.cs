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

namespace BindingCodeBehind_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string myValue;
        public string MyValue
        { get { return myValue; } set { myValue = value; textBox.Text = value; } }

        public static int myMwst;
        public int MyMwST
        {
            get { return myMwst; } set { myMwst = value; textBox.Text = value.ToString(); }
        }

        public MainWindow()
        {
            // string myValue = new string('*', 5);
            // MessageBox.Show(myValue.Length.ToString());

            InitializeComponent();
            MyValue = "ich bin der neue Value";
            MessageBox.Show(" ");
            MyValue = "ich bin der nächste Value";
            MyMwST = 22;
        }
    }
}
