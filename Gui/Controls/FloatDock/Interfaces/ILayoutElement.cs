using System.ComponentModel;

namespace Instrument.Gui.Controls.FloatDock.Interfaces
{
    public interface ILayoutElement : INotifyPropertyChanged, INotifyPropertyChanging
    {
        ILayoutContainer Parent { get; set; }
        ILayoutRoot Root { get; }
    }
}
