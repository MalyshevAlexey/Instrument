using Instrument.Gui.Controls.FloatDock.Interfaces;
using Instrument.Gui.Controls.FloatDock.Layout;
using Instrument.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Instrument.Gui.Controls.FloatDock.Controls
{
    public class FloatPanelControl : Grid , ILayoutControl
    {
        #region Constructor

        public FloatPanelControl(LayoutPanel model)
        {
            _model = model;
            InitContent();
            //CreateDynamicWPFGrid();
        }

        #endregion

        #region Model

        LayoutPanel _model;
        public ILayoutElement Model
        {
            get { return _model; }
        }

        #endregion

        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            LogicalTreeDumper.Dump(this);
            VisualTreeDumper.Dump(this);
        }

        private void InitContent()
        {
            int count = 0;
            
            for (int i = 0; i < _model.Children.Count + 5; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition() { Width = GridLength.Auto };
                ColumnDefinitions.Add(gridCol);
            }
            foreach (var item in _model.Children)
            {
                SetColumn(item, ++count);
                Children.Add(item);
                if (count < _model.Children.Count + 3)
                {
                    var gs1 = new GridSplitter();
                    gs1.HorizontalAlignment = HorizontalAlignment.Center;
                    gs1.VerticalAlignment = VerticalAlignment.Stretch;
                    gs1.Width = 5; //or whatever other height you desire.
                    SetColumn(gs1, ++count);
                    Children.Add(gs1);
                }
                
            }
            MeasureOverride(new Size(ActualWidth, ActualHeight));
            ArrangeOverride(new Size(ActualWidth, ActualHeight));
        }

        private void CreateDynamicWPFGrid()
        {
            // Create the Grid
            Grid DynamicGrid = new Grid();
            DynamicGrid.Background = new SolidColorBrush(Colors.Green);
            //DynamicGrid.ShowGridLines = true;

            ColumnDefinition gridCol1 = new ColumnDefinition() { Width = GridLength.Auto };
            ColumnDefinition gridCol2 = new ColumnDefinition() { Width = GridLength.Auto };
            ColumnDefinition gridCol3 = new ColumnDefinition() { Width = GridLength.Auto };
            ColumnDefinition gridCol4 = new ColumnDefinition();
            ColumnDefinition gridCol5 = new ColumnDefinition() { Width = GridLength.Auto };
            ColumnDefinition gridCol6 = new ColumnDefinition() { Width = GridLength.Auto };
            ColumnDefinition gridCol7 = new ColumnDefinition() { Width = GridLength.Auto };

            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);
            DynamicGrid.ColumnDefinitions.Add(gridCol3);
            DynamicGrid.ColumnDefinitions.Add(gridCol4);
            DynamicGrid.ColumnDefinitions.Add(gridCol5);
            DynamicGrid.ColumnDefinitions.Add(gridCol6);
            DynamicGrid.ColumnDefinitions.Add(gridCol7);

            TextBlock txt1 = new TextBlock() { Text = "Test Left" };
            TextBlock txt2 = new TextBlock() { Text = "Test Middle" };
            TextBlock txt3 = new TextBlock() { Text = "Test Left" };

            var gs1 = new GridSplitter();
            gs1.HorizontalAlignment = HorizontalAlignment.Center;
            gs1.VerticalAlignment = VerticalAlignment.Stretch;
            gs1.Width = 5; //or whatever other height you desire.

            var gs2 = new GridSplitter();
            gs2.HorizontalAlignment = HorizontalAlignment.Center;
            gs2.VerticalAlignment = VerticalAlignment.Stretch;
            gs2.Width = 5; //or whatever other height you desire.

            Grid.SetColumn(txt1, 1);
            Grid.SetColumn(gs1, 2);
            Grid.SetColumn(txt2, 3);
            Grid.SetColumn(gs2, 4);
            Grid.SetColumn(txt3, 5);

            DynamicGrid.Children.Add(txt1);
            DynamicGrid.Children.Add(gs1);
            DynamicGrid.Children.Add(txt2);
            DynamicGrid.Children.Add(gs2);
            DynamicGrid.Children.Add(txt3);

            // Display grid into a Window
            this.Children.Add(DynamicGrid);
            MeasureOverride(new Size(ActualWidth, ActualHeight));
            ArrangeOverride(new Size(ActualWidth, ActualHeight));
        }
    }
}
