using Machikoro.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Machikoro.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Juego j = new Juego(new string[] { "Jorge", "Maider"});

            var pto = j.Jugadores[0].PuntosDeInteres;
            var x = pto[0].Coste;
        }
    }
}
