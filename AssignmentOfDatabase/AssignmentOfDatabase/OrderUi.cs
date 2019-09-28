using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentOfDatabase
{
    public partial class OrderUi : Form
    {
        public OrderUi()
        {
            InitializeComponent();
        }


        private void AddOrder()
        {


            if (!String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                if (!String.IsNullOrEmpty(priceTextBox.Text))
                {


                    try
                    {
                        //Conncetion
                        string conncetionString = @"Server=DESKTOP-QREDJ0M; DATABASE=MyDataBase; Integrated Security=TRUE";
                        SqlConnection sqlConnection = new SqlConnection(conncetionString);

                        //sqlquery
                        string commandString = "INSERT INTO Orders(ItemName, Price, Quanity ) VALUES('" + itemNameTextBox.Text + "','" + priceTextBox.Text + "','"+quantityTextBox.Text+"')";
                        SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                        //Excution
                        sqlConnection.Open();

                        int isExcuted = sqlCommand.ExecuteNonQuery();
                        if (isExcuted > 0)
                        {
                            MessageBox.Show("Saved");
                            orderIdTextBox.Clear();
                            itemNameTextBox.Clear();
                            priceTextBox.Clear();
                            quantityTextBox.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Not Saved");
                        }

                        sqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
                else
                {
                    MessageBox.Show("Price is Empty");
                }
            }
            else
            {
                MessageBox.Show("Item Name is Empty");
            }

        }


        private void ShowAllInformation()
        {

            try
            {
                //conncetion
                string conncetion = @"Server=DESKTOP-QREDJ0M; DATABASE= MyDataBase; Integrated Security=TRUE";
                SqlConnection sqlConncetion = new SqlConnection(conncetion);

                //command
                string command = "SELECT *FROM Orders";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConncetion);

                //excute
                sqlConncetion.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                //show
                if (dataTable.Rows.Count > 0)
                {

                    displayDataGridView.DataSource = dataTable;
                    orderIdTextBox.Clear();
                    itemNameTextBox.Clear();
                    priceTextBox.Clear();
                    quantityTextBox.Clear();
                }
                else
                {

                    MessageBox.Show("Data Empty");
                }
                sqlConncetion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void DeleteData()
        {
            try
            {
                //conncention
                string conncetion = @"Server=DESKTOP-QREDJ0M; DATABASE=MyDataBase;Integrated Security=TRUE";
                SqlConnection sqlConncetion = new SqlConnection(conncetion);

                //command
                string command = "DELETE FROM Orders WHERE OrderId ='" + orderIdTextBox.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConncetion);

                //excute 
                sqlConncetion.Open();
                int isExcuted = sqlCommand.ExecuteNonQuery();
                if (isExcuted > 0)
                {
                    MessageBox.Show("Delete");
                    orderIdTextBox.Clear();
                    itemNameTextBox.Clear();
                    priceTextBox.Clear();
                    quantityTextBox.Clear();
                    
                }
                else
                {
                    MessageBox.Show("Not Deleted");
                }
                sqlConncetion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void UpdateInformation()
        {
            try
            {
                //conncetion
                string conncetion = @"Server=DESKTOP-QREDJ0M; DATABASE=MyDataBase; Integrated Security=TRUE";
                SqlConnection sqlConncetion = new SqlConnection(conncetion);

                //command
                string command = "UPDATE Orders  SET ItemName ='" + itemNameTextBox.Text + "' ,  Price ='" + priceTextBox.Text + "' ,Quanity='" + quantityTextBox.Text + "' WHERE OrderId ='" + orderIdTextBox.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConncetion);

                //Exute
                sqlConncetion.Open();
                int isExcuted = sqlCommand.ExecuteNonQuery();
                if (isExcuted > 0)
                {
                    MessageBox.Show("Upadte");
                    orderIdTextBox.Clear();
                    itemNameTextBox.Clear();
                    priceTextBox.Clear();
                    quantityTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Not Upadated");
                }
                sqlConncetion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void SearchInformation()
        {

            try
            {
                string conncetion = @"Server=DESKTOP-QREDJ0M; DATABASE=MyDataBase; Integrated Security=TRUE";
                SqlConnection sqlConncetion = new SqlConnection(conncetion);

                string command = "SELECT * FROM Orders Where OrderId = '" + searchIdTextBox.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConncetion);

                sqlConncetion.Open();
                SqlDataAdapter sqlDataAdapater = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapater.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    displayDataGridView.DataSource = dataTable;
                    MessageBox.Show("Search Match");
                    searchIdTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Search  Not Match");
                }
                sqlConncetion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }



        private void addButton_Click(object sender, EventArgs e)
        {
            AddOrder();
        }

        private void customerPageButton_Click(object sender, EventArgs e)
        {
            CustomerUi customerUi = new CustomerUi();
            customerUi.Show();
            this.Hide();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowAllInformation();
        }

        private void itemUIButton_Click(object sender, EventArgs e)
        {
            ItemUI itemUi = new ItemUI();
            itemUi.Show();
            this.Hide();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void upadteButton_Click(object sender, EventArgs e)
        {
            UpdateInformation();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchInformation();
        }
    }
}
