using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Layout;
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

    public abstract class LayoutGroup<T> : LayoutObject, ILayoutGroup where T : ILayoutObject
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
                foreach (LayoutObject element in e.OldItems)
                {
                    if (element.Parent == this)
                        element.Parent = null;
                }
            }
            if (e.NewItems != null)
            {
                foreach (ILayoutObject element in e.NewItems)
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

        #region Children

        public event EventHandler ChildrenCollectionChanged;

        ElementCollection<T> _children = new ElementCollection<T>();
        public ElementCollection<T> Children
        {
            get { return _children; }
        }

        IEnumerable<ILayoutObject> ILayoutContainer.Children
        {
            get { return _children.Cast<ILayoutObject>(); }
        }

        public int ChildrenCount
        {
            get { return _children.Count; }
        }

        public void InsertChildAt(int index, ILayoutObject element)
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

        public int IndexOfChild(ILayoutObject element)
        {
            return _children.Cast<ILayoutObject>().ToList().IndexOf(element);
        }

        public void RemoveChild(ILayoutObject element)
        {
            _children.Remove((T)element);
        }

        public void RemoveChildAt(int childIndex)
        {
            _children.RemoveAt(childIndex);
        }

        public void ReplaceChild(ILayoutObject oldElement, ILayoutObject newElement)
        {
            int index = _children.IndexOf((T)oldElement);
            _children.Insert(index, (T)newElement);
            _children.RemoveAt(index + 1);
        }

        public void ReplaceChildAt(int index, ILayoutObject element)
        {
            _children[index] = (T)element;
        }

        #endregion
    }
}
