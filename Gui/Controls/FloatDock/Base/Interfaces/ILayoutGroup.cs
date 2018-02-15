using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Instrument.Gui.Controls.FloatDock.Base.Interfaces
{
    public interface ILayoutGroup : ILayoutContainer, ILayoutPositionable, ILayoutConfigurable
    {
        void InsertChildAt(int index, ILayoutElement element);
        void MoveChild(int oldIndex, int newIndex);
        int IndexOfChild(ILayoutElement element);
        void RemoveChildAt(int index);
        void ReplaceChildAt(int index, ILayoutElement element);
        event EventHandler ChildrenCollectionChanged;
        Orientation Orientation { get; }
    }
}
