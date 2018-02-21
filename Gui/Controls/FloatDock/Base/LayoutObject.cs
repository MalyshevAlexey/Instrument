﻿using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using System.ComponentModel;
using System.Windows;

namespace Instrument.Gui.Controls.FloatDock.Base
{
    public abstract class LayoutObject : DependencyObject, ILayoutObject
    {
        #region Root

        private ILayoutRoot _root = null;
        public ILayoutRoot Root
        {
            get
            {
                var parent = Parent;
                while (parent != null && (!(parent is ILayoutRoot)))
                    parent = parent.Parent;
                return parent as ILayoutRoot;
            }
        }

        #endregion

        #region Parent

        private ILayoutContainer _parent = null;
        public ILayoutContainer Parent
        {
            get { return _parent; }
            set
            {
                if (_parent != value)
                {
                    ILayoutContainer oldValue = _parent;
                    ILayoutRoot oldRoot = _root;
                    RaisePropertyChanging(nameof(Parent));
                    OnParentChanging(oldValue, value);
                    _parent = value;
                    OnParentChanged(oldValue, value);
                    _root = Root;
                    if (oldRoot != _root)
                        OnRootChanged(oldRoot, _root);
                    RaisePropertyChanged(nameof(Parent));
                }
            }
        }

        protected virtual void OnParentChanging(ILayoutContainer oldValue, ILayoutContainer newValue)
        {
        }

        protected virtual void OnParentChanged(ILayoutContainer oldValue, ILayoutContainer newValue)
        {
        }

        protected virtual void OnRootChanged(ILayoutRoot oldRoot, ILayoutRoot newRoot)
        {
        }

        #endregion

        #region TagProperty

        public string Tag
        {
            get { return (string)GetValue(TagProperty); }
            set { SetValue(TagProperty, value); }
        }

        public static readonly DependencyProperty TagProperty =
            DependencyProperty.Register(nameof(Tag), typeof(string), typeof(LayoutObject),
                new FrameworkPropertyMetadata(""));

        #endregion

        public event PropertyChangingEventHandler PropertyChanging;
        protected virtual void RaisePropertyChanging(string propertyName)
            => PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
