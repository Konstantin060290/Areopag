using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Areopag.WPF.PowerCalc_1
{
    class Aggregate
    {
        public double Hydraulic_power { get; set; }
        public double Engine_power { get; set; }
        public double Power_without_sc { get; set; }
        public double Aggregate_qapacity { get; set; }
        public int Aggregate_P2 { get; set; }
        public int Aggregate_P1 { get; set; }
        public double Safety_coefficient { get; set; }

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
                7,//11
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

        public string Aggr_result(double ep, double hp, double pwsc, double sc, double pl_diam)
        {
            string res;
            
            if (pwsc*sc <= Electric_drive_powers_row.Last())
            {
                res = "Гидравлическая мощность агрегата =" + (hp).ToString("0.000") + " кВт;" + "\n" +
                "Мощность агрегата без коэффициента запаса=" + (pwsc).ToString("0.000") + " кВт;" + "\n" +
                "Коэффициент запаса=" + (sc).ToString() + ";" + "\n" +
                "Требуемая мощность электродвигателя агрегата=" + (pwsc*sc).ToString("0.000") + " кВт;" + "\n" +
                "Мощность, выбранного из ряда, электродвигателя=" + (ep).ToString() + " кВт;" + "\n" +
                "Расчетный диаметр плунжера="+(pl_diam).ToString("0.000")+" мм;"+ "\n" +

                "\n" + "Расчет выполнен - " +DateTime.Now.ToString();
                
            }
            else
            {
                res = "Гидравлическая мощность агрегата =" + (hp).ToString("0.000") + " кВт;" + "\n" +
                "Мощность агрегата без коэффициента запаса=" + (pwsc).ToString("0.000") + " кВт;" + "\n" +
                "Коэффициент запаса=" + (sc).ToString() + ";" + "\n" +
                "Требуемая мощность электродвигателя агрегата=" + (pwsc * sc).ToString("0.000") + " кВт;" + "\n" +
                "Электродвигатели с мощностю более 250 кВт вне применяемой номенклатуры!"+"\n" +
                "Расчетный диаметр плунжера=" + (pl_diam).ToString("0.000") + " мм;" + "\n" +

                "\n" +"Расчет выполнен - " + DateTime.Now.ToString();
            }
            return res;
        }

        //public void Drive_power_without_sc_calc()
        //{
        //    double[] Drive_powers_without_sc = new double[] {
        //        Electric_drive_powers_row[0]/Safety_coeffitients[0],//0,053
        //        Electric_drive_powers_row[1]/Safety_coeffitients[0],//0,074
        //        Electric_drive_powers_row[2]/Safety_coeffitients[0],//0,109
        //        Electric_drive_powers_row[3]/Safety_coeffitients[1],//0,183
        //        Electric_drive_powers_row[4]/Safety_coeffitients[1],//0,250
        //        Electric_drive_powers_row[5]/Safety_coeffitients[2],//0,393
        //        Electric_drive_powers_row[6]/Safety_coeffitients[3],//0,6
        //        Electric_drive_powers_row[7]/Safety_coeffitients[4],//0,917
        //        Electric_drive_powers_row[8]/Safety_coeffitients[5],//1,364
        //        Electric_drive_powers_row[9]/Safety_coeffitients[6],//2,222
        //        Electric_drive_powers_row[10]/Safety_coeffitients[7],//3,667
        //        Electric_drive_powers_row[11]/Safety_coeffitients[7],//4,667
        //        Electric_drive_powers_row[12]/Safety_coeffitients[7],//7,333
        //        Electric_drive_powers_row[13]/Safety_coeffitients[7],//10
        //        Electric_drive_powers_row[14]/Safety_coeffitients[7],//12,333
        //        Electric_drive_powers_row[15]/Safety_coeffitients[7],//14,667
        //        Electric_drive_powers_row[16]/Safety_coeffitients[7],//20
        //        Electric_drive_powers_row[17]/Safety_coeffitients[7],//24,667
        //        Electric_drive_powers_row[18]/Safety_coeffitients[7],//30
        //        Electric_drive_powers_row[19]/Safety_coeffitients[7],//36,667
        //        Electric_drive_powers_row[20]/Safety_coeffitients[7],//50
        //        Electric_drive_powers_row[21]/Safety_coeffitients[7],//60
        //        Electric_drive_powers_row[22]/Safety_coeffitients[7],//73,333
        //        Electric_drive_powers_row[23]/Safety_coeffitients[7],//88
        //        Electric_drive_powers_row[24]/Safety_coeffitients[7],//106,667
        //        Electric_drive_powers_row[25]/Safety_coeffitients[7],//133,333
        //        Electric_drive_powers_row[26]/Safety_coeffitients[7],//166,667
        //        Electric_drive_powers_row[27]/Safety_coeffitients[7],//210

        //    };


    }

}
