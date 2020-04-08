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

namespace Recipe_Generation_Machine
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
            int recipeID;
        }


        private void findRecipe_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("FindStart.xaml", UriKind.Relative));
        }

        private void addRecipe_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("CreateStart.xaml", UriKind.Relative));
        }
    }
}
