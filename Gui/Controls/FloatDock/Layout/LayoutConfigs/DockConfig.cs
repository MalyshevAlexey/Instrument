using Instrument.Gui.Controls.FloatDock.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Gui.Controls.FloatDock.Layout.LayoutConfigs
{
    public class DockConfig : ElementConfig
    {
        public override string Type => "Dock";

        public DockConfig()
        {
        }

        public string Test
        {
            get;
            set;
        }
    }
}
