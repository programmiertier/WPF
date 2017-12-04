using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunschliste_WpfApplication
{
    class Kram
    {
        private string _bezeichnung;
        private double _preis;

        public string bezeichnung { get { return _bezeichnung; } set { _bezeichnung = value; } }
        public double preis { get { return _preis; } set { _preis = value; } }

    }
}
