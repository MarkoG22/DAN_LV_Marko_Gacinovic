using PanPizza.ViewModel;
using System.Windows;

namespace PanPizza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            cmbSize.IsEnabled = false;
            cbSalami.IsEnabled = false;
            cbHam.IsEnabled = false;
            cbKulen.IsEnabled = false;
            cbKetchup.IsEnabled = false;
            cbMayonnaise.IsEnabled = false;
            cbHotPepper.IsEnabled = false;
            cbOlives.IsEnabled = false;
            cbOregano.IsEnabled = false;
            cbSesame.IsEnabled = false;
            cbCheese.IsEnabled = false;
        }        
    }
}
