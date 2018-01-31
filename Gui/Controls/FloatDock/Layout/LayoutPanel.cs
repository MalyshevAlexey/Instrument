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
    public enum Dock
    {
        /// <summary>
        /// Position this child in the center of the remaining space. 
        /// </summary> 
        Center,

        /// <summary>
        /// Position this child at the left of the remaining space. 
        /// </summary>
        Left,

        /// <summary> 
        /// Position this child at the top of the remaining space.
        /// </summary> 
        Top,

        /// <summary> 
        /// Position this child at the right of the remaining space.
        /// </summary>
        Right,

        /// <summary>
        /// Position this child at the bottom of the remaining space. 
        /// </summary> 
        Bottom,
    }

    [ContentProperty("Children")]
    public class LayoutPanel : LayoutGroup<ILayoutElement>
    {
        public LayoutPanel()
        {
        }

        #region DockProperty

        public static readonly DependencyProperty DockProperty =
                DependencyProperty.RegisterAttached(nameof(Dock), typeof(Dock), typeof(LayoutPanel),
                        new FrameworkPropertyMetadata(Dock.Center, OnDockChanged), IsValidDock);

        public static Dock GetDock(ILayoutElement element)
        {
            if (element == null) { throw new ArgumentNullException("element"); }
            return (Dock)element.GetValue(DockProperty);
        }

        public static void SetDock(ILayoutElement element, Dock dock)
        {
            if (element == null) { throw new ArgumentNullException("element"); }
            element.SetValue(DockProperty, dock);
        }

        internal static bool IsValidDock(object o)
        {
            Dock dock = (Dock)o;
            return (dock == Dock.Center || dock == Dock.Left || dock == Dock.Top || dock == Dock.Right || dock == Dock.Bottom);
        }

        private static void OnDockChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion


    }
}
