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
        public StyleControl(LayoutElement model)
        {
            _model = model;
        }

        #region Model

        LayoutElement _model;
        public LayoutObject Model
        {
            get { return _model; }
        }

        #endregion

        public IEnumerable Children
        {
            get
            {
                return Items;
            }
        }

        public void SetChildren()
        {
            foreach (ILayoutObject child in _model.Children)
            {
                if (child is LayoutConfig conf)
                {
                    if (conf.Type != _model.Type) throw new Exception("Config is not valide");
                    _model.Config = conf;
                }
                else
                    Items.Add(_model.Root.Manager.UIElementFromModel(child));
            }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            return finalSize;
        }

    }
}
