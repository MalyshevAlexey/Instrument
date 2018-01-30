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
        ILayoutContainer RootPanel { get; }
        UIElement RootPanelControl { get; }
        void OnLayoutRootPanelChanged(LayoutPanel oldLayout, LayoutPanel newLayout);
        void OnRootPanelControlChanged(FloatPanelControl oldControl, FloatPanelControl newControl);
    }
}
