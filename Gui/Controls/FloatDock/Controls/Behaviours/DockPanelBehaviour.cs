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
using System.Windows.Input;

namespace Instrument.Gui.Controls.FloatDock.Controls.Behaviours
{
    class DockPanelBehaviour : PanelBehaviour
    {
        public DockPanelBehaviour() : base()
        {
        }

        public override Size MeasureOverride(Size availableSize)
        {
            if (Control is StyleControl template) template.Measure(availableSize);
            foreach (UIElement child in Control.Children)
            {
                child.Measure(availableSize);
            }
            return new Size(availableSize.Width, 500);
            //return availableSize;
        }

        public override Size ArrangeOverride(Size finalSize)
        {
            if (Control is StyleControl template) template.Arrange(new Rect(finalSize));
            foreach (UIElement child in Control.Children)
            {
                child.Arrange(new Rect(finalSize));
            }
            return finalSize;
        }



        public override void UpdateChildren()
        {
            
        }



        //public override Size MeasureOverride(Size availableSize)
        //{
        //    double availableWidth = availableSize.Width;
        //    double availableHeight = availableSize.Height;
        //    List<UIElement> docks = new List<UIElement>();
        //    List<UIElement> center = new List<UIElement>();
        //    foreach (UIElement child in Panel.Children.OfType<SplitterControl>())
        //    {
        //        child.Measure(availableSize);
        //    }
        //    foreach (UIElement child in Panel.Children.OfType<ILayoutControl>())
        //    {
        //        Layout.Dock dock = LayoutPanel.GetDock((child as ILayoutControl).Model);
        //        double width = 0;
        //        double height = 0;
        //        switch (dock)
        //        {
        //            case Layout.Dock.HideRight:
        //            case Layout.Dock.HideLeft:
        //                width = 30;
        //                height = availableSize.Height;
        //                availableWidth -= width;
        //                break;
        //            case Layout.Dock.HideTop:
        //            case Layout.Dock.HideBottom:
        //                width = availableWidth;
        //                height = 30;
        //                availableHeight -= height;
        //                break;
        //            case Layout.Dock.Right:
        //            case Layout.Dock.Left:
        //            case Layout.Dock.Top:
        //            case Layout.Dock.Bottom:
        //                docks.Add(child);
        //                continue;
        //            case Layout.Dock.Center:
        //                center.Add(child);
        //                continue;
        //        }
        //        child.Measure(new Size(width, height));
        //    }
        //    foreach (UIElement child in docks)
        //    {
        //        Layout.Dock dock = LayoutPanel.GetDock((child as ILayoutControl).Model);
        //        double width = 0;
        //        double height = 0;
        //        switch (dock)
        //        {
        //            case Layout.Dock.Top:
        //            case Layout.Dock.Bottom:
        //                width = availableWidth;
        //                height = availableHeight / Panel.Children.Count;
        //                availableHeight -= height;
        //                break;
        //            case Layout.Dock.Right:
        //            case Layout.Dock.Left:
        //                width = availableWidth / Panel.Children.Count;
        //                height = availableHeight;
        //                availableWidth -= width;
        //                break;
        //        }
        //        child.Measure(new Size(width, height));
        //    }
        //    foreach (UIElement child in center)
        //    {
        //        double width = 0;
        //        double height = 0;

        //        if (Model.Orientation == Orientation.Horizontal)
        //        {
        //            width = availableWidth / center.Count;
        //            height = availableHeight;
        //        }
        //        else if (Model.Orientation == Orientation.Vertical)
        //        {
        //            width = availableWidth;
        //            height = availableHeight / center.Count;
        //        }
        //        child.Measure(new Size(width, height));
        //    }
        //    return availableSize;
        //}

        //public override Size ArrangeOverride(Size finalSize)
        //{
        //    double x = 0;
        //    double y = 0;
        //    double finalWidth = finalSize.Width;
        //    double finalHeight = finalSize.Height;
        //    List<UIElement> docks = new List<UIElement>();
        //    List<UIElement> center = new List<UIElement>();
        //    for (int i = 0; i < Panel.Children.Count; i++)
        //    {
        //        UIElement child = Panel.Children[i];
        //        Layout.Dock dock = LayoutPanel.GetDock((child as ILayoutControl).Model);
        //        switch (dock)
        //        {
        //            case Layout.Dock.HideRight:
        //                child.Arrange(new Rect(new Point(0, 0), child.DesiredSize));
        //                x += child.DesiredSize.Width;
        //                break;
        //            case Layout.Dock.HideLeft:
        //                child.Arrange(new Rect(new Point(finalSize.Width - child.DesiredSize.Width, 0), child.DesiredSize));
        //                finalWidth -= child.DesiredSize.Width;
        //                break;
        //            case Layout.Dock.HideTop:
        //                child.Arrange(new Rect(new Point(x, 0), child.DesiredSize));
        //                y += child.DesiredSize.Height;
        //                break;
        //            case Layout.Dock.HideBottom:
        //                child.Arrange(new Rect(new Point(x, finalSize.Height - child.DesiredSize.Height), child.DesiredSize));
        //                finalHeight -= child.DesiredSize.Height;
        //                break;
        //            case Layout.Dock.Right:
        //            case Layout.Dock.Left:
        //            case Layout.Dock.Top:
        //            case Layout.Dock.Bottom:
        //                docks.Add(child);
        //                if (i + 1 < Panel.Children.Count && Panel.Children[i + 1] is SplitterControl)
        //                    docks.Add(Panel.Children[++i]);
        //                continue;
        //            case Layout.Dock.Center:
        //                center.Add(child);
        //                if (i + 1 < Panel.Children.Count && Panel.Children[i + 1] is SplitterControl)
        //                    center.Add(Panel.Children[++i]);
        //                continue;
        //        }
        //    }
        //    for (int i = 0; i < docks.Count; i++)
        //    {
        //        UIElement child = docks[i];
        //        Layout.Dock dock = LayoutPanel.GetDock((child as ILayoutControl).Model);
        //        switch(dock)
        //        {
        //            case Layout.Dock.Top:
        //                child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
        //                y += child.DesiredSize.Height;
        //                finalHeight -= child.DesiredSize.Height;
        //                if (i + 1 < docks.Count && docks[i + 1] is SplitterControl)
        //                {
        //                    docks[++i].Arrange(new Rect(new Point(x, y), new Size(finalWidth, 5)));
        //                    y += 5;
        //                    finalHeight -= 5;
        //                }
        //                break;
        //            case Layout.Dock.Bottom:
        //                child.Arrange(new Rect(new Point(x, finalHeight - child.DesiredSize.Height), child.DesiredSize));
        //                finalHeight -= child.DesiredSize.Height;
        //                if (i + 1 < docks.Count && docks[i + 1] is SplitterControl)
        //                {
        //                    docks[++i].Arrange(new Rect(new Point(x, y), new Size(finalWidth, 5)));
        //                    y += 5;
        //                    finalHeight -= 5;
        //                }
        //                break;
        //            case Layout.Dock.Right:
        //                child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
        //                x += child.DesiredSize.Width;
        //                if (i + 1 < docks.Count && docks[i + 1] is SplitterControl)
        //                {
        //                    docks[++i].Arrange(new Rect(new Point(x, y), new Size(5, finalHeight)));
        //                    x += 5;
        //                    finalWidth -= 5;
        //                }
        //                break;
        //            case Layout.Dock.Left:
        //                child.Arrange(new Rect(new Point(finalWidth - child.DesiredSize.Width, y), child.DesiredSize));
        //                finalWidth -= child.DesiredSize.Width;
        //                if (i + 1 < docks.Count && docks[i + 1] is SplitterControl)
        //                {
        //                    docks[++i].Arrange(new Rect(new Point(x, y), new Size(5, finalHeight)));
        //                    x += 5;
        //                    finalWidth -= 5;
        //                }
        //                break;
        //        }
        //    }
        //    foreach (UIElement child in center)
        //    {
        //        child.Arrange(new Rect(new Point(x, y), child is SplitterControl ? new Size(5, finalHeight) : child.DesiredSize));
        //        if (Model.Orientation == Orientation.Horizontal)
        //        {
        //            x += child.DesiredSize.Width;
        //        }
        //        else if (Model.Orientation == Orientation.Vertical)
        //        {
        //            y += child.DesiredSize.Height;
        //        }
        //    }
        //    return finalSize;
        //}

        //public override void UpdateChildren()
        //{
        //    CreateSplitters();
        //}

        //private void CreateSplitters()
        //{
        //    for (int i = 1; i < Panel.Children.Count; i++)
        //    {
        //        var splitter = new SplitterControl();
        //        splitter.Cursor = Model.Orientation == Orientation.Horizontal ? Cursors.SizeWE : Cursors.SizeNS;
        //        Panel.Children.Insert(i, splitter);
        //        i++;
        //    }
        //}
    }
}
