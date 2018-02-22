using Instrument.Gui.Controls.FloatDock.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Instrument.Gui.Controls.FloatDock.Controls.Behaviours
{
    class StyledPanelBehaviour : PanelBehaviour
    {
        public override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in Control.Children)
            {
                child.Measure(availableSize);
            }
            return new Size(availableSize.Width, 300);
            //return availableSize;
        }

        public override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement child in Control.Children)
            {
                child.Arrange(new Rect(finalSize));
            }
            return finalSize;
        }

        public override void UpdateChildren()
        {
            
        }
    }
}
