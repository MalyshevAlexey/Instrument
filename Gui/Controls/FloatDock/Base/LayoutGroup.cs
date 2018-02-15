using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Instrument.Gui.Controls.FloatDock.Base
{
    public class ElementCollection<T> : ObservableCollection<T>
    {
    }

    public abstract class LayoutGroup<T> : LayoutElement, ILayoutGroup where T : ILayoutElement
    {
        #region Constructor

        internal LayoutGroup()
        {
            _children.CollectionChanged += new NotifyCollectionChangedEventHandler(_children_CollectionChanged);
        }

        #endregion

        private void _children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //Console.WriteLine(e.Action);
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

        ElementCollection<T> _children = new ElementCollection<T>();
        public ElementCollection<T> Children
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

        #region Width

        GridLength _width = new GridLength(1.0, GridUnitType.Star);
        public GridLength Width
        {
            get { return _width; }
            set
            {
                if (Width != value)
                {
                    RaisePropertyChanging(nameof(Width));
                    _width = value;
                    RaisePropertyChanged(nameof(Width));

                    OnWidthChanged();
                }
            }
        }

        protected virtual void OnWidthChanged()
        {

        }

        #endregion

        #region Height

        GridLength _height = new GridLength(1.0, GridUnitType.Star);
        public GridLength Height
        {
            get { return _height; }
            set
            {
                if (Height != value)
                {
                    RaisePropertyChanging(nameof(Height));
                    _height = value;
                    RaisePropertyChanged(nameof(Height));

                    OnDockHeightChanged();
                }
            }
        }

        protected virtual void OnDockHeightChanged()
        {

        }

        #endregion

        #region MinWidth

        private double _minWidth = 25.0;
        public double MinWidth
        {
            get { return _minWidth; }
            set
            {
                if (_minWidth != value)
                {
                    //MathHelper.AssertIsPositiveOrZero(value);
                    RaisePropertyChanging(nameof(MinWidth));
                    _minWidth = value;
                    RaisePropertyChanged(nameof(MinWidth));
                }
            }
        }

        #endregion

        #region MinHeight

        private double _minHeight = 25.0;
        public double MinHeight
        {
            get { return _minHeight; }
            set
            {
                if (_minHeight != value)
                {
                    //MathHelper.AssertIsPositiveOrZero(value);
                    RaisePropertyChanging(nameof(MinHeight));
                    _minHeight = value;
                    RaisePropertyChanged(nameof(MinHeight));
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

        #region Config

        private ElementConfig _config = null;
        public ElementConfig Config
        {
            get { return _config; }
            set
            {
                if (_config != value)
                {
                    RaisePropertyChanging(nameof(Config));
                    _config = value;
                    RaisePropertyChanged(nameof(Config));
                }
            }
        }

        #endregion
    }
}
