using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Gui.Controls.FloatDock.Interfaces
{
    public interface ILayoutGroup : ILayoutContainer
    {
        void InsertChildAt(int index, ILayoutElement element);
        void MoveChild(int oldIndex, int newIndex);
        int IndexOfChild(ILayoutElement element);
        void RemoveChildAt(int index);
        void ReplaceChildAt(int index, ILayoutElement element);
        event EventHandler ChildrenCollectionChanged;
    }
}
