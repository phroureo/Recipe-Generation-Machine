using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for CreateRecipeStart.xaml
    /// </summary>
    public partial class CreateRecipeStart : Page
    {
        public CreateRecipeStart()
        {
            InitializeComponent();
        }

        private void nxtBtn_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["rdb"].ToString()))
            using (SqlCommand com = new SqlCommand("dbo.sp_AddNewRecipe", conn))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@recipeName", SqlDbType.NVarChar).Value = nameTbox.Text;
                com.Parameters.Add("@recipeDesc", SqlDbType.NVarChar).Value = descTbox.Text;
                com.Parameters.Add("@recSource", SqlDbType.NVarChar).Value = sourceTbox;
                com.Parameters.Add("@status", SqlDbType.NVarChar).Direction = ParameterDirection.Output;
                com.Parameters.Add("@recID", SqlDbType.Int).Direction = ParameterDirection.Output;

                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();

                Globals.CurrentRecipeID = Convert.ToInt32(com.Parameters["@recID"].Value);
                Globals.StatusValue = com.Parameters["@status"].Value.ToString();
            }
            NavigationService.Navigate(new Uri("CreateStart.xaml", UriKind.Relative));
        }
    }
}
