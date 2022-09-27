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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeweyHaveFun
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List list;

        public MainWindow()
        {
            

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IdentifyingAreas ia = new IdentifyingAreas();
            ia.Show();
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bookBtn_Click(object sender, RoutedEventArgs e)
        {
            ReplaceBooks replace = new ReplaceBooks();
            this.Close();
            replace.Show();
        }

        private void callNumberBtn_Click(object sender, RoutedEventArgs e)
        {
            CallNumbers cn = new CallNumbers();
            cn.Show();
        }
    }
}
