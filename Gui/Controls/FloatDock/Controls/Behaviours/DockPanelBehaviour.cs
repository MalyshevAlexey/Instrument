using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Instrument.Gui.Controls.FloatDock.Controls.Behaviours
{
    class DockPanelBehaviour : IPanelBehaviour
    {
        private Panel _panel = null;
        private LayoutPanel _model = null;

        public DockPanelBehaviour(Panel panel, LayoutPanel model)
        {
            _panel = panel;
            _model = model;
        }

        public Size MeasureOverride(Size availableSize)
        {
            double availableWidth = availableSize.Width;
            double availableHeight = availableSize.Height;
            List<UIElement> docks = new List<UIElement>();
            List<UIElement> center = new List<UIElement>();
            foreach (UIElement child in _panel.Children.OfType<SplitterControl>())
            {
                child.Measure(availableSize);
            }
            foreach (UIElement child in _panel.Children.OfType<ILayoutControl>())
            {
                Layout.Dock dock = LayoutPanel.GetDock((child as ILayoutControl).Model);
                double width = 0;
                double height = 0;
                switch (dock)
                {
                    case Layout.Dock.HideRight:
                    case Layout.Dock.HideLeft:
                        width = 30;
                        height = availableSize.Height;
                        availableWidth -= width;
                        break;
                    case Layout.Dock.HideTop:
                    case Layout.Dock.HideBottom:
                        width = availableWidth;
                        height = 30;
                        availableHeight -= height;
                        break;
                    case Layout.Dock.Right:
                    case Layout.Dock.Left:
                    case Layout.Dock.Top:
                    case Layout.Dock.Bottom:
                        docks.Add(child);
                        continue;
                    case Layout.Dock.Center:
                        center.Add(child);
                        continue;
                }
                child.Measure(new Size(width, height));
            }
            foreach (UIElement child in docks)
            {
                Layout.Dock dock = LayoutPanel.GetDock((child as ILayoutControl).Model);
                double width = 0;
                double height = 0;
                switch (dock)
                {
                    case Layout.Dock.Top:
                    case Layout.Dock.Bottom:
                        width = availableWidth;
                        height = availableHeight / _panel.Children.Count;
                        availableHeight -= height;
                        break;
                    case Layout.Dock.Right:
                    case Layout.Dock.Left:
                        width = availableWidth / _panel.Children.Count;
                        height = availableHeight;
                        availableWidth -= width;
                        break;
                }
                child.Measure(new Size(width, height));
            }
            foreach (UIElement child in center)
            {
                double width = 0;
                double height = 0;
                
                if (_model.Orientation == Orientation.Horizontal)
                {
                    width = availableWidth / center.Count;
                    height = availableHeight;
                }
                else if (_model.Orientation == Orientation.Vertical)
                {
                    width = availableWidth;
                    height = availableHeight / center.Count;
                }
                child.Measure(new Size(width, height));
            }
            return availableSize;
        }

        public Size ArrangeOverride(Size finalSize)
        {
            double x = 0;
            double y = 0;
            double finalWidth = finalSize.Width;
            double finalHeight = finalSize.Height;
            List<UIElement> docks = new List<UIElement>();
            List<UIElement> center = new List<UIElement>();
            for (int i = 0; i < _panel.Children.Count; i++)
            {
                UIElement child = _panel.Children[i];
                Layout.Dock dock = LayoutPanel.GetDock((child as ILayoutControl).Model);
                switch (dock)
                {
                    case Layout.Dock.HideRight:
                        child.Arrange(new Rect(new Point(0, 0), child.DesiredSize));
                        x += child.DesiredSize.Width;
                        break;
                    case Layout.Dock.HideLeft:
                        child.Arrange(new Rect(new Point(finalSize.Width - child.DesiredSize.Width, 0), child.DesiredSize));
                        finalWidth -= child.DesiredSize.Width;
                        break;
                    case Layout.Dock.HideTop:
                        child.Arrange(new Rect(new Point(x, 0), child.DesiredSize));
                        y += child.DesiredSize.Height;
                        break;
                    case Layout.Dock.HideBottom:
                        child.Arrange(new Rect(new Point(x, finalSize.Height - child.DesiredSize.Height), child.DesiredSize));
                        finalHeight -= child.DesiredSize.Height;
                        break;
                    case Layout.Dock.Right:
                    case Layout.Dock.Left:
                    case Layout.Dock.Top:
                    case Layout.Dock.Bottom:
                        docks.Add(child);
                        if (i + 1 < _panel.Children.Count &&_panel.Children[i + 1] is SplitterControl)
                            docks.Add(_panel.Children[++i]);
                        continue;
                    case Layout.Dock.Center:
                        center.Add(child);
                        if (i + 1 < _panel.Children.Count && _panel.Children[i + 1] is SplitterControl)
                            center.Add(_panel.Children[++i]);
                        continue;
                }
            }
            for (int i = 0; i < docks.Count; i++)
            {
                UIElement child = docks[i];
                Layout.Dock dock = LayoutPanel.GetDock((child as ILayoutControl).Model);
                switch(dock)
                {
                    case Layout.Dock.Top:
                        child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
                        y += child.DesiredSize.Height;
                        finalHeight -= child.DesiredSize.Height;
                        if (i + 1 < docks.Count && docks[i + 1] is SplitterControl)
                        {
                            docks[++i].Arrange(new Rect(new Point(x, y), new Size(finalWidth, 5)));
                            y += 5;
                            finalHeight -= 5;
                        }
                        break;
                    case Layout.Dock.Bottom:
                        child.Arrange(new Rect(new Point(x, finalHeight - child.DesiredSize.Height), child.DesiredSize));
                        finalHeight -= child.DesiredSize.Height;
                        break;
                    case Layout.Dock.Right:
                        child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
                        x += child.DesiredSize.Width;
                        break;
                    case Layout.Dock.Left:
                        child.Arrange(new Rect(new Point(finalWidth - child.DesiredSize.Width, y), child.DesiredSize));
                        finalWidth -= child.DesiredSize.Width;
                        break;
                }
            }
            foreach (UIElement child in center)
            {
                child.Arrange(new Rect(new Point(x, y), child is SplitterControl ? new Size(5, finalHeight) : child.DesiredSize));
                if (_model.Orientation == Orientation.Horizontal)
                {
                    x += child.DesiredSize.Width;
                }
                else if (_model.Orientation == Orientation.Vertical)
                {
                    y += child.DesiredSize.Height;
                }
            }
            return finalSize;
        }

        public void UpdateChildren()
        {
            CreateSplitters();
        }

        private void CreateSplitters()
        {
            for (int i = 1; i < _panel.Children.Count; i++)
            {
                var splitter = new SplitterControl();
                splitter.Cursor = _model.Orientation == Orientation.Horizontal ? Cursors.SizeWE : Cursors.SizeNS;
                _panel.Children.Insert(i, splitter);
                i++;
            }
        }
    }
}
