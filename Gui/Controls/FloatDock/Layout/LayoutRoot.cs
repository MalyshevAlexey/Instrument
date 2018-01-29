using Instrument.Gui.Controls.FloatDock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Gui.Controls.FloatDock.Layout
{
    internal class LayoutRoot : LayoutElement, ILayoutRoot
    {
        #region Variables

        public ILayoutContainer RootPanel { get; set; }

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
        }

        public void ReplaceChild(ILayoutElement oldElement, ILayoutElement newElement)
        {
        }

        #endregion
    }
}
