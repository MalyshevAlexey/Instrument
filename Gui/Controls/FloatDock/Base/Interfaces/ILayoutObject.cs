using System.ComponentModel;

namespace Instrument.Gui.Controls.FloatDock.Base.Interfaces
{
    public interface ILayoutObject : INotifyPropertyChanged, INotifyPropertyChanging
    {
        ILayoutContainer Parent { get; set; }
        ILayoutRoot Root { get; }
        string Tag { get; set; }
    }
}
