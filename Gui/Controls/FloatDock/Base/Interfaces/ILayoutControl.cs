using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Instrument.Gui.Controls.FloatDock.Base.Interfaces
{
    public interface ILayoutControl
    {
        LayoutObject Model { get; }
        IEnumerable Children { get; }
    }
}
