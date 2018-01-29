using System;
using System.Collections.Generic;

namespace Instrument.Gui.Controls.FloatDock.Interfaces
{
    public interface ILayoutContainer : ILayoutElement
    {
        IEnumerable<ILayoutElement> Children { get; }
        int ChildrenCount { get; }
    }
}
