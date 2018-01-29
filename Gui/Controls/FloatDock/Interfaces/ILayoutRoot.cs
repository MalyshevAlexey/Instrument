using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Gui.Controls.FloatDock.Interfaces
{
    public interface ILayoutRoot : ILayoutContainer
    {
        DockManager Manager { get; }
        ILayoutContainer RootPanel { get; set; }
    }
}
