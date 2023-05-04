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

namespace RecommendationsApp
{
    public partial class MainForm : Form
    {

        public class Games
        {
            public int Id;
            public string Genre;
            public string Year;
            public string Price;
            public string Age;
            public string Gamepad;
            public string Name;
        }
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            listBox1.ItemHeight = 70;
            listBox1.DrawItem += listBox1_DrawItem;
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<Games> listofgames = new List<Games>();
            string connectionString = @"Data Source = recommapp.mssql.somee.com;" + "Initial Catalog = recommapp;" + "User id =AkhKamil_SQLLogin_1;" + "Password = bnyxhv5sxr;";

            string sqlExpression = "SELECT * FROM Games";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) 
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        Games gm = new Games();
                        gm.Id = Convert.ToInt32(reader.GetValue(0));
                        switch(Convert.ToInt32(reader.GetValue(1)))
                        {
                            case 1:
                                gm.Genre = "приключения";
                                break;
                            case 2:
                                gm.Genre = "действие";
                                break;
                            case 3:
                                gm.Genre = "симулятор";
                                break;
                            case 4:
                                gm.Genre = "стратегия";
                                break;
                            case 5:
                                gm.Genre = "головоломка";
                                break;
                            case 6:
                                gm.Genre = "ролевая игра";
                                break;
                            case 7:
                                gm.Genre = "выживание";
                                break;

                        }

                        switch (Convert.ToInt32(reader.GetValue(2)))
                        {
                            case 1:
                                gm.Year = "2010";
                                break;
                            case 2:
                                gm.Year = "2011";
                                break;
                            case 3:
                                gm.Year = "2012";
                                break;
                            case 4:
                                gm.Year = "2013";
                                break;
                            case 5:
                                gm.Year = "2014";
                                break;
                            case 6:
                                gm.Year = "2015";
                                break;
                            case 7:
                                gm.Year = "2016";
                                break;
                            case 8:
                                gm.Year = "2017";
                                break;
                            case 9:
                                gm.Year = "2018";
                                break;
                            case 10:
                                gm.Year = "2019";
                                break;
                            case 11:
                                gm.Year = "2020";
                                break;
                            case 12:
                                gm.Year = "2021";
                                break;
                            case 13:
                                gm.Year = "2022";
                                break;
                        }

                        switch (Convert.ToInt32(reader.GetValue(3)))
                        {
                            case 1:
                                gm.Price = "0 руб";
                                break;
                            case 2:
                                gm.Price = "499 руб";
                                break;
                            case 3:
                                gm.Price = "999 руб";
                                break;
                            case 4:
                                gm.Price = "1499 руб";
                                break;
                            case 5:
                                gm.Price = "1999 руб";
                                break;
                            case 6:
                                gm.Price = "2499 руб";
                                break;
                            case 7:
                                gm.Price = "2999 руб";
                                break;
                            case 8:
                                gm.Price = "3499 руб";
                                break;
                            case 9:
                                gm.Price = "3999 руб";
                                break;
                            case 10:
                                gm.Price = "4499 руб";
                                break;
                            case 11:
                                gm.Price = "4999 руб";
                                break;

                        }


                        switch (Convert.ToInt32(reader.GetValue(4)))
                        {
                            case 1:
                                gm.Age = "6+";
                                break;
                            case 2:
                                gm.Age = "12+";
                                break;
                            case 3:
                                gm.Age = "16+";
                                break;
                            case 4:
                                gm.Age = "18+";
                                break;
                        }

                        switch (Convert.ToInt32(reader.GetValue(5)))
                        {
                            case 1:
                                gm.Gamepad = "да";
                                break;
                            case 2:
                                gm.Gamepad = "нет";
                                break;
                        }

                        gm.Name = reader.GetValue(6).ToString();

                        listofgames.Add(gm);
                        continue;

                    }
                }
                reader.Close();
            }

            listBox1.DataSource = listofgames;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {

            Brush roomsBrush;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds,
                    e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, Color.FromArgb(42,41,51)) ;

                roomsBrush = Brushes.Gray;
            }
            else
            {
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Default, e.ForeColor, Color.FromArgb(19, 18, 31));
                roomsBrush = Brushes.Gray;
            }

            var linePen = new Pen(SystemBrushes.Control);
            var lineStartPoint = new Point(e.Bounds.Left, e.Bounds.Height + e.Bounds.Top);
            var lineEndPoint = new Point(e.Bounds.Width, e.Bounds.Height + e.Bounds.Top);

            e.DrawBackground();

            Games dataItem = listBox1.Items[e.Index] as Games;
            var timeFont = new Font("Microsoft Sans Serif", 10.25f, FontStyle.Bold);

            e.Graphics.DrawString(dataItem.Name, timeFont, Brushes.WhiteSmoke, e.Bounds.Left + 3, e.Bounds.Top + 5);


            var roomsFont = new Font("Microsoft Sans Serif", 10.25f, FontStyle.Regular);
            var priceFont = new Font("Microsoft Sans Serif", 10.25f, FontStyle.Regular);

            // And, finally, we draw that text.
            e.Graphics.DrawString(dataItem.Genre, roomsFont, roomsBrush, e.Bounds.Left + 3, e.Bounds.Top + 24);

            e.Graphics.DrawString(dataItem.Price, priceFont, Brushes.WhiteSmoke, e.Bounds.Left + 500, e.Bounds.Top + 38);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreatingOffer creatingOffer= new CreatingOffer();
            creatingOffer.ShowDialog();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(pictureBox3, "Добавить предложение");
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(pictureBox5, "Поиск");
        }
    }
}
