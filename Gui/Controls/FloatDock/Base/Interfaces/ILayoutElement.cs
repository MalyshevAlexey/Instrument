using Instrument.Gui.Controls.FloatDock.Base;
using Instrument.Gui.Controls.FloatDock.Layout;
using Instrument.Gui.Controls.FloatDock.Layout.LayoutConfigs;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace Instrument.Gui.Controls.FloatDock.Base.Interfaces
{
    public interface ILayoutElement : INotifyPropertyChanged, INotifyPropertyChanging
    {
        ILayoutContainer Parent { get; set; }
        ILayoutRoot Root { get; }
        object GetValue(DependencyProperty dp);
        void SetValue(DependencyProperty dp, object value);
        string Tag { get; set; }
        ElementConfig Config { get; set; }
    }
}
