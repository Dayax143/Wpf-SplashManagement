using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfSplashScreen_Licensing_
{
    /// <summary>
    /// Interaction logic for winSplash.xaml
    /// </summary>
    public partial class winSplash : Window
    {
        public winSplash()
        {
            InitializeComponent();
        }

        public void UpdateStatus(string message, int progress)
        {
            StatusText.Text = message;
            LoadingBar.Value = progress;
        }
    }
}
