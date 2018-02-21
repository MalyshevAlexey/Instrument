using Instrument.Gui.Controls.FloatDock.Base;
using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Controls;
using Instrument.Gui.Controls.FloatDock.Controls.Behaviours;
using Instrument.Gui.Controls.FloatDock.Layout;
using Instrument.Gui.Controls.FloatDock.Layout.LayoutEventArgs;
using Instrument.Gui.Controls.FloatDock.Themes;
using Instrument.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Instrument.Gui.Controls.FloatDock
{
    [ContentProperty(nameof(LayoutRootPanel))]
    public class DockManager : Control
    {
        #region Variables

        public Size AvailableSize { get; private set; }

        #endregion

        #region Constructor

        static DockManager()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockManager), new FrameworkPropertyMetadata(typeof(DockManager)));
        }

        public DockManager()
        {
            LayoutRoot = new LayoutRoot(this);
            Theme = new GenericTheme();
            Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = Theme.GetThemeUri() });
        }

        #endregion

        #region LayoutRoot

        public ILayoutRoot LayoutRoot
        {
            get { return (ILayoutRoot)GetValue(LayoutRootProperty); }
            set { SetValue(LayoutRootProperty, value); }
        }

        public static readonly DependencyProperty LayoutRootProperty =
            DependencyProperty.Register(nameof(LayoutRoot), typeof(ILayoutRoot), typeof(DockManager),
                new FrameworkPropertyMetadata(null, OnLayoutRootChanged));

        private static void OnLayoutRootChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        #endregion

        #region LayoutRootPanel

        public ILayoutElement LayoutRootPanel
        {
            get { return (ILayoutElement)GetValue(LayoutRootPanelProperty); }
            set { SetValue(LayoutRootPanelProperty, value); }
        }

        public static readonly DependencyProperty LayoutRootPanelProperty =
            DependencyProperty.Register(nameof(LayoutRootPanel), typeof(ILayoutElement), typeof(DockManager),
                new FrameworkPropertyMetadata(null, OnLayoutRootPanelChanged));

        private static void OnLayoutRootPanelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DockManager)d).OnLayoutRootPanelChanged(e.OldValue as ILayoutElement, e.NewValue as ILayoutElement);
        }

        public virtual void OnLayoutRootPanelChanged(ILayoutElement oldLayout, ILayoutElement newLayout)
        {
            if (oldLayout != null)
            {

            }
            if (newLayout != null)
            {
                LayoutRootPanel.Parent = LayoutRoot;
                LayoutRootPanelChanged?.Invoke(this, EventArgs.Empty);
                if (RootPanelControl == null)
                    RootPanelControl = UIElementFromModel(LayoutRootPanel) as ILayoutControl;
            }
        }

        public event EventHandler LayoutRootPanelChanged;

        #endregion

        #region RootPanelControl

        /// <summary>
        /// RootPanelControl Dependency Property
        /// </summary>
        public static readonly DependencyProperty RootPanelControlProperty =
            DependencyProperty.Register(nameof(RootPanelControl), typeof(ILayoutControl), typeof(DockManager),
                new FrameworkPropertyMetadata(null, OnRootPanelControlChanged));

        /// <summary>
        /// Gets or sets the RootPanelControl property.  This dependency property 
        /// indicates the layout panel control which is attached to the Layout.Root property.
        /// </summary>
        public ILayoutControl RootPanelControl
        {
            get { return (ILayoutControl)GetValue(RootPanelControlProperty); }
            set { SetValue(RootPanelControlProperty, value); }
        }

        /// <summary>
        /// Handles changes to the RootPanelControl property.
        /// </summary>
        private static void OnRootPanelControlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DockManager)d).OnRootPanelControlChanged(e.OldValue as ILayoutControl, e.NewValue as ILayoutControl);
        }

        public virtual void OnRootPanelControlChanged(ILayoutControl oldControl, ILayoutControl newControl)
        {
            if (oldControl != null)
            {

            }
            if (newControl != null)
            {
                
            }
        }

        #endregion

        #region Theme

        public static readonly DependencyProperty ThemeProperty =
            DependencyProperty.Register(nameof(Theme), typeof(Theme), typeof(DockManager),
                new FrameworkPropertyMetadata(null, OnThemeChanged));

        public Theme Theme
        {
            get { return (Theme)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }

        private static void OnThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DockManager)d).OnThemeChanged(e);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the Theme property.
        /// </summary>
        protected virtual void OnThemeChanged(DependencyPropertyChangedEventArgs e)
        {
            var oldTheme = e.OldValue as Theme;
            var newTheme = e.NewValue as Theme;
            var resources = this.Resources;
            if (oldTheme != null)
            {
                var resourceDictionaryToRemove =
                    resources.MergedDictionaries.FirstOrDefault(r => r.Source == oldTheme.GetThemeUri());
                if (resourceDictionaryToRemove != null)
                    resources.MergedDictionaries.Remove(
                        resourceDictionaryToRemove);
            }

            if (newTheme != null)
            {
                resources.MergedDictionaries.Add(new ResourceDictionary() { Source = newTheme.GetThemeUri() });
            }
        }

        #endregion

        internal UIElement UIElementFromModel(ILayoutObject model)
        {
            if (model is LayoutPanel panel)
                return new PanelControl(panel);
            if (model is LayoutDocument doc)
                return new DocumentControl(doc);

            return null;
        }

        internal IBehaviour BehaviourFromType(Layout.Type type)
        {
            if (type == Layout.Type.Dock)
                return new DockPanelBehaviour();
            
            return null;
        }

        protected override IEnumerator LogicalChildren
        {
            get
            {
                if (RootPanelControl != null)
                    yield return RootPanelControl;
            }
        }

        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            LogicalTreeDumper.Dump(this);
            VisualTreeDumper.Dump(this);
        }

        //protected override Size MeasureOverride(Size availableSize)
        //{
        //    AvailableSize = availableSize;
        //    return base.MeasureOverride(availableSize);
        //}
    }
}
