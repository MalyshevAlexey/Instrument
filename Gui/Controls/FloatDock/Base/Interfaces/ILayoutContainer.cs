using System;
using System.Collections.Generic;

namespace Instrument.Gui.Controls.FloatDock.Base.Interfaces
{
    public interface ILayoutContainer : ILayoutObject
    {
        IEnumerable<ILayoutObject> Children { get; }
        int ChildrenCount { get; }
        void RemoveChild(ILayoutObject element);
        void ReplaceChild(ILayoutObject oldElement, ILayoutObject newElement);
    }
}
