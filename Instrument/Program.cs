using Instrument.Gui.FloatingGui;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Instrument
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application app = new Application();
            app.Run(new MainWindow());
        }
    }
}
