using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _06RadChartViewDrillDown.ViewModels;
using _06RadChartViewDrillDown.ChartUtilities;

namespace _06RadChartViewDrillDown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point? touchDownPoint;

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainViewModel();
            this.chart1.TouchDown += MainWindow_TouchDown;
            this.chart1.TouchMove += MainWindow_TouchMove;
            this.chart1.TouchUp += MainWindow_TouchUp;

        }

        private void MainWindow_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            this.touchDownPoint = e.GetTouchPoint(this).Position;
        }

        private void MainWindow_TouchMove(object sender, System.Windows.Input.TouchEventArgs e)
        {
            if (this.touchDownPoint.HasValue)
            {
                Point pos = e.GetTouchPoint(this).Position;
                if (this.touchDownPoint.Value.X - pos.X >= 200)
                {
                    this.DrillUp();
                    this.touchDownPoint = null;
                }
                else if (pos.X - this.touchDownPoint.Value.X >= 200)
                {
                    this.DrillDown();
                    this.touchDownPoint = null;
                }
            }
        }

        private void MainWindow_TouchUp(object sender, System.Windows.Input.TouchEventArgs e)
        {
            this.touchDownPoint = null;
        }

        private void DrillUp()
        {
            MainViewModel vm = this.DataContext as MainViewModel;
            if (vm != null)
            {
                vm.DrillUp();
            }
        }

        private void DrillDown()
        {
            MainViewModel vm = this.DataContext as MainViewModel;
            if (vm != null)
            {
                vm.DrillDown();
            }
        }


        private void ChartSelectionBehavior_SelectionChanged(object sender, Telerik.Windows.Controls.ChartView.ChartSelectionChangedEventArgs e)
        {
            this.Dispatcher.BeginInvoke((Action)(() =>
            {
                MainViewModel vm = (MainViewModel)this.DataContext;
                if (vm != null && e.AddedPoints.Count > 0)
                {
                    vm.HandleItemClicked(e.AddedPoints[0].DataItem);
                }
            }));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.DrillUp();
        }

        private void ButtonForward_Click(object sender, RoutedEventArgs e)
        {
            this.DrillDown();
        }
    }
}
