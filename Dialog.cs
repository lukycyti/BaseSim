using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseSim2021
{
    public partial class Dialog : Form
    {
        public IndexedValue iV;

        public int NewValue;


        public Dialog(IndexedValueView iVV, Boolean policy)
        {
            iV = iVV.getIndexedValue();
            InitializeComponent();
            ValueDescritpion.AutoSize = true;
            ValueDescritpion.TextAlign = ContentAlignment.MiddleCenter;
            //ValueDescritpion.Dock = DockStyle.Fill
            
            ValueName.Text = iV.Name;
            ValueDescritpion.Text = iV.Description;
            
            if (policy)
            {
                numericUpDown1.Value = iV.Value;
                numericUpDown1.Maximum = iV.MaxValue;
                numericUpDown1.Minimum = iV.MinValue;
            } 
            else
            {
                numericUpDown1.Hide();
                button1.Hide();
                button2.Hide();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NewValue = (int)numericUpDown1.Value;
        }

        private void Dialog_Load(object sender, EventArgs e)
        {

        }
    }
}
