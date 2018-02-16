using Instrument.Gui.Controls.FloatDock.Base;
using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Controls;
using Instrument.Gui.Controls.FloatDock.Layout.LayoutConfigs;
using Instrument.Gui.Controls.FloatDock.Layout.LayoutEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Instrument.Gui.Controls.FloatDock.Layout
{
    public class LayoutRoot : LayoutObject, ILayoutRoot
    {
        #region Variables

        public ILayoutElement RootPanel { get; private set; } = null;

        #endregion

        #region Constructor

        public LayoutRoot(DockManager manager)
        {
            Manager = manager;
            Parent = this;
            Manager.LayoutRootPanelChanged += (s, args) => RootPanel = Manager.LayoutRootPanel;
        }

        #endregion

        #region Manager

        private DockManager _manager = null;
        public DockManager Manager
        {
            get { return _manager; }
            internal set
            {
                if (_manager != value)
                {
                    RaisePropertyChanging(nameof(Manager));
                    _manager = value;
                    RaisePropertyChanged(nameof(Manager));
                }
            }
        }

        #endregion

        #region Children

        public IEnumerable<ILayoutObject> Children
        {
            get
            {
                if (RootPanel is ILayoutContainer)
                    yield return RootPanel;
            }
        }

        public int ChildrenCount => RootPanel == null ? 0 : 1;

        public void RemoveChild(ILayoutObject element)
        {
            if (element == RootPanel)
                RootPanel = _manager.LayoutRootPanel = null;
        }

        public void ReplaceChild(ILayoutObject oldElement, ILayoutObject newElement)
        {
            if (oldElement == RootPanel)
                _manager.LayoutRootPanel = (ILayoutElement)newElement;
        }

        #endregion




















        //public virtual void OnLayoutRootPanelChanged(ILayoutCollection oldLayout, ILayoutCollection newLayout)
        //{
        //    if (oldLayout != null)
        //    {

        //    }
        //    if (newLayout != null)
        //    {
        //        newLayout.Parent = this;


        //        RootPanel = newLayout;

        //        //if (DesignMode) throw new Exception((newLayout as LayoutPanel).Tag.ToString());


        //        //Button btn1 = new Button() { Content = "Another 1" };
        //        //Button btn2 = new Button() { Content = "Another 2" };
        //        //LayoutDocument document = new LayoutDocument();
        //        //LayoutDocument document1 = new LayoutDocument();
        //        //document.Content = btn1;
        //        //document1.Content = btn2;
        //        //(RootPanel as LayoutPanel).Children.Add(document);
        //        //(RootPanel as LayoutPanel).Children.Add(document1);


        //        if (RootPanelControl == null)
        //            RootPanelControl = Manager.UIElementFromModel(RootPanel) as ILayoutControl;
                
        //        (RootPanelControl as FloatPanelControl).Children.Clear();
        //        //RecursiveBuildTree(RootPanel, RootPanelControl as UIElement);

                

        //        //RecursiveBuildTree(RootPanel, RootPanelControl as UIElement);

        //        Test(RootPanel, RootPanelControl as UIElement);


        //        //(RootPanelControl as FloatPanelControl).Children.Add(new DocumentControl(new LayoutDocument()) { AddChild = new Button() { Content = "Another button" } });
        //        //(RootPanelControl as FloatPanelControl).Children.Add(new TabControl());

        //        //(RootPanelControl as UIElement).Measure(new Size(400, 300));
        //        //(RootPanelControl as UIElement).Arrange(new Rect(Manager.DesiredSize));
        //        //RootPanel.ChildrenCollectionChanged += new EventHandler(RootPanelControl.InitContent);



        //        RootPanel.ChildrenCollectionChanged += RootPanel_ChildrenCollectionChanged;
        //    }
        //}

        //public void Test(ILayoutContainer current, UIElement control)
        //{
        //    foreach (ILayoutElement logicalChild in current.Children)
        //    {
        //        if (logicalChild is ILayoutContainer)
        //        {
        //            UIElement nextControl = Manager.UIElementFromModel(logicalChild);
        //            (control as Panel).Children.Add(nextControl);
        //            Test(logicalChild as ILayoutContainer, nextControl);
        //        }
        //        else if (logicalChild is LayoutContent)
        //        {
        //            UIElement doc = Manager.UIElementFromModel(logicalChild);
        //            (doc as Panel).Children.Add((logicalChild as LayoutContent).Content as UIElement);
        //            (control as Panel).Children.Add(doc);
        //        }
        //    }

        //    //if (current is ILayoutContainer)
        //    //{
        //    //    LayoutDocument document = new LayoutDocument() { Content = new Button() { Content = "Another ertreqwqw" } };
        //    //    UIElement nextControl = Manager.UIElementFromModel(document);
        //    //    (control as FloatPanelControl).Children.Add(nextControl);
        //    //    Test(document, nextControl);

        //    //    LayoutDocument document1 = new LayoutDocument() { Content = new Button() { Content = "Another er111111" } };
        //    //    UIElement nextControl1 = Manager.UIElementFromModel(document1);
        //    //    (control as FloatPanelControl).Children.Add(nextControl1);
        //    //    Test(document1, nextControl1);
        //    //}
        //    //else if (current is LayoutContent)
        //    //{
        //    //    UIElement doc = Manager.UIElementFromModel(current);
        //    //    (doc as Panel).Children.Add((current as LayoutContent).Content as UIElement);
        //    //    (control as Panel).Children.Add(doc);
        //    //}
        //}

        //public void RecursiveBuildTree(ILayoutContainer current, UIElement control)
        //{
        //    if (current != null)
        //    {
        //        foreach (ILayoutElement logicalChild in current.Children)
        //        {
        //            if (logicalChild is ILayoutContainer)
        //            {
        //                UIElement nextControl = Manager.UIElementFromModel(logicalChild);
        //                (control as Panel).Children.Add(nextControl);
        //                RecursiveBuildTree(logicalChild as ILayoutContainer, nextControl);
        //            }
        //            else if (logicalChild is ElementConfig config)
        //            {
        //                //Console.WriteLine("Config");
        //                current.Config = config;
        //            }
        //            else if (logicalChild is LayoutContent content)
        //            {
        //                UIElement doc = Manager.UIElementFromModel(content);
        //                (doc as Panel).Children.Add(content.Content as UIElement);
        //                (control as Panel).Children.Add(doc);
        //            }
        //        }
        //    }
        //}
    }
}
