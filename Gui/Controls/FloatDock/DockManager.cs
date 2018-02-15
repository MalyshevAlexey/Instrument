using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Controls;
using Instrument.Gui.Controls.FloatDock.Controls.Behaviours;
using Instrument.Gui.Controls.FloatDock.Layout;
using Instrument.Gui.Controls.FloatDock.Layout.LayoutEventArgs;
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

        public ILayoutRoot LayoutRoot
        {
            get { return (ILayoutRoot)GetValue(LayoutRootProperty); }
            set { SetValue(LayoutRootProperty, value); }
        }

        public static readonly DependencyProperty LayoutRootProperty =
            DependencyProperty.Register(nameof(LayoutRoot), typeof(ILayoutRoot), typeof(DockManager),
                new FrameworkPropertyMetadata(null, OnLayoutRootChanged));

        private static void OnLayoutRootChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DockManager)d).OnLayoutRootChanged(e.OldValue as ILayoutGroup, e.NewValue as ILayoutGroup);
        }

        public virtual void OnLayoutRootChanged(ILayoutGroup oldLayout, ILayoutGroup newLayout)
        {
        }

        #endregion

        #region LayoutRootPanel

        public ILayoutGroup LayoutRootPanel
        {
            get { return (ILayoutGroup)GetValue(LayoutRootPanelProperty); }
            set { SetValue(LayoutRootPanelProperty, value); }
        }

        public static readonly DependencyProperty LayoutRootPanelProperty =
            DependencyProperty.Register(nameof(LayoutRootPanel), typeof(ILayoutGroup), typeof(DockManager),
                new FrameworkPropertyMetadata(null, OnLayoutRootPanelChanged));

        private static void OnLayoutRootPanelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DockManager)d).OnLayoutRootPanelChanged(e.OldValue as ILayoutGroup, e.NewValue as ILayoutGroup);
        }

        public virtual void OnLayoutRootPanelChanged(ILayoutGroup oldLayout, ILayoutGroup newLayout)
        {
            if (oldLayout != null)
            {

            }
            if (newLayout != null)
            {
                LayoutRootPanel.Parent = LayoutRoot;
                LayoutRootPanelChanged?.Invoke(this, EventArgs.Empty);
                if (RootPanelControl == null)
                    RootPanelControl = UIElementFromModel(LayoutRootPanel) as ILayoutControl;
            }
        }

        public event EventHandler LayoutRootPanelChanged;

        #endregion

        #region RootPanelControl

        /// <summary>
        /// RootPanelControl Dependency Property
        /// </summary>
        public static readonly DependencyProperty RootPanelControlProperty =
            DependencyProperty.Register(nameof(RootPanelControl), typeof(ILayoutControl), typeof(DockManager),
                new FrameworkPropertyMetadata(null, OnRootPanelControlChanged));

        /// <summary>
        /// Gets or sets the RootPanelControl property.  This dependency property 
        /// indicates the layout panel control which is attached to the Layout.Root property.
        /// </summary>
        public ILayoutControl RootPanelControl
        {
            get { return (ILayoutControl)GetValue(RootPanelControlProperty); }
            set { SetValue(RootPanelControlProperty, value); }
        }

        /// <summary>
        /// Handles changes to the RootPanelControl property.
        /// </summary>
        private static void OnRootPanelControlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DockManager)d).OnRootPanelControlChanged(e.OldValue as ILayoutControl, e.NewValue as ILayoutControl);
        }

        public virtual void OnRootPanelControlChanged(ILayoutControl oldControl, ILayoutControl newControl)
        {
            if (oldControl != null)
            {

            }
            if (newControl != null)
            {
                //newControl.InitContent(this, EventArgs.Empty);
            }
        }

        #endregion

        internal UIElement UIElementFromModel(ILayoutElement model)
        {
            if (model is LayoutPanel panel)
                return new PanelControl(panel);
            else if (model is LayoutDocument)
                return new DocumentControl(model as LayoutDocument);

            return null;
        }

        internal IPanelBehaviour BehaviourFromType(Panel control, LayoutPanel model)
        {
            if (model.Type == Layout.Type.Root)
                return new RootPanelBehaviour(control, model);
            if (model.Type == Layout.Type.Dock)
                return new DockPanelBehaviour(control, model);
            if (model.Type == Layout.Type.Grid)
                return null;
            if (model.Type == Layout.Type.Tab)
                return null;

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

        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            LogicalTreeDumper.Dump(this);
            VisualTreeDumper.Dump(this);
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }

        //#region FrameworkElement overrides

        //protected override Visual GetVisualChild(int index)
        //{
        //    if (index < 0 || index > 1)
        //        throw new ArgumentOutOfRangeException("index");

        //    return LayoutRoot.RootPanelControl as Visual;
        //}

        //protected override int VisualChildrenCount
        //{
        //    get { return 1; }
        //}

        //protected override Size MeasureOverride(Size availableSize)
        //{
        //    (LayoutRoot.RootPanelControl as UIElement).Measure(availableSize);
        //    return (LayoutRoot.RootPanelControl as UIElement).DesiredSize;
        //}

        //protected override Size ArrangeOverride(Size finalSize)
        //{
        //    (LayoutRoot.RootPanelControl as UIElement).Arrange(new Rect(finalSize));
        //    return finalSize;
        //}

        //#endregion
    }
}
