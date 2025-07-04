using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace CSharpEgitimKampiPostgreDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionString = "Server=localhost;port=5432;Database=CustomerDb;user Id=postgres;Password=root";
        void GetAllCustomers()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "select * from customer";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();

        }
        private void btnlist_Click(object sender, EventArgs e)
        {
            GetAllCustomers();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string customerName = txtad.Text; // customer namei txtboxdan alıyoruz
            string customerSurname = txtsoyad.Text; // customer surname i txtboxdan alıyoruz
            string customerCity = txtsehir.Text; // customer city i txtboxdan alıyoruz
            var connection = new NpgsqlConnection(connectionString); // bağlantı stringini kullanarak yeni bir bağlantı oluşturuyoruz
            connection.Open(); // bağlantıyı açıyoruz
            string query= "insert into customer(CustomerName,CustomerSurname,CustomerCity) values(@p1,@p2,@p3)"; // sorgumuzu yazıyoruz
            var command = new NpgsqlCommand(query, connection); // sorguyu çalıştırmak için NpgsqlCommand nesnesi oluşturuyoruz buradaki query sorgumuzu temsil ediyor conntion ise veritabanı bağlantımızı temsil ediyor
            var adapter = new NpgsqlDataAdapter(command); // NpgsqlDataAdapter nesnesi ile sorgumuzu çalıştıracağız adaptera comman ile sorgumuzu ve çalışacak veritabanı bağlantımızı veriyoruz
            command.Parameters.AddWithValue("@p1",customerName); // sorgumuzdaki parametreleri dolduruyoruz
            command.Parameters.AddWithValue("@p2",customerSurname); // sorgumuzdaki parametreleri dolduruyoruz
            command.Parameters.AddWithValue("@p3",customerCity); // sorgumuzdaki parametreleri dolduruyoruz
            command.ExecuteNonQuery(); // sorgumuzu çalıştırıyoruz ve kayıt ekliyoruz
            MessageBox.Show("eklendi la"); // ekleme işlemi başarılı ise kullanıcıya mesaj gösteriyoruz
            connection.Close(); // bağlantıyı kapatıyoruz
            GetAllCustomers(); // ekleme işlemi sonrası tüm müşterileri listelemek için GetAllCustomers metodunu çağırıyoruz

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text); // silinecek müşteri id sini txtboxdan alıyoruz
            var connection = new NpgsqlConnection(connectionString); // bağlantı stringini kullanarak yeni bir bağlantı oluşturuyoruz
            connection.Open(); // bağlantıyı açıyoruz
            string query = "delete from customer where CustomerId=@p1"; // silme sorgumuzu yazıyoruz
            var command = new NpgsqlCommand(query, connection); // sorguyu çalıştırmak için NpgsqlCommand nesnesi oluşturuyoruz buradaki query sorgumuzu temsil ediyor connection ise veritabanı bağlantımızı temsil ediyor
            var adapter = new NpgsqlDataAdapter(command);
            command.Parameters.AddWithValue("@p1", id); // sorgumuzdaki parametreyi dolduruyoruz
            command.ExecuteNonQuery(); // sorgumuzu çalıştırıyoruz ve kayıt siliyoruz
            MessageBox.Show("silindi la"); // silme işlemi başarılı ise kullanıcıya mesaj gösteriyoruz
            connection.Close(); // bağlantıyı kapatıyoruz
            GetAllCustomers(); // silme işlemi sonrası tüm müşterileri listelemek için GetAllCustomers metodunu çağırıyoruz

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "update customer set CustomerName =@p1,CustomerSurname=@p2,CustomerCity=@p3 where CustomerId=@p4"; // güncelleme sorgumuzu yazıyoruz
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            command.Parameters.AddWithValue("@p1", txtad.Text);
            command.Parameters.AddWithValue("@p2", txtsoyad.Text);
            command.Parameters.AddWithValue("@p3", txtsehir.Text);
            command.Parameters.AddWithValue("@p4", int.Parse( txtID.Text));
            command.ExecuteNonQuery();
            MessageBox.Show("güncellendi la");
            connection.Close();
            GetAllCustomers(); // güncelleme işlemi sonrası tüm müşterileri listelemek için GetAllCustomers metodunu çağırıyoruz
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_id_getir_Click(object sender, EventArgs e)
        {

        }

        private void txtsehir_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtsoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}


