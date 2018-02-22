using Instrument.Gui.Controls.FloatDock.Layout;

namespace Instrument.Gui.Controls.FloatDock.Base.Interfaces
{
    public interface ILayoutElement : ILayoutGroup, ILayoutPositionable, ILayoutConfigurable, ILayoutOrientable, ILayoutResizable, ILayoutStyleable
    {
        Type Type { get; }
    }
}
