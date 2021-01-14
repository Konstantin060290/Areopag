using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Areopag.WF.PulsationDampanerSelection
{
    public class Operation
    {
        public const string about = "Данная программа позволяет произвести расчет полного" +
            " газового объема ПГА по первому и второму способам книги Бурданова В.Н. \"Дозирование жидкости объемными насосами\"";
        public const string version= "Версия - 0.0.2";
        public const string year_author = "Автор - Филюрин К.В. 2020 год";
        public double Q_max { get; set; }
        public double Strokes { get; set; }
        public double P_2 { get; set; }
        public double P_1 { get; set; }
        public double P_sr { get; set; }
        public double V_sw { get; set; }
        public double Delta_r { get; set; }
        public double P_d { get; set; }
        public double V0_1 { get; set; }//объем по первому способу
        public double V0_2 { get; set; }//объем по второму способу
        public double K { get; set; }
        
        
        public void CalcVoluemu_1()
        {
            V_sw = Q_max / (60 * Strokes);
            P_sr = (P_1 + P_2) / 2;
            Delta_r = (P_2 - P_sr) / P_sr;
            P_d = P_sr * 0.78;
            V0_1 = K * V_sw / (Math.Pow((P_d / P_1), 0.714) - Math.Pow((P_d / P_2), 0.714));

        }
        public void CalcVoluemu_2()
        {
            V_sw = Q_max / (60 * Strokes);
            P_sr = (P_2 / (Delta_r + 1));
            P_d = P_sr * 0.78;
            V0_2 = K * V_sw * Math.Pow((P_sr / P_d), 0.714) / (1 / Math.Pow((1 - (Delta_r / 100)), 0.714) - 1 / Math.Pow((1 + (Delta_r / 100)), 0.714));

        }

        
    }
}
