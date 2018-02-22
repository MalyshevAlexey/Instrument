using Instrument.Gui.Controls.FloatDock.Base;
using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Instrument.Gui.Controls.FloatDock.Layout
{
    [ContentProperty(nameof(Children))]
    public class TestPanel : LayoutElement, ILayoutAttachable
    {
        public TestPanel()
        {
        }

        #region DockProperty

        public static readonly DependencyProperty DockProperty =
                DependencyProperty.RegisterAttached(nameof(Dock), typeof(Dock), typeof(TestPanel),
                        new FrameworkPropertyMetadata(Dock.Center, OnDockChanged), IsValidDock);

        public static Dock GetDock(LayoutObject element)
        {
            if (element == null) { throw new ArgumentNullException("element"); }
            return (Dock)element.GetValue(DockProperty);
        }

        public static void SetDock(LayoutObject element, Dock dock)
        {
            if (element == null) { throw new ArgumentNullException("element"); }
            element.SetValue(DockProperty, dock);
        }

        internal static bool IsValidDock(object o)
        {
            Dock dock = (Dock)o;
            return (dock == Dock.Center || dock == Dock.Left || dock == Dock.Top || dock == Dock.Right || dock == Dock.Bottom
                || dock == Dock.HideLeft || dock == Dock.HideTop || dock == Dock.HideRight || dock == Dock.HideBottom);
        }

        private static void OnDockChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        #endregion
    }
}
