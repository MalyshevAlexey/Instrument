using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        GridLength DockWidth { get; set; }
        GridLength DockHeight { get; set; }
        double DockMinWidth { get; set; }
        double DockMinHeight { get; set; }
        double ActualWidth { get; set; }
        double ActualHeight { get; set; }
    }
}
