using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Layout;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Instrument.Gui.Controls.FloatDock.Base
{
    public abstract class LayoutElement : LayoutGroup<ILayoutObject>, ILayoutElement
    {
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

        private LayoutConfig _config = null;
        public LayoutConfig Config
        {
            get { return _config; }
            set
            {
                if (_config != value)
                {
                    RaisePropertyChanging(nameof(Config));
                    _config = value;
                    //RaisePropertyChanged(nameof(Config));
                }
            }
        }

        #endregion

        #region TypeProperty

        public Type Type
        {
            get { return (Type)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register(nameof(Type), typeof(Type), typeof(LayoutElement),
                new FrameworkPropertyMetadata(Type.Dock, OnTypeChanged));

        private static void OnTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LayoutElement)d).RaisePropertyChanged(nameof(Type));
        }

        #endregion

        #region StyleProperty

        public string Style
        {
            get { return (string)GetValue(StyleProperty); }
            set { SetValue(StyleProperty, value); }
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.Register(nameof(Style), typeof(string), typeof(LayoutObject),
                new FrameworkPropertyMetadata("", OnStyleChanged));

        private static void OnStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LayoutElement)d).OnStyleChanged(e.OldValue as string, e.NewValue as string);
        }

        private void OnStyleChanged(string oldStyle, string newStyle)
        {
            
        }

        #endregion
    }
}
