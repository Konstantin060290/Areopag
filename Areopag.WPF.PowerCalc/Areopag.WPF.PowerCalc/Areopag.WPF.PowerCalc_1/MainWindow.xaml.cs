using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Microsoft.Win32;
using System.IO;

namespace Areopag.WPF.PowerCalc_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pump_drive Pd1 = new Pump_drive();
        Pump_head Ph1 = new Pump_head();
        Aggregate Ag1 = new Aggregate();
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Aggr_power_calc()
        {
            Ag1.Hydraulic_power = Ag1.Aggregate_qapacity * Ag1.Aggregate_P2 / 36.7 / 1000; //кВт
            Ag1.Power_without_sc = Ag1.Aggregate_qapacity * (Ag1.Aggregate_P2 - Ag1.Aggregate_P1) / ((Ph1.Head_vol_efficiency * Ph1.Head_hydr_efficiency) * 36.7 * Pd1.Drive_mech_efficiency) / 1000;//кВт
            Ph1.Plunger_diameter = 1000 * Math.Sqrt(4 * Ag1.Aggregate_qapacity / (Ph1.Head_vol_efficiency * Pd1.Stroke_length * Pd1.Strokes * 60 * Math.PI));//в мм
            if (Ag1.Power_without_sc > 0 && Ag1.Power_without_sc <= Ag1.Drive_powers_without_sc[0])
            {
                Ag1.Engine_power = Ag1.Electric_drive_powers_row[0];
                Ag1.Safety_coefficient = Ag1.Safety_coeffitients[0];
            }
        }
        public void Aggr_power_calc_2()
        {
            Ag1.Hydraulic_power = Ag1.Aggregate_qapacity * Ag1.Aggregate_P2 / 36.7 / 1000; //кВт
            Ag1.Power_without_sc = Ag1.Aggregate_qapacity * (Ag1.Aggregate_P2 - Ag1.Aggregate_P1) / ((Ph1.Head_vol_efficiency * Ph1.Head_hydr_efficiency) * 36.7 * Pd1.Drive_mech_efficiency) / 1000;//кВт
            Ag1.Engine_power = Aggregate.FindNearest((Ag1.Power_without_sc * Ag1.Safety_coefficient), Ag1.Electric_drive_powers_row);
            Ph1.Plunger_diameter = 1000 * Math.Sqrt(4 * Ag1.Aggregate_qapacity / (Ph1.Head_vol_efficiency * Pd1.Stroke_length * Pd1.Strokes * 60 * Math.PI));//в мм
        }


        private void Qapacity_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {


            try
            {
                Ag1.Aggregate_qapacity = Convert.ToDouble(Qapacity_textbox.Text);
            }

            catch
            {
                Ag1.Aggregate_qapacity = 0;
            }
        }

        private void Result_button_click(object sender, RoutedEventArgs e)
        {
            if (Enter_safety_coeff_checkbox.IsChecked == true)
            {
                Aggr_power_calc_2();
            }

            else
            {
                Aggr_power_calc();
            }


            Result_textbox.Text = Ag1.Aggr_result(Ag1.Engine_power, Ag1.Hydraulic_power, Ag1.Power_without_sc, Ag1.Safety_coefficient, Ph1.Plunger_diameter);


        }

        private void P2_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Ag1.Aggregate_P2 = Convert.ToInt32(P2_textbox.Text);
            }
            catch
            {
                Ag1.Aggregate_P2 = 0;
            }
        }


        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            My_main_window.Close();
        }

        private void P1_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Ag1.Aggregate_P1 = Convert.ToInt32(P1_textbox.Text);
            }
            catch
            {
                Ag1.Aggregate_P1 = 0;
            }
        }

        private void Vol_eff_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Ph1.Head_vol_efficiency = Convert.ToDouble(Vol_eff_textbox.Text);
            }
            catch
            {
                Ph1.Head_vol_efficiency = 0;
            }
        }

        private void Mech_eff_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Pd1.Drive_mech_efficiency = Convert.ToDouble(Mech_eff_textbox.Text);
            }
            catch
            {
                Pd1.Drive_mech_efficiency = 0;
            }
        }

        private void Hydr_eff_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Ph1.Head_hydr_efficiency = Convert.ToDouble(Hydr_eff_textbox.Text);
            }
            catch
            {
                Ph1.Head_hydr_efficiency = 0;
            }
        }

        private void Safety_coeff_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Ag1.Safety_coefficient = Convert.ToDouble(Safety_coeff_textbox.Text);
            }

            catch
            {
                Ag1.Safety_coefficient = 0;
            }
        }

        private void Enter_safety_coeff_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            Safety_coeff_label.Visibility = Visibility.Visible;
            Safety_coeff_textbox.Visibility = Visibility.Visible;

        }
        private void Enter_safety_coeff_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            Safety_coeff_label.Visibility = Visibility.Hidden;
            Safety_coeff_textbox.Visibility = Visibility.Hidden;
        }
        private void My_main_window_Loaded(object sender, RoutedEventArgs e)
        {
            Safety_coeff_label.Visibility = Visibility.Hidden;
            Safety_coeff_textbox.Visibility = Visibility.Hidden;
            Strokes_label.Visibility = Visibility.Hidden;
            Stroke_label.Visibility = Visibility.Hidden;
            Strokes_textbox.Visibility = Visibility.Hidden;
            Stroke_lenght_textbox.Visibility = Visibility.Hidden;
        }

        private void Calc_add_parameters_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            Strokes_label.Visibility = Visibility.Visible;
            Stroke_label.Visibility = Visibility.Visible;
            Strokes_textbox.Visibility = Visibility.Visible;
            Stroke_lenght_textbox.Visibility = Visibility.Visible;
        }

        private void Calc_add_parameters_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            Strokes_label.Visibility = Visibility.Hidden;
            Stroke_label.Visibility = Visibility.Hidden;
            Strokes_textbox.Visibility = Visibility.Hidden;
            Stroke_lenght_textbox.Visibility = Visibility.Hidden;
        }

        private void Save_us_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text file (*.txt)|*.txt";
            DateTime now = DateTime.Now;

            dlg.FileName = "Расчет параметров дозировочного агрегата "+Convert.ToString(now.Day)+"."+Convert.ToString(now.Month)+"."+Convert.ToString(now.Year)+
                " " +Convert.ToString(now.Hour)+ "_"+ Convert.ToString(now.Minute) + "_"+Convert.ToString(now.Second);

            
            if (dlg.ShowDialog()==true)
            {
                File.WriteAllText(dlg.FileName, Result_textbox.Text);
            }
        }

        private void Strokes_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Pd1.Strokes = Convert.ToInt32(Strokes_textbox.Text);
        }

        private void Stroke_lenght_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Pd1.Stroke_length = Convert.ToInt32(Stroke_lenght_textbox.Text);
        }
    }
}
