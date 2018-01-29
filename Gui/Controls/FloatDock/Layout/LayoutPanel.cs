using Instrument.Gui.Controls.FloatDock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Gui.Controls.FloatDock.Layout
{
    public class LayoutPanel : LayoutElement, ILayoutContainer
    {
        public IEnumerable<ILayoutElement> Children => throw new NotImplementedException();

        public int ChildrenCount => throw new NotImplementedException();

        public void RemoveChild(ILayoutElement element)
        {
            throw new NotImplementedException();
        }

        public void ReplaceChild(ILayoutElement oldElement, ILayoutElement newElement)
        {
            throw new NotImplementedException();
        }
    }
}
