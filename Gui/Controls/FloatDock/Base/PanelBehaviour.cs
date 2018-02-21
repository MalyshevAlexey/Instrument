using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Controls;
using System.Windows;

namespace Instrument.Gui.Controls.FloatDock.Base
{
    public abstract class PanelBehaviour : IPanelBehaviour
    {
        public ILayoutControl Control { get; private set; } = null;
        public LayoutElement Model { get; private set; } = null;

        public PanelBehaviour()
        {
        }

        public void Initialize(ILayoutControl control)
        {
            Control = control;
            Model = control.Model as LayoutElement;
        }

        public abstract Size ArrangeOverride(Size finalSize);

        public abstract Size MeasureOverride(Size availableSize);

        public abstract void UpdateChildren();
    }
}
