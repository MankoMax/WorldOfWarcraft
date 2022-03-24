using System.Windows;

namespace WorldofWarcraft
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new RegPage();
        }
    }
}
