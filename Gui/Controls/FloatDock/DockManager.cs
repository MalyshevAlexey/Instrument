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
                newLayout.Parent = LayoutRoot;
                LayoutRoot.RootPanel = newLayout;
                if (RootPanelControl == null)
                    RootPanelControl = UIElementFromModel(LayoutRoot.RootPanel) as FloatPanelControl;
            }
        }

        #endregion

        #region RootPanelControl

        /// <summary>
        /// RootPanelControl Dependency Property
        /// </summary>
        public static readonly DependencyProperty RootPanelControlProperty =
            DependencyProperty.Register(nameof(RootPanelControl), typeof(FloatPanelControl), typeof(DockManager),
                new FrameworkPropertyMetadata(null, OnRootPanelControlChanged));

        /// <summary>
        /// Gets or sets the RootPanelControl property.  This dependency property 
        /// indicates the layout panel control which is attached to the Layout.Root property.
        /// </summary>
        public FloatPanelControl RootPanelControl
        {
            get { return (FloatPanelControl)GetValue(RootPanelControlProperty); }
            set { SetValue(RootPanelControlProperty, value); }
        }

        /// <summary>
        /// Handles changes to the RootPanelControl property.
        /// </summary>
        private static void OnRootPanelControlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DockManager)d).OnRootPanelControlChanged(e.OldValue as FloatPanelControl, e.NewValue as FloatPanelControl);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the RootPanelControl property.
        /// </summary>
        protected virtual void OnRootPanelControlChanged(FloatPanelControl oldLayout, FloatPanelControl newLayout)
        {
            
        }

        #endregion

        private UIElement UIElementFromModel(ILayoutContainer model)
        {
            if (model is LayoutPanel)
                return new FloatPanelControl(model as LayoutPanel);

            return null;
        }

        protected override IEnumerator LogicalChildren
        {
            get
            {
                if (RootPanelControl != null)
                    yield return RootPanelControl;
            }
        }

        
    }
}
