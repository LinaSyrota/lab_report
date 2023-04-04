using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ICalculator _base = new Greenhouse(double.Parse(textBox1.Text), double.Parse(textBox2.Text));

            List<double> result = _base.calculate(); // площа і кількість води в годину
            string mes = _base.message(result);

            if (checkBox1.Checked)
            {
                ICalculator mainP = new Main_Pipeline(_base, double.Parse(textBox3.Text));

                mes += mainP.message(mainP.calculate());
            }
            if (checkBox2.Checked)
            {
                ICalculator pump = new Pump(_base);

                mes += pump.message(pump.calculate());
            }
            if (checkBox3.Checked)
            {
                ICalculator dropper = new Dropper(_base, double.Parse(textBox1.Text), double.Parse(textBox2.Text));

                mes += dropper.message(dropper.calculate());
            }
            if (checkBox4.Checked)
            {
                ICalculator tubes = new Tubes(new Dropper(_base, double.Parse(textBox1.Text), double.Parse(textBox2.Text)));

                mes += tubes.message(tubes.calculate());
            }
            if (checkBox5.Checked)
            {
                ICalculator furniture = new Furniture(new Dropper(_base, double.Parse(textBox1.Text), double.Parse(textBox2.Text)));

                mes += furniture.message(furniture.calculate());
            }

            MessageBox.Show(mes);
        }
    }
}
