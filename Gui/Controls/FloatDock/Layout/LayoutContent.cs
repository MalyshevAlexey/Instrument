using Instrument.Gui.Controls.FloatDock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Instrument.Gui.Controls.FloatDock.Layout
{
    [ContentProperty("Content")]
    public abstract class LayoutContent : LayoutElement
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
                    RaisePropertyChanging("Content");
                    _content = value;
                    RaisePropertyChanged("Content");
                }
            }
        }

        #endregion
    }
}
