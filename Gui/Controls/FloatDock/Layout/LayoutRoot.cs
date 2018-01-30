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
    internal class LayoutRoot : LayoutElement, ILayoutRoot
    {
        #region Variables

        public ILayoutContainer RootPanel { get; private set; }
        public UIElement RootPanelControl { get; private set; }

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
                RootPanel = (LayoutPanel)newElement;
        }

        #endregion

        public virtual void OnLayoutRootPanelChanged(LayoutPanel oldLayout, LayoutPanel newLayout)
        {
            if (oldLayout != null)
            {

            }
            if (newLayout != null)
            {
                Parent = this;
                RootPanel = newLayout;
                if (RootPanelControl == null)
                    Manager.RootPanelControl = Manager.UIElementFromModel(RootPanel) as FloatPanelControl;
            }
        }

        public virtual void OnRootPanelControlChanged(FloatPanelControl oldLayout, FloatPanelControl newLayout)
        {

        }

        
    }
}
