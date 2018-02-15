using Instrument.Gui.Controls.FloatDock.Base;
using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Controls;
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
    public enum Dock
    {
        Center,
        Left,
        Top,
        Right,
        Bottom,
        HideLeft,
        HideTop,
        HideRight,
        HideBottom
    }

    public enum Type
    {
        Root,
        Dock,
        Grid,
        Tab,
    }

    [ContentProperty(nameof(Children))]
    public class LayoutPanel : LayoutGroup<ILayoutElement>
    {
        public LayoutPanel()
        {
        }

        #region DockProperty

        public static readonly DependencyProperty DockProperty =
                DependencyProperty.RegisterAttached(nameof(Dock), typeof(Dock), typeof(LayoutPanel),
                        new FrameworkPropertyMetadata(Dock.Center, OnDockChanged), IsValidDock);

        public static Dock GetDock(LayoutElement element)
        {
            if (element == null) { throw new ArgumentNullException("element"); }
            return (Dock)element.GetValue(DockProperty);
        }

        public static void SetDock(LayoutElement element, Dock dock)
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

        #region TypeProperty

        public Type Type
        {
            get { return (Type)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register(nameof(Type), typeof(Type), typeof(LayoutPanel),
                new FrameworkPropertyMetadata(Type.Dock, OnTypeChanged));

        private static void OnTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LayoutPanel)d).RaisePropertyChanged(nameof(Type));
        }

        #endregion
    }
}
