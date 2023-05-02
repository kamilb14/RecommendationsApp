using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RecommendationsApp
{
    public partial class LoginForm : Form
    {

        DataBase database = new DataBase();
        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration registration= new Registration();
            this.Hide();
            registration.ShowDialog();
        }

        public static string email;
        private void button1_Click(object sender, EventArgs e)
        {
            email = UserEmailTB.Text;
            textBox2.UseSystemPasswordChar = true;
            var password = textBox2.Text;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            DataTable dt = new DataTable();

            string querystring = $"select User_ID, Email, Password from dbo.Users where Email = '{email}' and Password = {password}";
            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            sqlDataAdapter.SelectCommand = command;
            sqlDataAdapter.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Вход выполнен!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm mainform = new MainForm();
                this.Hide();
                mainform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Такого аккаунта не существует!", "Не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }





        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.Transparent;
        }

        Point lastPoint;
        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint= new Point(e.X, e.Y);
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            this.Hide();
            mf.ShowDialog();
        }

       
    }
}
   
