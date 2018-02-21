using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Instrument.Gui.Controls.FloatDock.Base
{
    public abstract class Theme : DependencyObject
    {
        public abstract Uri GetThemeUri();
    }
}
