using Instrument.Gui.Controls.FloatDock.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Instrument.Gui.Controls.FloatDock.Layout
{
    public abstract class LayoutCollection<T> : LayoutElement, ILayoutCollection where T : ILayoutElement
    {
        #region Constructor

        internal LayoutCollection()
        {
            _children.CollectionChanged += new NotifyCollectionChangedEventHandler(_children_CollectionChanged);
        }

        #endregion

        void _children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine(e.Action);
            if (e.OldItems != null)
            {
                foreach (LayoutElement element in e.OldItems)
                {
                    if (element.Parent == this)
                        element.Parent = null;
                }
            }
            if (e.NewItems != null)
            {
                foreach (ILayoutElement element in e.NewItems)
                {
                    if (element.Parent != this)
                    {
                        if (element.Parent != null)
                            element.Parent.RemoveChild(element);
                        element.Parent = this;
                    }
                }
            }
            ChildrenCollectionChanged?.Invoke(this, EventArgs.Empty);
            RaisePropertyChanged(nameof(ChildrenCount));
        }

        #region Orientation

        private Orientation _orientation;
        public Orientation Orientation
        {
            get { return _orientation; }
            set
            {
                if (_orientation != value)
                {
                    RaisePropertyChanging(nameof(Orientation));
                    _orientation = value;
                    RaisePropertyChanged(nameof(Orientation));
                }
            }
        }

        #endregion

        #region Children

        public event EventHandler ChildrenCollectionChanged;

        ObservableCollection<T> _children = new ObservableCollection<T>();
        public ObservableCollection<T> Children
        {
            get { return _children; }
        }

        IEnumerable<ILayoutElement> ILayoutContainer.Children
        {
            get { return _children.Cast<ILayoutElement>(); }
        }

        public int ChildrenCount
        {
            get { return _children.Count; }
        }

        public void InsertChildAt(int index, ILayoutElement element)
        {
            _children.Insert(index, (T)element);
        }

        public void MoveChild(int oldIndex, int newIndex)
        {
            if (oldIndex == newIndex)
                return;
            _children.Move(oldIndex, newIndex);
            OnChildMoved(oldIndex, newIndex);
        }

        protected virtual void OnChildMoved(int oldIndex, int newIndex)
        {

        }

        public int IndexOfChild(ILayoutElement element)
        {
            return _children.Cast<ILayoutElement>().ToList().IndexOf(element);
        }

        public void RemoveChild(ILayoutElement element)
        {
            _children.Remove((T)element);
        }

        public void RemoveChildAt(int childIndex)
        {
            _children.RemoveAt(childIndex);
        }

        public void ReplaceChild(ILayoutElement oldElement, ILayoutElement newElement)
        {
            int index = _children.IndexOf((T)oldElement);
            _children.Insert(index, (T)newElement);
            _children.RemoveAt(index + 1);
        }

        public void ReplaceChildAt(int index, ILayoutElement element)
        {
            _children[index] = (T)element;
        }

        #endregion

        #region Position

        GridLength _dockWidth = new GridLength(1.0, GridUnitType.Star);
        public GridLength DockWidth
        {
            get { return _dockWidth; }
            set
            {
                if (DockWidth != value)
                {
                    RaisePropertyChanging("DockWidth");
                    _dockWidth = value;
                    RaisePropertyChanged("DockWidth");

                    OnDockWidthChanged();
                }
            }
        }

        protected virtual void OnDockWidthChanged()
        {

        }

        GridLength _dockHeight = new GridLength(1.0, GridUnitType.Star);
        public GridLength DockHeight
        {
            get { return _dockHeight; }
            set
            {
                if (DockHeight != value)
                {
                    RaisePropertyChanging("DockHeight");
                    _dockHeight = value;
                    RaisePropertyChanged("DockHeight");

                    OnDockHeightChanged();
                }
            }
        }

        protected virtual void OnDockHeightChanged()
        {

        }

        #region DockMinWidth

        private double _dockMinWidth = 25.0;
        public double DockMinWidth
        {
            get { return _dockMinWidth; }
            set
            {
                if (_dockMinWidth != value)
                {
                    //MathHelper.AssertIsPositiveOrZero(value);
                    RaisePropertyChanging("DockMinWidth");
                    _dockMinWidth = value;
                    RaisePropertyChanged("DockMinWidth");
                }
            }
        }

        #endregion

        #region DockMinHeight

        private double _dockMinHeight = 25.0;
        public double DockMinHeight
        {
            get { return _dockMinHeight; }
            set
            {
                if (_dockMinHeight != value)
                {
                    //MathHelper.AssertIsPositiveOrZero(value);
                    RaisePropertyChanging("DockMinHeight");
                    _dockMinHeight = value;
                    RaisePropertyChanged("DockMinHeight");
                }
            }
        }

        #endregion

        private double _actualWidth;
        public double ActualWidth
        {
            get { return _actualWidth; }
            set { _actualWidth = value; }
        }

        private double _actualHeight;
        public double ActualHeight
        {
            get { return _actualHeight; }
            set { _actualHeight = value; }
        }

        #endregion
    }
}
