using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecommendationsApp
{
    public partial class MainForm : Form
    {
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

            // Here we define the height of each item on your list.


            // Here i will just make an example data source, to emulate the control you are trying to reproduce.
            var dataSet = new List<Tuple<string, string, string>>();

            dataSet.Add(new Tuple<string, string, string>("Minecraft", "Sandbox", "1000 руб"));
            dataSet.Add(new Tuple<string, string, string>("Sally face", "Adventure", "2000 руб"));

            listBox1.DataSource = dataSet;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // This variable will hold the color of the bottom text - the one saying the count of 
            // the avaliable rooms in your example.
            Brush roomsBrush;

            // Here we override the DrawItemEventArgs to change the color of the selected 
            // item background to one of our preference.
            // I changed to SystemColors.Control, to be more like the list you are trying to reproduce.
            // Also, as I see in your example, the font of the room text part is black colored when selected, and gray
            // colored when not selected. So, we are going to reproduce it as well, by setting the correct color
            // on our variable defined above.
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

            // Looking more at your example, i noticed a gray line at the bottom of each item.
            // Lets reproduce that, too.
            var linePen = new Pen(SystemBrushes.Control);
            var lineStartPoint = new Point(e.Bounds.Left, e.Bounds.Height + e.Bounds.Top);
            var lineEndPoint = new Point(e.Bounds.Width, e.Bounds.Height + e.Bounds.Top);


            // Command the event to draw the appropriate background of the item.
            e.DrawBackground();

            // Here you get the data item associated with the current item being drawed.
            var dataItem = listBox1.Items[e.Index] as Tuple<string, string, string>;

            // Here we will format the font of the part corresponding to the Time text of your list item.
            // You can change to wathever you want - i defined it as a bold font.
            var timeFont = new Font("Microsoft Sans Serif", 10.25f, FontStyle.Bold);

            // Here you draw the time text on the top of the list item, using the format you defined.
            e.Graphics.DrawString(dataItem.Item1, timeFont, Brushes.WhiteSmoke, e.Bounds.Left + 3, e.Bounds.Top + 5);

            // Now we draw the avaliable rooms part. First we define our font.
            var roomsFont = new Font("Microsoft Sans Serif", 10.25f, FontStyle.Regular);

            var priceFont = new Font("Microsoft Sans Serif", 10.25f, FontStyle.Regular);

            // And, finally, we draw that text.
            e.Graphics.DrawString(dataItem.Item2, roomsFont, roomsBrush, e.Bounds.Left + 3, e.Bounds.Top + 24);

            e.Graphics.DrawString(dataItem.Item3, priceFont, Brushes.WhiteSmoke, e.Bounds.Left + 500, e.Bounds.Top + 38);
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
