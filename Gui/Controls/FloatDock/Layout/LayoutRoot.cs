using Instrument.Gui.Controls.FloatDock.Controls;
using Instrument.Gui.Controls.FloatDock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Instrument.Gui.Controls.FloatDock.Layout
{
    public class LayoutRoot : LayoutElement, ILayoutRoot
    {
        #region Variables

        public ILayoutGroup RootPanel { get; private set; }

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
                RootPanel = (ILayoutGroup)newElement;
        }

        #endregion

        public virtual void OnLayoutRootPanelChanged(ILayoutGroup oldLayout, ILayoutGroup newLayout)
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
                RootPanel.ChildrenCollectionChanged += new EventHandler(RootPanelControl.InitContent);
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
                newControl.InitContent(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
