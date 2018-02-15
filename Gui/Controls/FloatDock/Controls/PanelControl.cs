using Instrument.Gui.Controls.FloatDock.Base;
using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Controls.Behaviours;
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
    public class PanelControl : Panel, ILayoutControl
    {
        #region Varibles

        IPanelBehaviour behaviour = null;

        #endregion

        #region Constructor

        public PanelControl(LayoutPanel model)
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
        public LayoutElement Model
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
            var manager = _model?.Root?.Manager;
            if (manager == null)
                return;

            behaviour = manager.BehaviourFromType(this, _model);
            Children.Clear();
            foreach (ILayoutElement child in _model.Children)
            {
                if (child is ElementConfig conf)
                {
                    if (conf.Type != _model.Type) throw new Exception("Config is not valide");
                    _model.Config = conf;
                }
                else
                    Children.Add(manager.UIElementFromModel(child));
            }
        }

        private void OnLayoutUpdated(object sender, EventArgs e)
        {
            _model.ActualWidth = ActualWidth;
            _model.ActualHeight = ActualHeight;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            return behaviour.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            return behaviour.ArrangeOverride(finalSize);
        }
    }
}
