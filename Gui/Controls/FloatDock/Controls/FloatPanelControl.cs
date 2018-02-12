using Instrument.Gui.Controls.FloatDock.Base;
using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Layout;
using Instrument.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Instrument.Gui.Controls.FloatDock.Controls
{
    public class FloatPanelControl : Panel, ILayoutControl
    {
        #region Constructor

        public FloatPanelControl(LayoutPanel model)
        {
            _model = model;
            _model.PropertyChanged += (s, args) =>
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    UpdateChildren();
                }), DispatcherPriority.Normal, null);
            };
        }

        #endregion

        #region Model

        LayoutPanel _model;
        public ILayoutElement Model
        {
            get { return _model; }
        }

        #endregion

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            UpdateChildren();
            LayoutUpdated += new EventHandler(OnLayoutUpdated);
        }

        private void UpdateChildren()
        {
            Children.Clear();

            if (_model == null ||
                _model.Root == null)
                return;

            var manager = _model.Root.Manager;
            if (manager == null)
                return;

            foreach (var item in _model.Children)
            {
                if (item is ElementConfig conf)
                {
                    if (conf.Type != _model.Type.ToString())
                        throw new Exception("Config is not valide");
                }
                else
                    Children.Add(_model.Root.Manager.UIElementFromModel(item));
            }
        }

        private void OnLayoutUpdated(object sender, EventArgs e)
        {
            _model.ActualWidth = ActualWidth;
            _model.ActualHeight = ActualHeight;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            double width = availableSize.Width / Children.Count;
            foreach (var item in Children)
            {
                (item as UIElement).Measure(new Size(width, availableSize.Height));
            }
            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double x = 0;
            foreach (var item in Children)
            {
                (item as UIElement).Arrange(new Rect(new Point(x,0),(item as UIElement).DesiredSize));
                x += (item as UIElement).DesiredSize.Width;
            }
            return base.ArrangeOverride(finalSize);
        }
    }
}
