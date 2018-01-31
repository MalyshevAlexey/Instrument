using Instrument.Gui.Controls.FloatDock.Controls;
using Instrument.Gui.Controls.FloatDock.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Instrument.Gui.Controls.FloatDock.Interfaces
{
    public interface ILayoutRoot : ILayoutContainer
    {
        DockManager Manager { get; }
        ILayoutGroup RootPanel { get; }
        ILayoutControl RootPanelControl { get; }
        void OnLayoutRootPanelChanged(ILayoutGroup oldLayout, ILayoutGroup newLayout);
    }
}
