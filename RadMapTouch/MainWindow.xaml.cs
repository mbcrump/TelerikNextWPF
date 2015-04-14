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

namespace RadMapTouch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ImagePathFormat = "/RadMapTouch;component/Images/{0}.png";

        public MainWindow()
        {
            InitializeComponent();

            this.RadMap1.InitializeCompleted += new EventHandler(RadMap1_InitializeCompleted);
        }

        private void RadMap1_InitializeCompleted(object sender, EventArgs e)
        {
            // remove the default zoom levels
            this.RadMap1.MapZoomBar.Commands.Clear();

            this.AddCustomZoomAction(15, "Downtown");
            this.AddCustomZoomAction(18, "Neighborhood");
            this.AddCustomZoomAction(20, "Block");
        }

        private void AddCustomZoomAction(int zoomLevel, string label)
        {
            string imagePath = string.Format(ImagePathFormat, label);
            this.RadMap1.MapZoomBar.RegisterSetZoomLevelCommand(zoomLevel,
                label,
                this.LayoutRoot.Resources["CustomCommandDataTemplate"] as DataTemplate,
                new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }
    }
}
