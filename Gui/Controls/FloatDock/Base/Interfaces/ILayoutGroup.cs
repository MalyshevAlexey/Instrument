using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Instrument.Gui.Controls.FloatDock.Base.Interfaces
{
    public interface ILayoutGroup : ILayoutContainer
    {
        void InsertChildAt(int index, ILayoutObject element);
        void MoveChild(int oldIndex, int newIndex);
        int IndexOfChild(ILayoutObject element);
        void RemoveChildAt(int index);
        void ReplaceChildAt(int index, ILayoutObject element);
        event EventHandler ChildrenCollectionChanged;
    }
}
