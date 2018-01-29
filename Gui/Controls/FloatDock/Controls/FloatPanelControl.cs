using Instrument.Gui.Controls.FloatDock.Interfaces;
using Instrument.Gui.Controls.FloatDock.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Instrument.Gui.Controls.FloatDock.Controls
{
    public class FloatPanelControl : Grid
    {
        #region Constructor

        public FloatPanelControl(LayoutPanel model)
        {
            _model = model;
        }

        #endregion

        #region Model

        LayoutPanel _model;
        public ILayoutElement Model
        {
            get { return _model; }
        }

        #endregion


    }
}
