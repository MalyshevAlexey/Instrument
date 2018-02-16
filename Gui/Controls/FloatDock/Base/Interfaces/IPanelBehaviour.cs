using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Instrument.Gui.Controls.FloatDock.Base.Interfaces
{
    public interface IPanelBehaviour : IBehaviour
    {
        Size MeasureOverride(Size availableSize);
        Size ArrangeOverride(Size finalSize);
        void UpdateChildren();
    }
}
