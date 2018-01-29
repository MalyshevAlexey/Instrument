using Instrument.Gui.Controls.FloatDock.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Instrument.Gui.Controls.FloatDock.Layout
{
    [ContentProperty("Children")]
    public class LayoutPanel : LayoutGroup<UIElement>, ILayoutContainer
    {
        public LayoutPanel()
        {
            for (int i = 0; i < 3; i++)
            {
                Button btn = new Button() { Content = "Button " + i };
                Children.Add(btn);
            }
        }
    }
}
