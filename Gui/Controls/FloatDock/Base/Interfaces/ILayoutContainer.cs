using System;
using System.Collections.Generic;

namespace Instrument.Gui.Controls.FloatDock.Base.Interfaces
{
    public interface ILayoutContainer : ILayoutElement
    {
        IEnumerable<ILayoutElement> Children { get; }
        int ChildrenCount { get; }
        void RemoveChild(ILayoutElement element);
        void ReplaceChild(ILayoutElement oldElement, ILayoutElement newElement);
    }
}
