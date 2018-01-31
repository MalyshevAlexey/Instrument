using System.ComponentModel;
using System.Windows;

namespace Instrument.Gui.Controls.FloatDock.Interfaces
{
    public interface ILayoutElement : INotifyPropertyChanged, INotifyPropertyChanging
    {
        ILayoutContainer Parent { get; set; }
        ILayoutRoot Root { get; }
        object GetValue(DependencyProperty dp);
        void SetValue(DependencyProperty dp, object value);
    }
}
