using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace CSharpEgitimKampiPostgreDb
{
    public partial class FrmEmploye : Form
    {
        public FrmEmploye()
        {
            InitializeComponent();
        }
        string connectionString = "Server=localhost;port=5432;Database=CustomerDb;user Id=postgres;Password=root";

        void GetallEmployes()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "select * from employees";
            var command = new NpgsqlCommand(query, connection);
            var dataadapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataadapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        void DepartmentList()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "select * from Deparments";
            var command = new NpgsqlCommand(query, connection);
            var dataadapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataadapter.Fill(dataTable);
            cmbDepartment.DisplayMember = "DepartmenName";
            cmbDepartment.ValueMember = "DepartmentId";
            cmbDepartment.DataSource = dataTable;
            connection.Close();
     
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            string employeeName = txtad.Text;
            string employeeSurname = txtsoyad.Text;
            decimal employeeSalary = decimal.Parse( txtmaas.Text);
            int departmentid = int.Parse(cmbDepartment.SelectedValue.ToString());
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "insert into employees (EmployeeName,EmployeeSurname,EmployeeSalary,DepartmentId)values (@p1,@p2,@p3,@p4)";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@p1", employeeName);
            command.Parameters.AddWithValue("@p2", employeeSurname);
            command.Parameters.AddWithValue("@p3", employeeSalary);
            command.Parameters.AddWithValue("@p4", departmentid);
            command.ExecuteNonQuery();
            MessageBox.Show("eklendi");
            connection.Close();
            GetallEmployes();




        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            GetallEmployes();
        }

        private void FrmEmploye_Load(object sender, EventArgs e)
        {
            GetallEmployes();
            DepartmentList();
        }
    }
}
