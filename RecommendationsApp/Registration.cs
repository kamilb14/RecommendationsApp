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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RecommendationsApp
{
    public partial class Registration : Form
    {

        DataBase database = new DataBase();
        public Registration()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable table = new DataTable();
            DataBase dataBase = new DataBase();
            if (CheckingUser())

            {
                return;
            }

            var firstname = textBox1.Text;
            var lastname = textBox3.Text;
            var email = textBox2.Text;
            var password = textBox4.Text;

            int a = 0;
            switch(comboBox1.SelectedItem)
            {
                case "Приключения":
                    a= 1;
                    break;

                case "Действие":
                    a= 2;
                    break;

                case "Симулятор":
                    a= 3;
                    break;

                case "Стратегия":
                    a= 4;
                    break;

                case "Головоломка":
                    a= 5;
                    break;

                case "Ролевая игра":
                    a= 6;
                    break;

                case "Выживание":
                    a= 7;
                    break;

            }


            int b = 0;
            switch(comboBox5.SelectedItem)
            {
                case "2010":
                    b= 1;
                    break;
                case "2011":
                    b= 2;
                    break;
                case "2012":
                    b= 3;
                    break;
                case "2013":
                    b= 4;
                    break;
                case "2014":
                    b= 5;
                    break;
                case "2015":
                    b= 6;
                    break;
                case "2016":
                    b= 7;
                    break;
                case "2017":
                    b= 8;
                    break;
                case "2018":
                    b= 9;
                    break;
                case "2019":
                    b= 10;
                    break;
                case "2020":
                    b= 11;
                    break;
                case "2021":
                    b= 12;
                    break;
                case "2022":
                    b= 13;
                    break;
            }

            int c = 0;
            switch(comboBox3.SelectedItem)
            {
                case "0":
                    c= 1;
                    break;
                case "499":
                    c= 2;
                    break;
                case "999":
                    c= 3;
                    break;
                case "1499":
                    c= 4;
                    break;
                case "1999":
                    c= 5;
                    break;
                case "2499":
                    c= 6;
                    break;
                case "2999":
                    c= 7;
                    break;
                case "3499":
                    c= 8;
                    break;
                case "3999":
                    c= 9;
                    break;
                case "4499":
                    c= 10;  
                    break;
                case "4999":
                    c= 11;
                    break;
                       
            }

            int d = 0;
            switch(comboBox2.SelectedItem)
            {
                case "6":
                    d = 1;
                    break;
                case "12":
                    d = 2;
                    break;
                case "16":
                    d = 3;
                    break;
                case "18":
                    d = 4;
                    break;
            }

            int h = 0;
            switch(comboBox4.SelectedItem)
            {
                case "Да":
                    h = 1;
                    break;
                case "Нет":
                    h = 2;
                    break;
            }








            string queryregistration = $" insert into Users( FirstName, LastName, Email, Password, Genre_ID, Year_ID, Price_ID, Age_ID, Gamepad_ID) values ('{firstname}', '{lastname}', '{email}', '{password}', '{a}', '{b}', '{c}', '{d}', '{h}')";
            SqlCommand command = new SqlCommand(queryregistration, dataBase.getConnection());

            dataBase.openConnetion();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Регистрация прошла успешно!", "Успех!");
                LoginForm login = new LoginForm();
                login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан");
            }
            dataBase.closeConnetion();
        }

        private Boolean CheckingUser()
        {
            var email = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querychecking = $"select User_ID, FirstName, Email, Password from dbo.Users where Email = '{email}'";

            SqlCommand command = new SqlCommand(querychecking, database.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Этот E-mail уже закреплен за другим пользователем!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}