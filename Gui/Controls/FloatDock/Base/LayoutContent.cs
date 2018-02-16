using Instrument.Gui.Controls.FloatDock.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Instrument.Gui.Controls.FloatDock.Base
{
    [ContentProperty(nameof(Content))]
    public abstract class LayoutContent : LayoutObject
    {
        #region Content

        private object _content = null;
        public object Content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    RaisePropertyChanging(nameof(Content));
                    _content = value;
                    RaisePropertyChanged(nameof(Content));
                }
            }
        }

        #endregion
    }
}
