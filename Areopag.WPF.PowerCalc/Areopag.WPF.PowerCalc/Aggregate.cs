﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Areopag.WPF.PowerCalc
    {
    class Aggregate
        {
        public double Hydraulic_power { get; set; }
        public double Engine_power { get; set; }
        public double Power_without_sc { get; set; }
        public double Aggregate_qapacity { get; set; }
        public double Aggregate_P2 { get; set; }
        public double Aggregate_P1 { get; set; }
        public double Safety_coefficient { get; set; }
        public double Heads_qantity { get; set; }
        public double Torque { get; set; }
        public double Aggr_vol_efficienty { get; set; }
        public double Aggr_hydr_efficienty { get; set; }
        public double Aggr_mech_efficienty { get; set; }

        public double[] Electric_drive_powers_row = new double[] {
                0.18,//0
                0.25,//1
                0.37,//2
                0.55,//3
                0.75,//4
                1.1,//5
                1.5,//6
                2.2,//7
                3,//8
                4,//9
                5.5,//10
                7.5,//11
                11,//12
                15,//13
                18.5,//14
                22,//15
                30,//16
                37,//17
                45,//18
                55,//19
                75,//20
                90,//21
                110,//22
                132,//23
                160,//24
                200,//25
                250,//26
                315};//27
        public double[] Safety_coeffitients = new double[] {
                3.4,//0
                3,  //1
                2.8,//2
                2.5,//3
                2.4,//4
                2.2,//5
                1.8,//6
                1.5};//7
        public double[] Drive_powers_without_sc = new double[] {
                0.053,//0
                0.074,//1
                0.109,//2
                0.183,//3
                0.250,//4
                0.393,//5
                0.6,//6
                0.917,//7
                1.364,//8
                2.222,//9
                3.667,//10
                4.667,//11
                7.333,//12
                10,//13
                12.333,//14
                14.667,//15
                20,//16
                24.667,//17
                30,//18
                36.667,//19
                50,//20
                60,//21
                73.333,//22
                88,//23
                106.667,//24
                133.333,//25
                166.667,//26
                210};//27
        
        public static double FindNearest(double targetNumber, IEnumerable<double> collection)
        {
            var results = collection.ToArray();
            double nearestValue;
            if (results.Any(ab => ab == targetNumber))
                nearestValue = results.FirstOrDefault(i => i == targetNumber);
          
            else
            {
                double greaterThanTarget = 0;
                double lessThanTarget = 0;
                if (results.Any(ab => ab > targetNumber))
                {
                    greaterThanTarget = results.Where(i => i > targetNumber).Min();
                }
                //if (results.Any(ab => ab < targetNumber))
                //{
                //    lessThanTarget = results.Where(i => i < targetNumber).Max();
                //}

                if (lessThanTarget == 0)
                {
                    nearestValue = greaterThanTarget;
                }
                //else if (greaterThanTarget == 0)
                //{
                //    nearestValue = lessThanTarget;
                //}
                //else if (targetNumber - lessThanTarget < greaterThanTarget - targetNumber)
                //{
                //    nearestValue = lessThanTarget;
                //}

                else
                {
                    nearestValue = greaterThanTarget;
                }

            }
            return nearestValue;
        }

        //Метод не используется
        public string Aggr_result(double ep, double hp, double pwsc, double sc, double pl_diam_calc, double pl_diam, double pr_force, double drive_force,
            double torque)
        {
            string res;

            if (pwsc*sc <= Electric_drive_powers_row.Last())
            {
                res = "Выходная мощность насоса = " + (hp).ToString("0.000") + " кВт;" + "\n" + "\n"+
                "Потребляемая мощность насоса = " + (pwsc).ToString("0.000") + " кВт;" + "\n" + "\n" +
                "Коэффициент запаса = " + (sc).ToString() + ";" + "\n" + "\n" +
                "Расчетная мощность электродвигателя агрегата = " + (pwsc * sc).ToString("0.000") + " кВт;" + "\n" + "\n" +
                "Мощность, выбранного из ряда, электродвигателя = " + (ep).ToString() + " кВт;" + "\n" + "\n" +
                "Расчетный диаметр плунжера = " + (pl_diam_calc).ToString("0.000") + " мм;" + "\n" + "\n" +
                "Выбранный из ряда, диаметр плунжера = " + (pl_diam).ToString("0.0") + " мм;" + "\n" + "\n" +
                "Возникающее осевое усилие на плунжере = " + (pr_force).ToString("0.000") + " кгс;" + "\n" + "\n" +
                "Предполагаемый приводной механизм c усилием: " + (drive_force).ToString("0.000")+ " кгс;"+"\n" + "\n" +
                "Требуемый момент на кривошипном валу (для одной насосной головки) = " +(torque).ToString("0.000")+ " Нм;" + "\n" + "\n" +
                "\n" + "Расчет выполнен - " +DateTime.Now.ToString();
                
            }
            else
            {
                res = "Выходная мощность насоса = " + (hp).ToString("0.000") + " кВт;" + "\n"+ "\n" +
               "Потребляемая мощность насоса = " + (pwsc).ToString("0.000") + " кВт;" + "\n" + "\n" +
                "Коэффициент запаса = " + (sc).ToString() + ";" + "\n" + "\n" +
                "Расчетная мощность электродвигателя агрегата = " + (pwsc * sc).ToString("0.000") + " кВт;" + "\n" + "\n" +
                "Электродвигатели с мощностю более 250 кВт вне применяемой номенклатуры!" +"\n" + "\n" +
                "Расчетный диаметр плунжера = " + (pl_diam_calc).ToString("0.000") + " мм;" + "\n" + "\n" +
                "Выбранный из ряда, диаметр плунжера = " + (pl_diam).ToString("0.0") + " мм;" + "\n" + "\n" +
                "Возникающее осевое усилие на плунжере = " + (pr_force).ToString("0.000") + " кгс;" + "\n" + "\n" +
                "Предполагаемый приводной механизм с усилием: " + (drive_force).ToString("0.000") + " кгс;"+"\n" + "\n" +
                "Требуемый момент на кривошипном валу (для одной насосной головки) = " + (torque).ToString("0.000") + " Нм;" + "\n" + "\n" +
                "\n" +"Расчет выполнен - " + DateTime.Now.ToString();
            }
            return res;
        }

   

    }

}
