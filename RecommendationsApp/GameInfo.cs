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
    public partial class GameInfo : Form
    {
        public GameInfo()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm= new MainForm();
            mainForm.ShowDialog();
        }
    }
}
