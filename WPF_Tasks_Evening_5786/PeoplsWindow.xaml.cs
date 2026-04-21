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
using WPF_Tasks_Evening_5786.Models;

namespace WPF_Tasks_Evening_5786
{
    /// <summary>
    /// Interaction logic for PeoplsWindow.xaml
    /// </summary>
    public partial class PeoplsWindow : Window
    {
        public PeoplsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Models.PesachTasksDbContext ctx = new PesachTasksDbContext())
                {
                    var list = ctx.People .ToList();    
                    dgListOfPeople.ItemsSource = list; 
                }

            }
            catch
            {

            }
        }
    }
}
