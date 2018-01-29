using System.Collections.Generic;

namespace Instrument.Gui.Controls.FloatDock.Interfaces
{
    public interface ILayoutContainer : ILayoutElement
    {
        IEnumerable<ILayoutElement> Children { get; }
        void RemoveChild(ILayoutElement element);
        void ReplaceChild(ILayoutElement oldElement, ILayoutElement newElement);
        int ChildrenCount { get; }
    }
}
