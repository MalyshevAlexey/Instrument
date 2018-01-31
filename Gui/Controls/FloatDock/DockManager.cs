using Instrument.Gui.Controls.FloatDock.Controls;
using Instrument.Gui.Controls.FloatDock.Interfaces;
using Instrument.Gui.Controls.FloatDock.Layout;
using Instrument.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Instrument.Gui.Controls.FloatDock
{
    [ContentProperty(nameof(LayoutRootPanel))]
    public class DockManager : Control
    {
        #region Variables

        

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

        #region LayoutRoot

        public static readonly DependencyProperty LayoutRootProperty =
            DependencyProperty.Register(nameof(LayoutRoot), typeof(ILayoutRoot), typeof(DockManager));

        public ILayoutRoot LayoutRoot
        {
            get { return (ILayoutRoot)GetValue(LayoutRootProperty); }
            set { SetValue(LayoutRootProperty, value); }
        }

        #endregion

        #region LayoutRootPanel

        public static readonly DependencyProperty LayoutRootPanelProperty =
            DependencyProperty.Register(nameof(LayoutRootPanel), typeof(ILayoutGroup), typeof(DockManager),
                new FrameworkPropertyMetadata(null, OnLayoutRootPanelChanged));

        public ILayoutGroup LayoutRootPanel
        {
            get { return (ILayoutGroup)GetValue(LayoutRootPanelProperty); }
            set { SetValue(LayoutRootPanelProperty, value); }
        }

        private static void OnLayoutRootPanelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DockManager)d).LayoutRoot.OnLayoutRootPanelChanged(e.OldValue as ILayoutGroup, e.NewValue as ILayoutGroup);
        }

        #endregion

        internal UIElement UIElementFromModel(ILayoutContainer model)
        {
            if (model is LayoutPanel)
                return new FloatPanelControl(model as LayoutPanel);

            return null;
        }

        protected override IEnumerator LogicalChildren
        {
            get
            {
                if (LayoutRoot.RootPanelControl != null)
                    yield return LayoutRoot.RootPanelControl;
            }
        }

        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            LogicalTreeDumper.Dump(this);
            VisualTreeDumper.Dump(this);
        }
    }
}
