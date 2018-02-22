using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Instrument.Gui.Controls.FloatDock.Base;
using System.Collections;

namespace Instrument.Gui.Controls.FloatDock.Controls
{
    public class StyleControl : ItemsControl, ILayoutControl
    {
        #region Varibles

        IPanelBehaviour behaviour = null;

        #endregion

        public StyleControl(LayoutElement model)
        {
            _model = model;
            Style = _model?.Root?.Manager.Resources[_model.Style] as Style;
        }

        #region Model

        LayoutElement _model;
        public LayoutObject Model
        {
            get { return _model; }
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

            behaviour.UpdateChildren();
        }

        public IEnumerable Children
        {
            get
            {
                return Items;
            }
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
