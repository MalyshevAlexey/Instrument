using Instrument.Gui.Controls.FloatDock.Interfaces;
using Instrument.Gui.Controls.FloatDock.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Instrument.Gui.Controls.FloatDock
{
    public class DockManager : Control
    {
        #region Variables

        ILayoutRoot LayoutRoot;

        #endregion

        #region Constructor

        static DockManager()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockManager), new FrameworkPropertyMetadata(typeof(DockManager)));
        }

        public DockManager()
        {
            LayoutRoot = new LayoutRoot(this);
        }

        #endregion

        #region LayoutRootPanel

        public static readonly DependencyProperty LayoutRootPanelProperty =
            DependencyProperty.Register(nameof(LayoutRootPanel), typeof(LayoutPanel), typeof(DockManager),
                new FrameworkPropertyMetadata(null, OnLayoutRootPanelChanged));

        public LayoutPanel LayoutRootPanel
        {
            get { return (LayoutPanel)GetValue(LayoutRootPanelProperty); }
            set { SetValue(LayoutRootPanelProperty, value); }
        }

        private static void OnLayoutRootPanelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DockManager)d).OnLayoutRootPanelChanged(e.OldValue as LayoutPanel, e.NewValue as LayoutPanel);
        }

        private void OnLayoutRootPanelChanged(LayoutPanel oldLayout, LayoutPanel newLayout)
        {
            if (oldLayout != null)
            {

            }
            if (newLayout != null)
            {
                
            }
        }

        #endregion
    }
}
