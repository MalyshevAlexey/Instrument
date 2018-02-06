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
    class DocumentControl : Control, ILayoutControl
    {
        #region Constructor

        public DocumentControl(LayoutDocument model)
        {
            _model = model;
        }

        #endregion

        #region Model

        LayoutDocument _model;
        public ILayoutElement Model
        {
            get { return _model; }
        }

        #endregion

        public void InitContent(object sender, EventArgs e) { }
    }
}
