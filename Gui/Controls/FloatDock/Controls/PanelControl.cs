using Instrument.Gui.Controls.FloatDock.Base;
using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Controls.Behaviours;
using Instrument.Gui.Controls.FloatDock.Layout;
using Instrument.Utilities;
using System;
using System.Collections;
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
        public bool flag = false;

        #endregion

        #region Constructor

        public PanelControl(LayoutPanel model)
        {
            _model = model;
            _model.PropertyChanged += (s, args) =>
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (flag)
                    {
                        UpdateChildren();
                        flag = false;
                    }
                }), DispatcherPriority.Normal, null);
            };
        }

        #endregion

        #region Model

        LayoutElement _model;
        public LayoutObject Model
        {
            get { return _model; }
        }

        #endregion

        IEnumerable ILayoutControl.Children => Children;

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

            if (manager.Resources[_model.Style] is Style style)
            {
                LayoutStyle layoutStyle = new LayoutStyle(_model);
                LayoutPanel panel = new LayoutPanel();
                int count = _model.ChildrenCount;
                for (int i = 0; i < count; i++)
                    panel.Children.Add(_model.Children.First());
                panel.Parent = layoutStyle;
                panel.Type = _model.Type;
                layoutStyle.Style = _model.Style;
                layoutStyle.Children.Add(panel);
                _model.Children.Add(layoutStyle);
                //_model = layoutStyle;
                behaviour = new StyledPanelBehaviour();
                //behaviour.Initialize(this);
            }
            else
            {
                behaviour = manager.BehaviourFromType(_model.Type) as IPanelBehaviour;
            }
            
            if (behaviour == null)
                return;

            behaviour.Initialize(this);
            Children.Clear();  

            foreach (ILayoutObject child in _model.Children)
            {
                if (child is LayoutConfig conf)
                {
                    if (conf.Type != _model.Type) throw new Exception("Config is not valide");
                    _model.Config = conf;
                }
                else
                    Children.Add(manager.UIElementFromModel(child));
            }

            behaviour.UpdateChildren();
        }

        public void SetChildren()
        {
            
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
