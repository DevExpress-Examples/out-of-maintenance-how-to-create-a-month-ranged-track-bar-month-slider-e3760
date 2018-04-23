using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;

namespace MonthSliderExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Text = monthRangeTrackBar1.MonthRangeValue.ToString();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            monthRangeTrackBar1.Properties.InitialDateValue = (DateTime)dateEdit1.EditValue;
        }
    }
}
