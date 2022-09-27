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

namespace DeweyHaveFun
{
    
    public partial class ReplaceBooksSuccess : Window
    {
        public int correctNumbers;
        public ReplaceBooksSuccess()
        {

        InitializeComponent();

            
            ReplaceBooks rp = new ReplaceBooks();
            
            //lblWin.Content = "You successfully got " + correctNumbers+ rp.timed + "correct";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            this.Close();
            
        }
    }
}
