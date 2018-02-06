using Instrument.Gui.Controls.FloatDock.Controls;
using Instrument.Gui.Controls.FloatDock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Instrument.Gui.Controls.FloatDock.Layout
{
    public class LayoutRoot : LayoutElement, ILayoutRoot
    {
        #region Variables

        public ILayoutCollection RootPanel { get; private set; }

        #endregion

        #region Constructor

        public LayoutRoot(DockManager manager)
        {
            Manager = manager;
            Parent = this;
        }

        #endregion

        #region Manager

        private DockManager _manager = null;
        public DockManager Manager
        {
            get { return _manager; }
            internal set
            {
                if (_manager != value)
                {
                    RaisePropertyChanging(nameof(Manager));
                    _manager = value;
                    RaisePropertyChanged(nameof(Manager));
                }
            }
        }

        #endregion

        #region Children

        public IEnumerable<ILayoutElement> Children
        {
            get
            {
                if (RootPanel is ILayoutContainer)
                    yield return RootPanel;
            }
        }

        public int ChildrenCount => 1;

        public void RemoveChild(ILayoutElement element)
        {
            if (element == RootPanel)
                RootPanel = null;
        }

        public void ReplaceChild(ILayoutElement oldElement, ILayoutElement newElement)
        {
            if (oldElement == RootPanel)
                RootPanel = (ILayoutCollection)newElement;
        }

        #endregion

        public virtual void OnLayoutRootPanelChanged(ILayoutCollection oldLayout, ILayoutCollection newLayout)
        {
            if (oldLayout != null)
            {

            }
            if (newLayout != null)
            {
                newLayout.Parent = this;
                RootPanel = newLayout;
                if (RootPanelControl == null)
                    RootPanelControl = Manager.UIElementFromModel(RootPanel) as ILayoutControl;
                (RootPanelControl as FloatPanelControl).Children.Clear();
                RecursiveBuildVisualTree(RootPanel, RootPanelControl as UIElement);
                //RootPanel.ChildrenCollectionChanged += new EventHandler(RootPanelControl.InitContent);
            }
        }

        private void RecursiveBuildVisualTree(ILayoutContainer current, UIElement control)
        {
            if (current != null)
                foreach (ILayoutElement logicalChild in current.Children)
                {
                    if (logicalChild is LayoutPanel)
                    {
                        //Console.WriteLine((logicalChild as LayoutPanel).Tag);
                        UIElement nextControl = Manager.UIElementFromModel(logicalChild);
                        (control as Panel).Children.Add(nextControl);
                        RecursiveBuildVisualTree(logicalChild as ILayoutContainer, nextControl);
                    }
                    else
                    {
                        //Console.WriteLine("Document");
                        (control as Panel).Children.Add(Manager.UIElementFromModel(logicalChild));
                    }
                }
        }

        #region RootPanelControl

        /// <summary>
        /// RootPanelControl Dependency Property
        /// </summary>
        public static readonly DependencyProperty RootPanelControlProperty =
            DependencyProperty.Register(nameof(RootPanelControl), typeof(ILayoutControl), typeof(LayoutRoot),
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
            ((LayoutRoot)d).OnRootPanelControlChanged(e.OldValue as ILayoutControl, e.NewValue as ILayoutControl);
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
    }
}
