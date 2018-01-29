using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Gui.Controls.FloatDock.Interfaces
{
    public interface ILayoutPanelElement : ILayoutElement
    {
        bool IsVisible { get; }
    }
}
