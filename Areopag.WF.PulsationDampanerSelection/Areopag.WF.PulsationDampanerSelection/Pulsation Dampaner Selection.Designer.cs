namespace Areopag.WF.PulsationDampanerSelection
{
    partial class PulsationDampanerSelectionForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PulsationDampanerSelectionForm));
            this.QapacityTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StrokesTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.P2TextBox = new System.Windows.Forms.TextBox();
            this.P1TextBox = new System.Windows.Forms.TextBox();
            this.P1Label = new System.Windows.Forms.Label();
            this.Volume_TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Calculation = new System.Windows.Forms.Button();
            this.V0Tip = new System.Windows.Forms.ToolTip(this.components);
            this.OneHeadRb = new System.Windows.Forms.RadioButton();
            this.TwoHeadRb = new System.Windows.Forms.RadioButton();
            this.ThreeHeadRb = new System.Windows.Forms.RadioButton();
            this.Delta_rTb = new System.Windows.Forms.TextBox();
            this.DeltaP_label = new System.Windows.Forms.Label();
            this.Way1Rb = new System.Windows.Forms.RadioButton();
            this.Way2Rb = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.about = new System.Windows.Forms.Button();
            this.k_coefficient = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QapacityTextBox
            // 
            this.QapacityTextBox.Location = new System.Drawing.Point(184, 38);
            this.QapacityTextBox.Name = "QapacityTextBox";
            this.QapacityTextBox.Size = new System.Drawing.Size(244, 20);
            this.QapacityTextBox.TabIndex = 0;
            this.QapacityTextBox.TextChanged += new System.EventHandler(this.QapacityTextBox_TextChanged);
            this.QapacityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QapacityTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Максимальная величина подачи, которая ожидается при эксплуатационных условиях, л/" +
    "ч";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(42, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Число двойных ходов плунжера, ход/мин";
            // 
            // StrokesTextBox
            // 
            this.StrokesTextBox.Location = new System.Drawing.Point(184, 92);
            this.StrokesTextBox.Name = "StrokesTextBox";
            this.StrokesTextBox.Size = new System.Drawing.Size(244, 20);
            this.StrokesTextBox.TabIndex = 1;
            this.StrokesTextBox.TextChanged += new System.EventHandler(this.StrokesTextBox_TextChanged);
            this.StrokesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StrokesTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(112, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "P2, МПа";
            // 
            // P2TextBox
            // 
            this.P2TextBox.Location = new System.Drawing.Point(184, 134);
            this.P2TextBox.Name = "P2TextBox";
            this.P2TextBox.Size = new System.Drawing.Size(244, 20);
            this.P2TextBox.TabIndex = 2;
            this.P2TextBox.TextChanged += new System.EventHandler(this.P2TextBox_TextChanged);
            this.P2TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.P2TextBox_KeyPress);
            // 
            // P1TextBox
            // 
            this.P1TextBox.Location = new System.Drawing.Point(184, 179);
            this.P1TextBox.Name = "P1TextBox";
            this.P1TextBox.Size = new System.Drawing.Size(244, 20);
            this.P1TextBox.TabIndex = 3;
            this.P1TextBox.TextChanged += new System.EventHandler(this.P1TextBox_TextChanged);
            this.P1TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.P1TextBox_KeyPress);
            // 
            // P1Label
            // 
            this.P1Label.Location = new System.Drawing.Point(112, 182);
            this.P1Label.Name = "P1Label";
            this.P1Label.Size = new System.Drawing.Size(52, 20);
            this.P1Label.TabIndex = 1;
            this.P1Label.Text = "P1, МПа";
            // 
            // Volume_TextBox
            // 
            this.Volume_TextBox.Location = new System.Drawing.Point(184, 331);
            this.Volume_TextBox.Name = "Volume_TextBox";
            this.Volume_TextBox.Size = new System.Drawing.Size(244, 20);
            this.Volume_TextBox.TabIndex = 5;
            this.Volume_TextBox.Text = "0";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(112, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "V0, л";
            // 
            // Calculation
            // 
            this.Calculation.Location = new System.Drawing.Point(252, 263);
            this.Calculation.Name = "Calculation";
            this.Calculation.Size = new System.Drawing.Size(118, 42);
            this.Calculation.TabIndex = 4;
            this.Calculation.Text = "Выполнить расчет";
            this.Calculation.UseVisualStyleBackColor = true;
            this.Calculation.Click += new System.EventHandler(this.Calculation_Click);
            // 
            // V0Tip
            // 
            this.V0Tip.Tag = "";
            // 
            // OneHeadRb
            // 
            this.OneHeadRb.AutoSize = true;
            this.OneHeadRb.Checked = true;
            this.OneHeadRb.Location = new System.Drawing.Point(447, 32);
            this.OneHeadRb.Name = "OneHeadRb";
            this.OneHeadRb.Size = new System.Drawing.Size(157, 30);
            this.OneHeadRb.TabIndex = 6;
            this.OneHeadRb.TabStop = true;
            this.OneHeadRb.Text = "Одноголовочный насос\r\nодностороннего действия";
            this.OneHeadRb.UseVisualStyleBackColor = true;
            this.OneHeadRb.CheckedChanged += new System.EventHandler(this.OneHeadRb_CheckedChanged);
            // 
            // TwoHeadRb
            // 
            this.TwoHeadRb.AutoSize = true;
            this.TwoHeadRb.Location = new System.Drawing.Point(447, 68);
            this.TwoHeadRb.Name = "TwoHeadRb";
            this.TwoHeadRb.Size = new System.Drawing.Size(197, 82);
            this.TwoHeadRb.TabIndex = 6;
            this.TwoHeadRb.Text = "Двухголовочный насос\r\nс головками одностороннего\r\nдействия или одноголовочный\r\nна" +
    "сос с головкой двухстороннего\r\nдействия (такт хода плунжеров\r\nсмещен на 180˚)";
            this.TwoHeadRb.UseVisualStyleBackColor = true;
            this.TwoHeadRb.CheckedChanged += new System.EventHandler(this.TwoHeadRb_CheckedChanged);
            // 
            // ThreeHeadRb
            // 
            this.ThreeHeadRb.AutoSize = true;
            this.ThreeHeadRb.Location = new System.Drawing.Point(447, 156);
            this.ThreeHeadRb.Name = "ThreeHeadRb";
            this.ThreeHeadRb.Size = new System.Drawing.Size(157, 56);
            this.ThreeHeadRb.TabIndex = 6;
            this.ThreeHeadRb.Text = "Трехголовочный насос\r\nодностороннего действия\r\n(такт хода плунжеров\r\nсмещен на 12" +
    "0˚)";
            this.ThreeHeadRb.UseVisualStyleBackColor = true;
            this.ThreeHeadRb.CheckedChanged += new System.EventHandler(this.ThreeHeadRb_CheckedChanged);
            // 
            // Delta_rTb
            // 
            this.Delta_rTb.Location = new System.Drawing.Point(184, 220);
            this.Delta_rTb.Name = "Delta_rTb";
            this.Delta_rTb.Size = new System.Drawing.Size(244, 20);
            this.Delta_rTb.TabIndex = 8;
            this.Delta_rTb.TextChanged += new System.EventHandler(this.delta_rTb_TextChanged);
            this.Delta_rTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Delta_rTb_KeyPress);
            // 
            // DeltaP_label
            // 
            this.DeltaP_label.Location = new System.Drawing.Point(125, 220);
            this.DeltaP_label.Name = "DeltaP_label";
            this.DeltaP_label.Size = new System.Drawing.Size(39, 20);
            this.DeltaP_label.TabIndex = 9;
            this.DeltaP_label.Text = "бр, %";
            // 
            // Way1Rb
            // 
            this.Way1Rb.AutoSize = true;
            this.Way1Rb.Checked = true;
            this.Way1Rb.Location = new System.Drawing.Point(10, 9);
            this.Way1Rb.Name = "Way1Rb";
            this.Way1Rb.Size = new System.Drawing.Size(71, 17);
            this.Way1Rb.TabIndex = 10;
            this.Way1Rb.TabStop = true;
            this.Way1Rb.Text = "Способ 1";
            this.Way1Rb.UseVisualStyleBackColor = true;
            this.Way1Rb.CheckedChanged += new System.EventHandler(this.Way1Rb_CheckedChanged);
            // 
            // Way2Rb
            // 
            this.Way2Rb.AutoSize = true;
            this.Way2Rb.Location = new System.Drawing.Point(10, 32);
            this.Way2Rb.Name = "Way2Rb";
            this.Way2Rb.Size = new System.Drawing.Size(71, 17);
            this.Way2Rb.TabIndex = 10;
            this.Way2Rb.Text = "Способ 2";
            this.Way2Rb.UseVisualStyleBackColor = true;
            this.Way2Rb.CheckedChanged += new System.EventHandler(this.Way2Rb_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Way1Rb);
            this.panel1.Controls.Add(this.Way2Rb);
            this.panel1.Location = new System.Drawing.Point(465, 220);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 64);
            this.panel1.TabIndex = 11;
            // 
            // about
            // 
            this.about.Location = new System.Drawing.Point(563, 326);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(75, 23);
            this.about.TabIndex = 13;
            this.about.Text = "Справка";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // k_coefficient
            // 
            this.k_coefficient.AutoSize = true;
            this.k_coefficient.Location = new System.Drawing.Point(483, 7);
            this.k_coefficient.Name = "k_coefficient";
            this.k_coefficient.Size = new System.Drawing.Size(92, 13);
            this.k_coefficient.TabIndex = 14;
            this.k_coefficient.Text = "Коэффициент k=";
            // 
            // PulsationDampanerSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(650, 377);
            this.Controls.Add(this.k_coefficient);
            this.Controls.Add(this.about);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DeltaP_label);
            this.Controls.Add(this.Delta_rTb);
            this.Controls.Add(this.ThreeHeadRb);
            this.Controls.Add(this.TwoHeadRb);
            this.Controls.Add(this.OneHeadRb);
            this.Controls.Add(this.Calculation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.P1Label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Volume_TextBox);
            this.Controls.Add(this.P1TextBox);
            this.Controls.Add(this.P2TextBox);
            this.Controls.Add(this.StrokesTextBox);
            this.Controls.Add(this.QapacityTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PulsationDampanerSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расчет объема ПГА";
            this.Load += new System.EventHandler(this.PulsationDampanerSelectionForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox QapacityTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox StrokesTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox P2TextBox;
        private System.Windows.Forms.TextBox P1TextBox;
        private System.Windows.Forms.Label P1Label;
        private System.Windows.Forms.TextBox Volume_TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Calculation;
        private System.Windows.Forms.ToolTip V0Tip;
        private System.Windows.Forms.RadioButton OneHeadRb;
        private System.Windows.Forms.RadioButton TwoHeadRb;
        private System.Windows.Forms.RadioButton ThreeHeadRb;
        private System.Windows.Forms.TextBox Delta_rTb;
        private System.Windows.Forms.Label DeltaP_label;
        private System.Windows.Forms.RadioButton Way1Rb;
        private System.Windows.Forms.RadioButton Way2Rb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button about;
        private System.Windows.Forms.Label k_coefficient;
    }
}

