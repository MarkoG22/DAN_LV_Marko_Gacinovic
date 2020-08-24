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

        /// <summary>
        /// method for disabling user controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// method for enabling user controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            cmbSize.IsEnabled = true;
            cbSalami.IsEnabled = true;
            cbHam.IsEnabled = true;
            cbKulen.IsEnabled = true;
            cbKetchup.IsEnabled = true;
            cbMayonnaise.IsEnabled = true;
            cbHotPepper.IsEnabled = true;
            cbOlives.IsEnabled = true;
            cbOregano.IsEnabled = true;
            cbSesame.IsEnabled = true;
            cbCheese.IsEnabled = true;

            //cmbSize = null;
            //cbSalami = null;
            //cbHam = null;
            //cbKulen = null;
            //cbKetchup = null;
            //cbMayonnaise = null;
            //cbHotPepper = null;
            //cbOlives = null;
            //cbOregano = null;
            //cbSesame = null;
            //cbCheese = null;
        }
    }
}
