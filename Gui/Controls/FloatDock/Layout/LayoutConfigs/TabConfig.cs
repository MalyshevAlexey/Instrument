using Instrument.Gui.Controls.FloatDock.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Gui.Controls.FloatDock.Layout.LayoutConfigs
{
    public class TabConfig : ElementConfig
    {
        public override Type Type => Type.Tab;

        public string TabPosition { get; set; }
    }
}
