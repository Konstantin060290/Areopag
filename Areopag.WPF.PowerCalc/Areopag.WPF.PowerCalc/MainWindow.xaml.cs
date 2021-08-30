using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Windows.Controls.Primitives;
using System.Reflection;

namespace Areopag.WPF.PowerCalc
    {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
        {
        Pump_drive Pd1 = new Pump_drive();
        Pump_head Ph1 = new Pump_head();
        Aggregate Ag1 = new Aggregate();


        public MainWindow()
            {
            InitializeComponent();
            }
        //Методы расчета
        #region CalcMethods
        public void Aggr_power_calc()
            {

            Ag1.Hydraulic_power = Ag1.Aggregate_qapacity * (Ag1.Aggregate_P2- Ag1.Aggregate_P1) / 36.7 / 1000; //кВт
            Ag1.Power_without_sc = Ag1.Aggregate_qapacity * (Ag1.Aggregate_P2 - Ag1.Aggregate_P1) / (Ag1.Aggr_vol_efficienty * Ag1.Aggr_hydr_efficienty * 36.7 * Ag1.Aggr_mech_efficienty) / 1000;//кВт
           
            if (Ag1.Power_without_sc >= Ag1.Drive_powers_without_sc[10])
                {
                Ag1.Safety_coefficient = Ag1.Safety_coeffitients[7];//1,5
                }
            if (Ag1.Power_without_sc < Ag1.Drive_powers_without_sc[10] & Ag1.Power_without_sc >= Ag1.Drive_powers_without_sc[9])
                {
                Ag1.Safety_coefficient = Ag1.Safety_coeffitients[6];//1,8
                }
            if (Ag1.Power_without_sc < Ag1.Drive_powers_without_sc[9] & Ag1.Power_without_sc >= Ag1.Drive_powers_without_sc[8])
                {
                Ag1.Safety_coefficient = Ag1.Safety_coeffitients[5];//2,2
                }
            if (Ag1.Power_without_sc < Ag1.Drive_powers_without_sc[8] & Ag1.Power_without_sc >= Ag1.Drive_powers_without_sc[7])
                {
                Ag1.Safety_coefficient = Ag1.Safety_coeffitients[4];//2,4
                }
            if (Ag1.Power_without_sc < Ag1.Drive_powers_without_sc[7] & Ag1.Power_without_sc >= Ag1.Drive_powers_without_sc[6])
                {
                Ag1.Safety_coefficient = Ag1.Safety_coeffitients[3];//2,5
                }
            if (Ag1.Power_without_sc < Ag1.Drive_powers_without_sc[6] & Ag1.Power_without_sc >= Ag1.Drive_powers_without_sc[5])
                {
                Ag1.Safety_coefficient = Ag1.Safety_coeffitients[2];//2,8
                }
            if (Ag1.Power_without_sc < Ag1.Drive_powers_without_sc[5] & Ag1.Power_without_sc >= Ag1.Drive_powers_without_sc[3])
                {
                Ag1.Safety_coefficient = Ag1.Safety_coeffitients[1];//3
                }
            if (Ag1.Power_without_sc < Ag1.Drive_powers_without_sc[3])
                {
                Ag1.Safety_coefficient = Ag1.Safety_coeffitients[0];//3,4
                }

            Ag1.Engine_power = Aggregate.FindNearest((Ag1.Power_without_sc* Ag1.Safety_coefficient), Ag1.Electric_drive_powers_row);
            Ph1.Plunger_diameter_calc = 1000 * Math.Sqrt(4 * Ag1.Aggregate_qapacity / (Ag1.Heads_qantity*Ag1.Aggr_vol_efficienty* Pd1.Stroke_length* Pd1.Strokes * 60 * Math.PI));//в мм
            Ph1.Plunger_diameter = Aggregate.FindNearest(Ph1.Plunger_diameter_calc, Ph1.Plungers_row);
            Ph1.Pressure_force = Ag1.Aggregate_P2 * Math.PI* Math.Pow((Ph1.Plunger_diameter / 10), 2) / 4;//кГс
            Pd1.Max_force = Aggregate.FindNearest(Ph1.Pressure_force, Pd1.forces);
            Ag1.Torque = Ph1.Pressure_force * (Pd1.Stroke_length/2) * 10 / 1000; //Нм
           }
        public void Aggr_power_calc_2()
        {
            Ag1.Hydraulic_power = Ag1.Aggregate_qapacity * (Ag1.Aggregate_P2- Ag1.Aggregate_P1) / 36.7 / 1000; //кВт
            Ag1.Power_without_sc = Ag1.Aggregate_qapacity * (Ag1.Aggregate_P2 - Ag1.Aggregate_P1) / (Ag1.Aggr_vol_efficienty * Ag1.Aggr_hydr_efficienty * 36.7 * Ag1.Aggr_mech_efficienty) / 1000;//кВт
            Ag1.Engine_power = Aggregate.FindNearest((Ag1.Power_without_sc * Ag1.Safety_coefficient), Ag1.Electric_drive_powers_row);
            Ph1.Plunger_diameter_calc = 1000 * Math.Sqrt(4 * Ag1.Aggregate_qapacity / (Ag1.Heads_qantity*Ag1.Aggr_vol_efficienty * Pd1.Stroke_length * Pd1.Strokes * 60 * Math.PI));//в мм
            Ph1.Plunger_diameter = Aggregate.FindNearest(Ph1.Plunger_diameter_calc, Ph1.Plungers_row);
            Ph1.Pressure_force = Ag1.Aggregate_P2* Math.PI * Math.Pow((Ph1.Plunger_diameter / 10), 2) / 4;//кГс
            Pd1.Max_force = Aggregate.FindNearest(Ph1.Pressure_force, Pd1.forces);
            Ag1.Torque = Ph1.Pressure_force * (Pd1.Stroke_length/2) * 10 / 1000; //Нм
            }
        #endregion CalcMethods

        //Работа с интерфейсом
        //Меню
        #region MenuFile
        private void Save_us_Click(object sender, RoutedEventArgs e)
            {   

            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            for (int j = 0; j < ResultGrid.Columns.Count; j++)
                {
                Range myrange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[1].ColumnWidth = 10;
                sheet1.Columns[2].ColumnWidth = 70;
                sheet1.Columns[j + 1].ColumnWidth = 25;
                myrange.Value2 = ResultGrid.Columns[j].Header;
                myrange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                myrange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                }
            for (int i = 0; i < ResultGrid.Columns.Count; i++)
                {
                for (int j = 0; j < ResultGrid.Items.Count; j++)
                    {
                    TextBlock b = ResultGrid.Columns[i].GetCellContent(ResultGrid.Items[j]) as TextBlock;
                    Range myRange = sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                    myRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    myRange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    }

                }


            }
        
                private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
                    {
                    My_main_window.Close();
                    }

                private void PGA_volume_calc_Click(object sender, RoutedEventArgs e)
                    {
                    try
                        {
                        Process.Start("Расчет объема ПГА.exe");
                        }
                    catch
                        {
                        MessageBox.Show("Приложение \"Расчет объема ПГА.exe\" не найдено");
                        }
                    }

        #endregion MenuFile

                //Основные параметры
                #region MainParameters
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

                        private void P2_textbox_TextChanged(object sender, TextChangedEventArgs e)
                            {
                            try
                                {
                                Ag1.Aggregate_P2 = Convert.ToDouble(P2_textbox.Text);
                                }
                            catch
                                {
                                Ag1.Aggregate_P2 = 0;
                                }
                            }


                        private void P1_textbox_TextChanged(object sender, TextChangedEventArgs e)
                            {
                            try
                                {
                                Ag1.Aggregate_P1 = Convert.ToDouble(P1_textbox.Text);
                                }
                            catch
                                {
                                Ag1.Aggregate_P1 = 0;
                                }
                            }
                        private void P1_textbox_Loaded(object sender, RoutedEventArgs e)
                            {
                            Ag1.Aggregate_P1 = Convert.ToDouble(P1_textbox.Text);
                            }
                #endregion MainParameters

                //Показатели эффективности
                #region Effecienty
                private void Vol_eff_textbox_TextChanged(object sender, TextChangedEventArgs e)
                    {

                    try
                        {
                        Ag1.Aggr_vol_efficienty = Convert.ToDouble(Vol_eff_textbox.Text);
                        }
                    catch
                        {
                        Ag1.Aggr_vol_efficienty = 0;
                        }
                    }

                    private void Vol_eff_textbox_Loaded(object sender, RoutedEventArgs e)
                    {
                    Ag1.Aggr_vol_efficienty = Convert.ToDouble(Vol_eff_textbox.Text);
                    }

                private void Hydr_eff_textbox_TextChanged(object sender, TextChangedEventArgs e)
                    {
                    try
                        {
                        Ag1.Aggr_hydr_efficienty = Convert.ToDouble(Hydr_eff_textbox.Text);
                        
                        }
                    catch
                        {
                         Ag1.Aggr_hydr_efficienty = 0;
                        }
                    }
   
                private void Hydr_eff_textbox_Loaded(object sender, RoutedEventArgs e)
                    {
                    Ag1.Aggr_hydr_efficienty = Convert.ToDouble(Hydr_eff_textbox.Text);
                    }

                private void Mech_eff_textbox_TextChanged(object sender, TextChangedEventArgs e)
                    {
                    try
                        {
                        Ag1.Aggr_mech_efficienty = Convert.ToDouble(Mech_eff_textbox.Text);
                        }
                    catch
                        {
                        Ag1.Aggr_mech_efficienty = 0;
                        }
                    }
                private void Mech_eff_textbox_Loaded(object sender, RoutedEventArgs e)
                    {
                    Ag1.Aggr_mech_efficienty = Convert.ToDouble(Mech_eff_textbox.Text);
                    }

        #endregion Effecienty

                //Конструктивная реализация
                #region Construction
                private void Qantity_of_heads_textbox_TextChanged(object sender, TextChangedEventArgs e)
                    {
                    try
                        {
                        Ag1.Heads_qantity = Convert.ToInt32(Qantity_of_heads_textbox.Text);
                        }
                    catch
                        {
                        Ag1.Heads_qantity = 0;
                        }
                    }

                private void Qantity_of_heads_textbox_Loaded(object sender, RoutedEventArgs e)
                    {
                    Ag1.Heads_qantity = Convert.ToInt32(Qantity_of_heads_textbox.Text);
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
                private void Safety_coeff_textbox_Loaded(object sender, RoutedEventArgs e)
                    {
                    Ag1.Safety_coefficient = Convert.ToDouble(Safety_coeff_textbox.Text);
                    }
                private void Strokes_textbox_TextChanged(object sender, TextChangedEventArgs e)
                    {
                    try
                        {
                        Pd1.Strokes = Convert.ToInt32(Strokes_textbox.Text);
                        }
                    catch
                        {
                        Pd1.Strokes = 0;
                        }
                    }
                private void Strokes_textbox_Loaded(object sender, RoutedEventArgs e)
                    {
                    Pd1.Strokes = Convert.ToInt32(Strokes_textbox.Text);
                    }
                private void Stroke_lenght_textbox_TextChanged(object sender, TextChangedEventArgs e)
                    {
                    try
                        {
                        Pd1.Stroke_length = Convert.ToDouble(Stroke_lenght_textbox.Text);
                        }
                    catch
                        {
                        Pd1.Stroke_length = 0;
                        }
                    }

                    private void Stroke_lenght_textbox_Loaded(object sender, RoutedEventArgs e)
                    {
                    Pd1.Stroke_length = Convert.ToDouble(Stroke_lenght_textbox.Text);
                    }

        #endregion Construction

        //Запуск расчета
        #region StartCalc               

        private SolidColorBrush hb = new SolidColorBrush(Colors.Orange);
        private SolidColorBrush nb = new SolidColorBrush(Colors.White);
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

            System.Data.DataTable dt = new System.Data.DataTable("ResultTable");
            DataColumn id = new DataColumn("Id", typeof(int));
            DataColumn name = new DataColumn("Наименование параметра", typeof(string));
            DataColumn symbol = new DataColumn("Условное обозначение", typeof(string));
            DataColumn value = new DataColumn("Значение параметра");
            DataColumn unit = new DataColumn("Единица измерения", typeof(string));

            dt.Columns.Add(id);
            dt.Columns.Add(name);
            dt.Columns.Add(symbol);
            dt.Columns.Add(value);
            dt.Columns.Add(unit);
            DataRow input = dt.NewRow();
            int i = 0;
            input[0] = i;
            input[1] = "Исходные данные";
            input[2] = "-------------------";
            input[3] = "-------------------";
            input[4] = "-------------------"; ;
            dt.Rows.Add(input);
            DataRow qapacity = dt.NewRow();            
            qapacity[0] = ++i;
            qapacity[1] = "Номинальная подача агрегата";
            qapacity[2] = "Qа";
            qapacity[3] = Ag1.Aggregate_qapacity;
            qapacity[4] = "л/ч";
            dt.Rows.Add(qapacity);
            if (Ag1.Heads_qantity > 1)
                {
                DataRow head_qapacity = dt.NewRow();
                head_qapacity[0] = ++i;
                head_qapacity[1] = "Номинальная подача головки агрегата";
                head_qapacity[2] = "Qг";
                head_qapacity[3] = Math.Round(Ag1.Aggregate_qapacity/Ag1.Heads_qantity, 3);
                head_qapacity[4] = "л/ч";
                dt.Rows.Add(head_qapacity);
                }
            DataRow p2 = dt.NewRow();
            p2[0] = ++i;
            p2[1] = "Давление на выходе агрегата";
            p2[2] = "P2";
            p2[3] = Ag1.Aggregate_P2;
            p2[4] = "кгс/см2";
            dt.Rows.Add(p2);
            DataRow p1 = dt.NewRow();
            p1[0] = ++i;
            p1[1] = "Давление на входе агрегата";
            p1[2] = "P1";
            p1[3] = Ag1.Aggregate_P1;
            p1[4] = "кгс/см2";
            dt.Rows.Add(p1);
            DataRow vol_eff = dt.NewRow();
            vol_eff[0] = ++i;
            vol_eff[1] = "Объемный КПД агрегата";
            vol_eff[2] = "η1-2";
            vol_eff[3] = Ag1.Aggr_vol_efficienty;
            vol_eff[4] = "-";
            dt.Rows.Add(vol_eff);
            DataRow hydr_eff = dt.NewRow();
            hydr_eff[0] = ++i;
            hydr_eff[1] = "Гидравлический КПД агрегата";
            hydr_eff[2] = "ηг";
            hydr_eff[3] = Ag1.Aggr_hydr_efficienty;
            hydr_eff[4] = "-";
            dt.Rows.Add(hydr_eff);
            DataRow mech_eff = dt.NewRow();
            mech_eff[0] = ++i;
            mech_eff[1] = "Механический КПД агрегата";
            mech_eff[2] = "ηм";
            mech_eff[3] = Ag1.Aggr_mech_efficienty;
            mech_eff[4] = "-";
            dt.Rows.Add(mech_eff);
            DataRow heads_quantity = dt.NewRow();
            heads_quantity[0] = ++i;
            heads_quantity[1] = "Количество головок в агрегате";
            heads_quantity[2] = "z";
            heads_quantity[3] = Ag1.Heads_qantity;
            heads_quantity[4] = "шт.";
            dt.Rows.Add(heads_quantity);
            DataRow strokes = dt.NewRow();
            strokes[0] = ++i;
            strokes[1] = "Число двойных ходов плунжера в мин.";
            strokes[2] = "n";
            strokes[3] = Pd1.Strokes;
            strokes[4] = "-";
            dt.Rows.Add(strokes);
            DataRow stroke_length = dt.NewRow();
            stroke_length[0] = ++i;
            stroke_length[1] = "Величина хода плунжера";
            stroke_length[2] = "h";
            stroke_length[3] = Pd1.Stroke_length;
            stroke_length[4] = "мм";
            dt.Rows.Add(stroke_length);
            DataRow output = dt.NewRow();
            int j = 0;
            output[0] = j;
            output[1] = "Результаты расчета";
            output[2] = "-------------------";
            output[3] = "-------------------";
            output[4] = "-------------------"; ;
            dt.Rows.Add(output);
            DataRow hydraulic_power = dt.NewRow();
            hydraulic_power[0] = ++j;
            hydraulic_power[1] = "Выходная мощность насоса";
            hydraulic_power[2] = "Nв";
            hydraulic_power[3] = Math.Round(Ag1.Hydraulic_power, 3);
            hydraulic_power[4] = "кВт";
            dt.Rows.Add(hydraulic_power);
            DataRow consumption_power = dt.NewRow();
            consumption_power[0] = ++j;
            consumption_power[1] = "Потребляемая мощность насоса";
            consumption_power[2] = "Nп";
            consumption_power[3] = Math.Round(Ag1.Power_without_sc, 3);
            consumption_power[4] = "кВт";
            dt.Rows.Add(consumption_power);
            DataRow safety_factor = dt.NewRow();
            safety_factor[0] = ++j;
            safety_factor[1] = "Коэффициент запаса";
            safety_factor[2] = "k";
            safety_factor[3] = Ag1.Safety_coefficient;
            safety_factor[4] = "-";
            dt.Rows.Add(safety_factor);
            DataRow calc_motor_power = dt.NewRow();
            calc_motor_power[0] = ++j;
            calc_motor_power[1] = "Расчетная мощность электродвигателя";
            calc_motor_power[2] = "NэДвр";
            calc_motor_power[3] = Math.Round((Ag1.Power_without_sc*Ag1.Safety_coefficient),3);
            calc_motor_power[4] = "кВт";
            dt.Rows.Add(calc_motor_power);
            DataRow motor_power = dt.NewRow();
            motor_power[0] = ++j;
            motor_power[1] = "Мощность выбранного из ряда электродвигателя";
            motor_power[2] = "NэДв";
            motor_power[3] = Ag1.Engine_power;
            motor_power[4] = "кВт";
            dt.Rows.Add(motor_power);
            DataRow calc_pl_diam = dt.NewRow();
            calc_pl_diam[0] = ++j;
            calc_pl_diam[1] = "Расчетный диаметр плунжера";
            calc_pl_diam[2] = "Dплр";
            calc_pl_diam[3] = Math.Round(Ph1.Plunger_diameter_calc, 3);
            calc_pl_diam[4] = "мм";
            dt.Rows.Add(calc_pl_diam);
            DataRow pl_diam = dt.NewRow();
            pl_diam[0] = ++j;
            pl_diam[1] = "Выбранный из ряда, диаметр плунжера";
            pl_diam[2] = "Dпл";
            pl_diam[3] = Ph1.Plunger_diameter;
            pl_diam[4] = "мм";
            dt.Rows.Add(pl_diam);
            DataRow vg = dt.NewRow();
            vg[0] = ++j;
            vg[1] = "Объем геометрического замещения";
            vg[2] = "Vг";
            vg[3] = Math.Round(((Math.PI*(Ph1.Plunger_diameter/10)*(Ph1.Plunger_diameter/10)/4)*(Pd1.Stroke_length/10)), 3);
            vg[4] = "см3";
            dt.Rows.Add(vg);
            DataRow pl_force = dt.NewRow();
            pl_force[0] = ++j;
            pl_force[1] = "Возникающее осевое усилие на плунжере";
            pl_force[2] = "Fпл";
            pl_force[3] = Math.Round(Ph1.Pressure_force, 3);
            pl_force[4] = "кгс";
            dt.Rows.Add(pl_force);
            DataRow drive_choosen = dt.NewRow();
            drive_choosen[0] = ++j;
            drive_choosen[1] = "Предполагаемый приводной механизм c усилием";
            drive_choosen[2] = "-";
            drive_choosen[3] = Pd1.Max_force;
            drive_choosen[4] = "кгс";
            dt.Rows.Add(drive_choosen);
            DataRow torque = dt.NewRow();
            torque[0] = ++j;
            torque[1] = "Требуемый момент на кривошипном валу (для одной насосной головки)";
            torque[2] = "Мкр1г";
            torque[3] = Math.Round(Ag1.Torque, 3);
            torque[4] = "Нм";
            dt.Rows.Add(torque);
            int z = 0;
            DataRow date = dt.NewRow();
            date[0] = z;
            date[1] = "Дата и время выполнения расчета";
            date[2] = "-------------------";
            date[3] = DateTime.Now.ToString();
            date[4] = "-------------------";
            dt.Rows.Add(date);

            ResultGrid.ItemsSource = dt.DefaultView;

        }
        
                #endregion StartCalc
                          
                //Работа с чек-боксами (видимость, скрытие)
                #region CheckBoxes
                private void My_main_window_Loaded(object sender, RoutedEventArgs e)
                {
                    Safety_coeff_label.Visibility = Visibility.Hidden;
                    Safety_coeff_textbox.Visibility = Visibility.Hidden;
                    //Strokes_label.Visibility = Visibility.Hidden;
                    //Stroke_label.Visibility = Visibility.Hidden;
                    //Strokes_textbox.Visibility = Visibility.Hidden;
                    //Stroke_lenght_textbox.Visibility = Visibility.Hidden;

                }

                private void Calc_add_parameters_checkbox_Checked(object sender, RoutedEventArgs e)
                {
                    Strokes_label.Visibility = Visibility.Visible;
                    Stroke_label.Visibility = Visibility.Visible;
                    Strokes_textbox.Visibility = Visibility.Visible;
                    Stroke_lenght_textbox.Visibility = Visibility.Visible;
                    Pd1.Strokes = Convert.ToInt32(Strokes_textbox.Text);
                    Pd1.Stroke_length = Convert.ToDouble(Stroke_lenght_textbox.Text);
            }

                private void Calc_add_parameters_checkbox_Unchecked(object sender, RoutedEventArgs e)
                {
                    Strokes_label.Visibility = Visibility.Hidden;
                    Stroke_label.Visibility = Visibility.Hidden;
                    Strokes_textbox.Visibility = Visibility.Hidden;
                    Stroke_lenght_textbox.Visibility = Visibility.Hidden;
                    Pd1.Strokes = 0;
                    Pd1.Stroke_length = 0;
                }

                private void Enter_safety_coeff_checkbox_Checked(object sender, RoutedEventArgs e)
                    {
                    Safety_coeff_label.Visibility = Visibility.Visible;
                    Safety_coeff_textbox.Visibility = Visibility.Visible;
                    Ag1.Safety_coefficient = Convert.ToDouble(Safety_coeff_textbox.Text);

                    }
                private void Enter_safety_coeff_checkbox_Unchecked(object sender, RoutedEventArgs e)
                    {
                    Safety_coeff_label.Visibility = Visibility.Hidden;
                    Safety_coeff_textbox.Visibility = Visibility.Hidden;
                    }
                private void Calc_add_parameters_checkbox_Loaded(object sender, RoutedEventArgs e)
                    {
                    Calc_add_parameters_checkbox.IsChecked = true;
                    }

        #endregion CheckBoxes

        //Методы показа рядов эДв, плунжеров, механизмов
        #region ShowRows
        private void Show_pl_row_btn_Click(object sender, RoutedEventArgs e)
                    {
                    MessageBox.Show(string.Join("\t", Ph1.Plungers_row), "Ряд применяемых в программе плунжеров, мм", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                private void ED_row_btn_Click(object sender, RoutedEventArgs e)
                    {
                    MessageBox.Show(string.Join("\t", Ag1.Electric_drive_powers_row), "Ряд применяемых в программе электродвигателей, кВт", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
        
                private void Show_drives_row_Click(object sender, RoutedEventArgs e)
                    {
                    string all="";
                    for (int i=0; i<Pd1.drives.Length;i++)
                        {
                        all+=string.Concat(Pd1.drives[i] +" (F="+Pd1.forces[i].ToString()+ " кгс, величина хода: "+ Pd1.stroke_lengthes[i].ToString()+" мм);" + "\r\n"+ "\r\n");
                        }
                    MessageBox.Show(all, "Ряд применяемых приводов и их предельные усилия на ползуне", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                #endregion ShowRows

                //О программе
                #region About

                static string about = "Данная программа позволяет выполнить расчет параметров дозировочных агрегатов по " + "\n" +
                 "ТУ 3632-003-46919837-2007.";
                static string author = "Филюрин К.В.";
                static string year_author = "2021";
                static string version = "1.0.0.0";
        private Microsoft.Office.Interop.Excel.Application excel;

        private void MenuItem_About_Click(object sender, RoutedEventArgs e)
                    {
                    MessageBox.Show((about + "\n" + "\n" + "Автор - " + author + "\n" + "\n" + "Год выхода - " + year_author + "\n" + "\n" + "Версия - " + version),
                        "Справка", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                #endregion About

        //Недоделки
        #region  Nedodelki
        private void Add_head_Click(object sender, RoutedEventArgs e)
            {

            New_head NH1 = new New_head();
            NH1.Show();


            }

        public object SelectedTreeElem { get; set; }
        static public object New_head_in_tree { get; set; }

        //private void TreeViewItem_Selected(Object sender, RoutedEventArgs e)
        //{
        //    TreeViewItem item = e.OriginalSource as TreeViewItem;
        //    if (item != null)
        //    {
        //        ItemsControl parent = GetSelectedTreeViewItemParent(item);
        //    }
        //}
        private void Change_head_button_Click(object sender, RoutedEventArgs e)
            {

            }

        public ItemsControl GetSelectedTreeViewItemParent(TreeViewItem item)
            {
            DependencyObject parent = VisualTreeHelper.GetParent(item);
            while (!(parent is TreeViewItem || parent is TreeView))
                {
                parent = VisualTreeHelper.GetParent(parent);
                }

            return parent as ItemsControl;
            }

        private void Bl_aggr_treeview_i_Selected(object sender, RoutedEventArgs e)
            {
            TreeViewItem item = e.OriginalSource as TreeViewItem;
            if (item != null)
                {
                ItemsControl parent = GetSelectedTreeViewItemParent(item);
                parent.Items.Remove(item);
                }


            }

        private void Remove_head_button_Click(object sender, RoutedEventArgs e)
            {
            //TreeNode node = this.trvMenu.Nodes.Cast<TreeNode>().FirstOrDefault(x => x.Name == "TestNode")
            //if (node != null)
            //{
            //    this.trvMenu.Nodes.Remove(node);
            //}

            }






        #endregion Nedodelki



        }
    }
