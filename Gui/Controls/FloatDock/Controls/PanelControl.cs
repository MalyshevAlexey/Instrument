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

        public PanelControl()
        {

        }



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

        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register(nameof(Model), typeof(LayoutElement), typeof(PanelControl),
                new FrameworkPropertyMetadata(null, OnModelChanged));

        public LayoutElement Model1
        {
            get { return (LayoutElement)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        private static void OnModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PanelControl)d).OnModelChanged(e);
        }

        protected virtual void OnModelChanged(DependencyPropertyChangedEventArgs e)
        {
            _model = e.NewValue as LayoutElement;
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

        public int ChildrenCount => Children.Count;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            UpdateChildren();
            //LayoutUpdated += new EventHandler(OnLayoutUpdated);
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
