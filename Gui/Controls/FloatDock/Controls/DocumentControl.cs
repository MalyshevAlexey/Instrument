﻿using Instrument.Gui.Controls.FloatDock.Base;
using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Layout;
using Instrument.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Instrument.Gui.Controls.FloatDock.Controls
{
    class DocumentControl : Control, ILayoutControl
    {
        //private ContentPresenter _view;
        //private object logicalChildren;

        #region Constructor

        static DocumentControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DocumentControl), new FrameworkPropertyMetadata(typeof(DocumentControl)));
        }

        public DocumentControl(LayoutDocument model)
        {
            _model = model;
            _model.PropertyChanged += (s, args) =>
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    UpdateChildren();
                }), DispatcherPriority.Normal, null);
            };
            //_view = new ContentPresenter();
            //AddVisualChild(_view);
        }

        #endregion

        #region Model

        LayoutDocument _model;
        public LayoutObject Model
        {
            get { return _model; }
        }

        #endregion

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(UIElement), typeof(DocumentControl),
            new UIPropertyMetadata(null, OnContentChanged));

        public UIElement Content
        {
            get { return (UIElement)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DocumentControl)d).OnContentChanged(e.OldValue as UIElement, e.NewValue as UIElement);
        }

        protected virtual void OnContentChanged(UIElement oldElement, UIElement newElement)
        {
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            UpdateChildren();
            //LayoutUpdated += new EventHandler(OnLayoutUpdated);
        }

        private void UpdateChildren()
        {
            Content = null;
            Content = _model.Content as UIElement;
            //if (_model?.Content != null)
            //{
            //    _view.Content = _model.Content;
            //    logicalChildren = _model.Content;
            //}
                //_view.SetBinding(ContentPresenter.ContentProperty, new Binding("Content") { Source = _model.Content });
            //Children.Clear();
            //if (_model?.Content != null)
            //    Children.Add(_model.Content as UIElement);
            //(_model.Content as Button).Command = new RelayCommand((e) =>
            //{
            //    (_model.Content as Button).Content = "changrd";
            //});
        }

        private void OnLayoutUpdated(object sender, EventArgs e)
        {
            //UpdateChildren();
        }

        //#region FrameworkElement overrides

        //protected override Visual GetVisualChild(int index)
        //{
        //    if (index < 0 || index > 1)
        //        throw new ArgumentOutOfRangeException("index");

        //    return _view;
        //}

        //protected override int VisualChildrenCount
        //{
        //    get { return 1; }
        //}

        //protected override IEnumerator LogicalChildren
        //{
        //    get { yield return logicalChildren; }
        //}

        //protected override Size MeasureOverride(Size availableSize)
        //{
        //    _view.Measure(availableSize);
        //    return _view.DesiredSize;
        //}

        //protected override Size ArrangeOverride(Size finalSize)
        //{
        //    _view.Arrange(new Rect(finalSize));
        //    return finalSize;
        //}

        //#endregion

        protected override Size MeasureOverride(Size availableSize)
        {
            //Console.WriteLine(availableSize.Width + " " + availableSize.Height);
            Content?.Measure(availableSize);
            return availableSize;
            //return new Size(200, 100);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            //Console.WriteLine(finalSize.Width + " " + finalSize.Height);
            Content?.Arrange(new Rect(finalSize));
            return base.ArrangeOverride(finalSize);
        }

        public void SetChildren()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerator LogicalChildren
        {
            get
            {
                if (Content != null)
                    yield return Content;
            }
        }

        public IEnumerable Children => throw new NotImplementedException();

        public int ChildrenCount => 1;

        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            Console.WriteLine((Content as Button).Content);
            PanelControl panel = VisualTreeHelper.GetParent(this) as PanelControl;
            //VisualTreeDumper.Dump(panel);
            panel.flag = true;
            _model?.Parent.RemoveChild(_model);
            panel.flag = false;
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseRightButtonDown(e);
            Console.WriteLine(this);
        }
    }
}
