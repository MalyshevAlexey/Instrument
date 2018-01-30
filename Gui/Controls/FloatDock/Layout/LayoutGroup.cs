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
    public abstract class LayoutGroup<T> : LayoutElement, ILayoutContainer where T : UIElement
    {
        #region Constructor

        internal LayoutGroup()
        {
            _children.CollectionChanged += new NotifyCollectionChangedEventHandler(_children_CollectionChanged);
        }

        void _children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine(e.Action);
        }

        #endregion

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
    }
}
