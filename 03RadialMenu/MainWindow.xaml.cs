using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace _03RadialMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.ImageTransitionCommand = new DelegateCommand(this.OnImageTransitionCommandExecuted);
            this.radTransitionControl.Content = this.sampleImageFolder + "mainImage.jpg";
        }

        private readonly string sampleImageFolder = "/_03RadialMenu;component/Images/Customization/";
        private string lastImage;

        private void OnImageTransitionCommandExecuted(object param)
        {
            var currentImage = (string)param;
            if (currentImage != this.lastImage)
            {
                this.radTransitionControl.Content = this.sampleImageFolder + currentImage + ".jpg";
            }

            this.lastImage = currentImage;
        }

        public ICommand ImageTransitionCommand
        {
            get;
            private set;
        }
    }
}
