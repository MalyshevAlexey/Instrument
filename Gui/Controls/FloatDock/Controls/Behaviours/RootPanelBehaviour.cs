using Instrument.Gui.Controls.FloatDock.Base;
using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Instrument.Gui.Controls.FloatDock.Controls.Behaviours
{
    public class RootPanelBehaviour : IPanelBehaviour
    {
        private Panel _panel = null;
        private ILayoutGroup _model = null;
        
        public RootPanelBehaviour(Panel panel, ILayoutGroup model)
        {
            _panel = panel;
            _model = model;
        }

        public Size MeasureOverride(Size availableSize)
        {
            double availableWidth = availableSize.Width;
            double availableHeight = availableSize.Height;
            List<UIElement> stars = new List<UIElement>();
            foreach (UIElement child in _panel.Children)
            {
                double width = 0;
                double height = 0;
                ILayoutGroup model = (child as ILayoutControl).Model as ILayoutGroup;
                
                if (_model.Orientation == Orientation.Horizontal)
                {
                    if (model.Width.IsAbsolute)
                    {
                        width = model.Width.Value;
                        height = availableSize.Height;
                        availableWidth -= width;
                    }
                    else if (model.Width.IsStar)
                    {
                        stars.Add(child);
                        continue;
                    }
                }
                else if (_model.Orientation == Orientation.Vertical)
                {
                    if (model.Height.IsAbsolute)
                    {
                        width = availableSize.Width;
                        height = model.Height.Value;
                        availableHeight -= height;
                    }
                    else if (model.Height.IsStar)
                    {
                        stars.Add(child);
                        continue;
                    }
                }
                child.Measure(new Size(width, height));
            }
            foreach (UIElement child in stars)
            {
                double width = 0;
                double height = 0;
                if (_model.Orientation == Orientation.Horizontal)
                {
                    width = availableWidth / stars.Count;
                    height = availableSize.Height;
                }
                else if (_model.Orientation == Orientation.Vertical)
                {
                    width = availableSize.Width;
                    height = availableHeight / stars.Count;
                }
                child.Measure(new Size(width, height));
            }

            
            //double width = 0;
            //double height = 0;
            //if (_model.Orientation == Orientation.Horizontal)
            //{
            //    width = availableSize.Width / _panel.Children.Count;
            //    height = availableSize.Height;
            //}
            //else if (_model.Orientation == Orientation.Vertical)
            //{
            //    width = availableSize.Width;
            //    height = availableSize.Height / _panel.Children.Count;
            //}
            //foreach (var item in _panel.Children)
            //{
            //    (item as UIElement).Measure(new Size(width, height));
            //}
            return availableSize;
        }

        public Size ArrangeOverride(Size finalSize)
        {
            if (_model.Orientation == Orientation.Horizontal)
            {
                double x = 0;
                foreach (UIElement child in _panel.Children)
                {
                    child.Arrange(new Rect(new Point(x, 0), child.DesiredSize));
                    x += child.DesiredSize.Width;
                }
            }
            else if (_model.Orientation == Orientation.Vertical)
            {
                double y = 0;
                foreach (UIElement child in _panel.Children)
                {
                    child.Arrange(new Rect(new Point(0, y), child.DesiredSize));
                    y += child.DesiredSize.Height;
                }
            }
            return finalSize;
        }
    }
}
