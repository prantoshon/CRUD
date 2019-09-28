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
    public partial class CustomerUi : Form
    {
        public CustomerUi()
        {
            InitializeComponent();

        }

        private void CustomerUi_Load(object sender, EventArgs e)
        {
           
        }

        private void itemUIButton_Click(object sender, EventArgs e)
        {
            ItemUI itemUi = new ItemUI();
            itemUi.Show();
            this.Hide();
        }



        private void AddCustomer()
        {


            if (!String.IsNullOrEmpty(nameTextBox.Text))
            {
                if (!String.IsNullOrEmpty(addressTextBox.Text))
                {


                    try
                    {
                        //Conncetion
                        string conncetionString = @"Server=DESKTOP-QREDJ0M; DATABASE=MyDataBase; Integrated Security=TRUE";
                        SqlConnection sqlConnection = new SqlConnection(conncetionString);

                        //sqlquery
                        string commandString = "INSERT INTO Customers(CustomerName,CustomerAddress ,CustomerNumber) VALUES('" + nameTextBox.Text+ "','" + addressTextBox.Text + "','"+numberTextBox.Text+"')";
                        SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                        //Excution
                        sqlConnection.Open();

                        int isExcuted = sqlCommand.ExecuteNonQuery();
                        if (isExcuted > 0)
                        {
                            MessageBox.Show("Saved");
                            customerIdTextBox.Clear();
                            nameTextBox.Clear();
                            addressTextBox.Clear();
                            numberTextBox.Clear();
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
                    MessageBox.Show("Address is Empty");
                }
            }
            else
            {
                MessageBox.Show("Name is Empty");
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
                string command = "SELECT *FROM Customers";
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
                    customerIdTextBox.Clear();
                    nameTextBox.Clear();
                    addressTextBox.Clear();
                    numberTextBox.Clear();
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
                string command = "DELETE FROM Customers WHERE Id ='" + customerIdTextBox.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConncetion);

                //excute 
                sqlConncetion.Open();
                int isExcuted = sqlCommand.ExecuteNonQuery();
                if (isExcuted > 0)
                {
                    MessageBox.Show("Delete");
                    customerIdTextBox.Clear();
                    nameTextBox.Clear();
                    addressTextBox.Clear();
                    numberTextBox.Clear();
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
                string command = "UPDATE Customers  SET CustomerName ='" + nameTextBox.Text + "' , CustomerAddress ='" +addressTextBox.Text + "', CustomerNumber ='"+numberTextBox.Text+"' WHERE Id ='" + customerIdTextBox.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConncetion);

                //Exute
                sqlConncetion.Open();
                int isExcuted = sqlCommand.ExecuteNonQuery();
                if (isExcuted > 0)
                {
                    MessageBox.Show("Upadte");
                    customerIdTextBox.Clear();
                    nameTextBox.Clear();
                    addressTextBox.Clear();
                    numberTextBox.Clear();
                 
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

        private void SeachInformation()
        {

            try
            {
                string conncetion = @"Server=DESKTOP-QREDJ0M; DATABASE=MyDataBase; Integrated Security=TRUE";
                SqlConnection sqlConncetion = new SqlConnection(conncetion);

                string command = "SELECT * FROM Customers Where CustomerName = '" + searchIdTextBox.Text + "'";
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
            AddCustomer();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowAllInformation();

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
            SeachInformation();
        }

        private void orderPageButton_Click(object sender, EventArgs e)
        {
            OrderUi orderUi = new OrderUi();
            orderUi.Show();
            this.Hide();
        }




    }
}
