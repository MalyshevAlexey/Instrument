using Instrument.Gui.Controls.FloatDock.Base;
using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Layout;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Instrument.Gui.Controls.FloatDock.Controls
{
    class TestPanelControl : ItemsControl, ILayoutControl
    {
        #region Varibles

        IPanelBehaviour behaviour = null;
        public bool flag = true;

        #endregion

        #region Model

        LayoutElement _model;
        public LayoutObject Model
        {
            get { return _model; }
        }

        #endregion

        #region Constructor

        public TestPanelControl(TestPanel model)
        {
            _model = model;
            _model.PropertyChanged += (s, args) =>
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (flag)
                    {
                        UpdateChildren();
                    }
                }), DispatcherPriority.Normal, null);
            };
        }

        #endregion

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            UpdateChildren();
        }

        private void UpdateChildren()
        {
            var manager = _model?.Root?.Manager;
            if (manager == null)
                return;

            if (manager.Resources[_model.Style] is Style style)
                Style = style;

            behaviour = manager.BehaviourFromType(_model.Type) as IPanelBehaviour;
            if (behaviour == null)
                return;

            behaviour.Initialize(this);
            Items.Clear();
            foreach (ILayoutObject child in _model.Children)
            {
                if (child is LayoutConfig conf)
                {
                    if (conf.Type != _model.Type) throw new Exception("Config is not valide");
                    _model.Config = conf;
                }
                else
                    Items.Add(manager.UIElementFromModel(child));
            }

            FrameworkElementFactory factoryPanel = new FrameworkElementFactory(typeof(PanelControl));

            factoryPanel.SetValue(PanelControl.ModelProperty, _model);

            ItemsPanelTemplate template = new ItemsPanelTemplate();

            template.VisualTree = factoryPanel;

            ItemsPanel = template;


            behaviour.UpdateChildren();
        }

        public IEnumerable Children
        {
            get
            {
                return Items;
            }
        }

        public int ChildrenCount => Items.Count;

        public void InternalMeasure(Size availableSize)
        {
            base.MeasureOverride(availableSize);
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            return base.MeasureOverride(availableSize);
            //return behaviour.MeasureOverride(availableSize);
            //return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            return base.ArrangeOverride(finalSize);
            //return behaviour.ArrangeOverride(finalSize);
        }
    }
}
