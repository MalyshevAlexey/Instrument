using Instrument.Gui.Controls.FloatDock.Base;
using Instrument.Gui.Controls.FloatDock.Controls;
using Instrument.Gui.Controls.FloatDock.Layout;
using Instrument.Gui.Controls.FloatDock.Layout.LayoutEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Instrument.Gui.Controls.FloatDock.Base.Interfaces
{
    public interface ILayoutRoot : ILayoutContainer
    {
        DockManager Manager { get; }
    }
}
