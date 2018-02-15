using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Instrument.Gui.Controls.FloatDock.Base.Interfaces
{
    public interface ILayoutPositionable
    {
        GridLength Width { get; set; }
        GridLength Height { get; set; }
        double MinWidth { get; set; }
        double MinHeight { get; set; }
        double ActualWidth { get; set; }
        double ActualHeight { get; set; }
    }
}
