using Instrument.Gui.Controls.FloatDock.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Gui.Controls.FloatDock.Themes
{
    public class GenericTheme : Theme
    {
        public override Uri GetThemeUri()
        {
            return new Uri("/FloatDock;component/Themes/generic.xaml", UriKind.Relative);
        }
    }
}
