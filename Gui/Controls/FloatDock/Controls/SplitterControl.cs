using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Instrument.Gui.Controls.FloatDock.Controls
{
    public class SplitterControl : Control
    {
        static SplitterControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitterControl), new FrameworkPropertyMetadata(typeof(SplitterControl)));
        }
    }
}
