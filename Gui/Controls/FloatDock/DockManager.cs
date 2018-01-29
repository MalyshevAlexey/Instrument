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
    }
}
