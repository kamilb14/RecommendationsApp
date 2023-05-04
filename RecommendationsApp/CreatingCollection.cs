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

namespace RecommendationsApp
{
    public partial class CreatingCollection : Form
    {
        
        public CreatingCollection()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            DataBase dataBase = new DataBase();

            var email = textBox2.Text;
            var collectionname = textBox1.Text;


            string collectionadd = $" insert into Collection (CollectionName, Email) values ('{collectionname}', '{email}')";
            SqlCommand command = new SqlCommand(collectionadd, dataBase.getConnection());

            dataBase.openConnetion();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Подборка успешно добавлена", "Успех");
                MainForm mf = new MainForm();
                this.Hide();
                mf.ShowDialog();    
            } 
            else
            {
                MessageBox.Show("Игра не добавлена");
            }
            dataBase.closeConnetion();

        }
    }
}
