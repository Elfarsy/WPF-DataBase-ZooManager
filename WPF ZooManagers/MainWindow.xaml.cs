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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WPF_ZooManagers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SqlConnection sqlconnection;
        public MainWindow()
        {
            InitializeComponent();

            string connectionstring = ConfigurationManager.ConnectionStrings["WPF_ZooManagers.Properties.Settings.PanjututorialsDBConnectionString"].ConnectionString; //A VERT FUCKING IMPORTANT CODE
            sqlconnection = new SqlConnection(connectionstring);
            ShowZoos(); // the method which we have defined above in Private 
            ShowAllAnimals(); //private method we have done above
        }
        private void ShowAllAnimals()
        {
            try
            {
                string query = "select * from Animal";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {
                    DataTable animal = new DataTable();
                    sqlDataAdapter.Fill(animal); ///////////////////////////////////////////ATTENTION FOR THE TABLE NAME

                    listAllAnimals.DisplayMemberPath = "Name";
                    listAllAnimals.SelectedValuePath = "Id";
                    listAllAnimals.ItemsSource = animal.DefaultView; /////////////////////////////

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


        }
        private void ShowZoos()
        {
            //It's always good option to use Databases with try and catch 
            try
            {
                string query = "select * from Zoo";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);
                using (sqlDataAdapter)
                {
                    DataTable zooTable = new DataTable();

                    sqlDataAdapter.Fill(zooTable);
                    //Which information of the table in the dataTavle should be shown in our ListBox
                    ListZoos.DisplayMemberPath = "Location"; //Content we want to see
                                                             //Which Value should be delivied . when an item from our ListBox is selected
                    ListZoos.SelectedValuePath = "Id"; //Value vehind specific item
                                                       //The Reference to the data the listbox should populate 
                    ListZoos.ItemsSource = zooTable.DefaultView; //Zoo Table is Default view Easily


                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void ShowAssociatedAnimals()
        {
            //It's always good option to use Databases with try and catch 
            try
            {
                string query = "select * from Animal a inner join ZooAnimal " +
                "za on a.Id = za.AnimalId where za.ZooId=@ZooId";
                SqlCommand sqlcommand = new SqlCommand(query, sqlconnection);

                //The sqlDataAdapter can be imagined like an interface to make tables usable by C#-Objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand); //we command query because we are running a command
                using (sqlDataAdapter)
                {
                    sqlcommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);
                    DataTable animalTable = new DataTable();

                    sqlDataAdapter.Fill(animalTable);
                    //Which information of the table in the dataTavle should be shown in our ListBox
                    ListZAssociatedAnimals.DisplayMemberPath = "Name"; //Content we want to see
                                                                       //Which Value should be delivied . when an item from our ListBox is selected
                    ListZAssociatedAnimals.SelectedValuePath = "Id"; //Value vehind specific item
                                                                     //The Reference to the data the listbox should populate 
                    ListZAssociatedAnimals.ItemsSource = animalTable.DefaultView; //Zoo Table is Default view Easily


                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
            }

        }

        private void ListZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(ListZoos.SelectedValue.ToString()); //that shows me the ID the ZooName I have wriites
            ShowAssociatedAnimals(); //this will run the private method which we wrote up to be done show
            SHowSelectedZooInTextBox();
            
        }

        private void DeleteZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Zoo where id =@ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                sqlconnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);
                sqlCommand.ExecuteScalar(); //super simple execution
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlconnection.Close();
                ShowZoos();

            }



        }

        private void AddZoo_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string query = "insert into Zoo values (@Location)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                sqlconnection.Open();
                sqlCommand.Parameters.AddWithValue("@Location", MyTextBox.Text);
                sqlCommand.ExecuteScalar(); //super simple execution
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlconnection.Close();
                ShowZoos();

            }

        }

        private void AddAnimalsToZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into ZooAnimal values (@ZooId, @AnimalId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                sqlconnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                sqlCommand.ExecuteScalar(); //super simple execution
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlconnection.Close();
                ShowAssociatedAnimals();

            }

        }

        private void RemoveAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Animal where id = @AnimalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                sqlconnection.Open();


                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);

                sqlCommand.ExecuteScalar(); //super simple execution
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlconnection.Close();
                ShowAllAnimals();

            }

        }

        private void AddAnimal(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Animal values(@Name)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                sqlconnection.Open();

                sqlCommand.Parameters.AddWithValue("@Name", MyTextBox.Text);
                sqlCommand.ExecuteScalar(); //super simple execution
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlconnection.Close();
                ShowAllAnimals();

            }

        }



        private void RemoveAnima_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from ZooAnimalvalues (@ZooId, @AnimalId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                sqlconnection.Open();

                sqlCommand.Parameters.AddWithValue("@ZooId", listAllAnimals.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);

                sqlCommand.ExecuteScalar(); //super simple execution
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlconnection.Close();
                ShowAssociatedAnimals();

            }
        }
        private void SHowSelectedZooInTextBox()
        {
            //It's always good option to use Databases with try and catch 
            try
            {
                string query = "select location from Zoo where Id=@ZooID";

                SqlCommand sqlcommand = new SqlCommand(query, sqlconnection);

                //The sqlDataAdapter can be imagined like an interface to make tables usable by C#-Objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand); //we command query because we are running a command
                using (sqlDataAdapter)
                {
                    sqlcommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);
                    DataTable zooDataTable = new DataTable();

                    sqlDataAdapter.Fill(zooDataTable);

                    MyTextBox.Text = zooDataTable.Rows[0]["Location"].ToString();

                    DataTable ListAllAnimals = new DataTable();
                    sqlDataAdapter.Fill(ListAllAnimals);
                    MyTextBox.Text = ListAllAnimals.Rows[0]["Name"].ToString();






                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
            }
        }
        private void ShowSelectedAnimal()
        {
            //It's always good option to use Databases with try and catch 
            try
            {
                string query = "select name from Animal where Id=@AnimalId";

                SqlCommand sqlcommand = new SqlCommand(query, sqlconnection);

                //The sqlDataAdapter can be imagined like an interface to make tables usable by C#-Objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand); //we command query because we are running a command
                using (sqlDataAdapter)
                {
                    sqlcommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                    DataTable animalDataTable = new DataTable();

                    sqlDataAdapter.Fill(animalDataTable);

                    MyTextBox.Text = animalDataTable.Rows[0]["Name"].ToString();

                   






                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
            }


        }
        private void ListAllAnimals(object sender, SelectionChangedEventArgs e)
        {
            
            ShowSelectedAnimal();
        }

        private void UpdateZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "update Zoo Set Location =@Location where Id=@ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                sqlconnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@Location", MyTextBox.Text);
                sqlCommand.ExecuteScalar(); //super simple execution
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlconnection.Close();
                ShowZoos();

            }
        }

        private void UpdateAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "update Animal Set Name = @Name where Id = @AnimalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                sqlconnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@Name", MyTextBox.Text);
                sqlCommand.ExecuteScalar(); //super simple execution
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlconnection.Close();
                ShowAllAnimals();

            }
        }
    }
}

        
   

