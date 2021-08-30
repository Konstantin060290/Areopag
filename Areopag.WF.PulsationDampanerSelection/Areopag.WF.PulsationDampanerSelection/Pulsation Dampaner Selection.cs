using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Areopag.WF.PulsationDampanerSelection
{
    public partial class PulsationDampanerSelectionForm : Form
    {



        Operation Op1 = new Operation();
        public PulsationDampanerSelectionForm()
        {
            InitializeComponent();
        }

        private void QapacityTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Op1.Q_max = Double.Parse(QapacityTextBox.Text);
            }
            catch
            {
                Op1.Q_max = 0;
            }
        }

        private void StrokesTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Op1.Strokes = Double.Parse(StrokesTextBox.Text);
            }
            catch
            {
                Op1.Strokes = 0;
            }
        }

        private void P2TextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Op1.P_2 = Double.Parse(P2TextBox.Text);
            }
            catch
            {
                Op1.P_2 = 0;
            }
        }

        private void P1TextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Op1.P_1 = Double.Parse(P1TextBox.Text);
            }
            catch
            {
                Op1.P_1 = 0;
            }
        }

        private void delta_rTb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Op1.Delta_r = Double.Parse(Delta_rTb.Text);
            }
            catch
            {
                Op1.Delta_r = 0;
            }
        }


        private void Calculation_Click(object sender, EventArgs e)
        {

            if (Way1Rb.Checked == true)
            {
                Op1.CalcVoluemu_1();
                Volume_TextBox.Text = Convert.ToString(Math.Round(Op1.V0_1, 3));
            }
            if (Way2Rb.Checked == true)
            {
                Op1.CalcVoluemu_2();
                Volume_TextBox.Text = Convert.ToString(Math.Round(Op1.V0_2, 3));
            }
        }

        double common_k = 0.6;//коэффициент k по умолчанию

        private void PulsationDampanerSelectionForm_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(Volume_TextBox, "Полный газовый объем");

            if (Way1Rb.Checked == true)
            {
                Delta_rTb.Visible = false;
                DeltaP_label.Visible = false;
            }

            else
            {
                Delta_rTb.Visible = true;
                DeltaP_label.Visible = true;
            }

            if (OneHeadRb.Checked == true)
            {
                Op1.K = common_k;
            }

            k_coefficient.Text = "Коэффициент k=" + Convert.ToString(Op1.K);
        }
        //Проверка ввода десятичных чисел
        private void QapacityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
                char ch = e.KeyChar;
                if (!Char.IsDigit(ch) && ch != 8 && (ch != ',' || QapacityTextBox.Text.Contains(",")))
                {
                    e.Handled = true;
                }                   
        }

        private void StrokesTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && (ch != ',' || StrokesTextBox.Text.Contains(",")))
            {
                e.Handled = true;
            }
        }

        private void P2TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && (ch != ',' || P2TextBox.Text.Contains(",")))
            {
                e.Handled = true;
            }
        }

        private void P1TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && (ch != ',' || P1TextBox.Text.Contains(",")))
            {
                e.Handled = true;
            }
        }
        private void Delta_rTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && (ch != ',' || Delta_rTb.Text.Contains(",")))
            {
                e.Handled = true;
            }
        }

        //Изменение значений коэффциента K в зависимости от выбранного типа агрегата
        private void OneHeadRb_CheckedChanged(object sender, EventArgs e)
        {
            Op1.K = common_k;
            k_coefficient.Text = "Коэффициент k=" + Convert.ToString(common_k);

        }

        private void TwoHeadRb_CheckedChanged(object sender, EventArgs e)
        {
            Op1.K = 0.25;
            k_coefficient.Text = "Коэффициент k=" + Convert.ToString(Op1.K);
        }

        private void ThreeHeadRb_CheckedChanged(object sender, EventArgs e)
        {
            Op1.K = 0.13;
            k_coefficient.Text = "Коэффициент k=" + Convert.ToString(Op1.K);
        }

        private void Way1Rb_CheckedChanged(object sender, EventArgs e)
        {

            Delta_rTb.Visible = false;
            DeltaP_label.Visible = false;
            P1TextBox.Visible = true;
            P1Label.Visible = true;
            Op1.Delta_r = 0;

        }

        private void Way2Rb_CheckedChanged(object sender, EventArgs e)
        {
            Delta_rTb.Visible = true;
            DeltaP_label.Visible = true;
            Delta_rTb.Location = P1TextBox.Location;
            DeltaP_label.Location = P1Label.Location;
            P1TextBox.Visible = false;
            P1Label.Visible = false;
            Op1.Delta_r = 0;
            Delta_rTb.Text = 0.ToString();


        }


        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            Operation.about+Environment.NewLine+Environment.NewLine+
            Operation.version+Environment.NewLine+Environment.NewLine+
            Operation.year_author,
            "Справка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }
    }
}
