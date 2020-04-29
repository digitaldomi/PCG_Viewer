namespace TestRealTimeCharts
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pcgChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_Start = new System.Windows.Forms.Button();
            this.textBox_ComPort = new System.Windows.Forms.TextBox();
            this.label_ComPort = new System.Windows.Forms.Label();
            this.checkBox_LowFrequencyEnable = new System.Windows.Forms.CheckBox();
            this.button_Recording = new System.Windows.Forms.Button();
            this.label_FileName = new System.Windows.Forms.Label();
            this.textBox_FileName = new System.Windows.Forms.TextBox();
            this.button_ComPortConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcgChart)).BeginInit();
            this.SuspendLayout();
            // 
            // pcgChart
            // 
            chartArea1.Name = "ChartArea1";
            this.pcgChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.pcgChart.Legends.Add(legend1);
            this.pcgChart.Location = new System.Drawing.Point(13, 12);
            this.pcgChart.Name = "pcgChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.MarkerSize = 1;
            series1.Name = "PCG";
            series1.YValuesPerPoint = 2;
            this.pcgChart.Series.Add(series1);
            this.pcgChart.Size = new System.Drawing.Size(1246, 452);
            this.pcgChart.TabIndex = 0;
            this.pcgChart.Text = "chart1";
            // 
            // button_Start
            // 
            this.button_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Start.Location = new System.Drawing.Point(1083, 489);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(175, 45);
            this.button_Start.TabIndex = 1;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_ComPort
            // 
            this.textBox_ComPort.Location = new System.Drawing.Point(954, 489);
            this.textBox_ComPort.Name = "textBox_ComPort";
            this.textBox_ComPort.Size = new System.Drawing.Size(113, 20);
            this.textBox_ComPort.TabIndex = 2;
            this.textBox_ComPort.Text = "COM8";
            // 
            // label_ComPort
            // 
            this.label_ComPort.AutoSize = true;
            this.label_ComPort.Location = new System.Drawing.Point(864, 492);
            this.label_ComPort.Name = "label_ComPort";
            this.label_ComPort.Size = new System.Drawing.Size(84, 13);
            this.label_ComPort.TabIndex = 3;
            this.label_ComPort.Text = "Enter COM Port:";
            this.label_ComPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_ComPort.Click += new System.EventHandler(this.label_ComPort_Click);
            // 
            // checkBox_LowFrequencyEnable
            // 
            this.checkBox_LowFrequencyEnable.AutoSize = true;
            this.checkBox_LowFrequencyEnable.Location = new System.Drawing.Point(13, 491);
            this.checkBox_LowFrequencyEnable.Name = "checkBox_LowFrequencyEnable";
            this.checkBox_LowFrequencyEnable.Size = new System.Drawing.Size(228, 17);
            this.checkBox_LowFrequencyEnable.TabIndex = 4;
            this.checkBox_LowFrequencyEnable.Text = "Include Low Frequency Range (6Hz-20Hz)";
            this.checkBox_LowFrequencyEnable.UseVisualStyleBackColor = true;
            // 
            // button_Recording
            // 
            this.button_Recording.Enabled = false;
            this.button_Recording.Location = new System.Drawing.Point(323, 485);
            this.button_Recording.Name = "button_Recording";
            this.button_Recording.Size = new System.Drawing.Size(99, 23);
            this.button_Recording.TabIndex = 5;
            this.button_Recording.Text = "Start Recording";
            this.button_Recording.UseVisualStyleBackColor = true;
            this.button_Recording.Click += new System.EventHandler(this.button_Recording_Click);
            // 
            // label_FileName
            // 
            this.label_FileName.AutoSize = true;
            this.label_FileName.Location = new System.Drawing.Point(320, 518);
            this.label_FileName.Name = "label_FileName";
            this.label_FileName.Size = new System.Drawing.Size(58, 13);
            this.label_FileName.TabIndex = 6;
            this.label_FileName.Text = "File name: ";
            // 
            // textBox_FileName
            // 
            this.textBox_FileName.Location = new System.Drawing.Point(385, 518);
            this.textBox_FileName.Name = "textBox_FileName";
            this.textBox_FileName.Size = new System.Drawing.Size(182, 20);
            this.textBox_FileName.TabIndex = 7;
            this.textBox_FileName.Text = "PCG_20200101_121212.txt";
            // 
            // button_ComPortConfig
            // 
            this.button_ComPortConfig.Location = new System.Drawing.Point(954, 511);
            this.button_ComPortConfig.Name = "button_ComPortConfig";
            this.button_ComPortConfig.Size = new System.Drawing.Size(113, 23);
            this.button_ComPortConfig.TabIndex = 8;
            this.button_ComPortConfig.Text = "Show COM config";
            this.button_ComPortConfig.UseVisualStyleBackColor = true;
            this.button_ComPortConfig.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 544);
            this.Controls.Add(this.button_ComPortConfig);
            this.Controls.Add(this.textBox_FileName);
            this.Controls.Add(this.label_FileName);
            this.Controls.Add(this.button_Recording);
            this.Controls.Add(this.checkBox_LowFrequencyEnable);
            this.Controls.Add(this.label_ComPort);
            this.Controls.Add(this.textBox_ComPort);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.pcgChart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Phonocardiograph";
            ((System.ComponentModel.ISupportInitialize)(this.pcgChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart pcgChart;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.TextBox textBox_ComPort;
        private System.Windows.Forms.Label label_ComPort;
        private System.Windows.Forms.CheckBox checkBox_LowFrequencyEnable;
        private System.Windows.Forms.Button button_Recording;
        private System.Windows.Forms.Label label_FileName;
        private System.Windows.Forms.TextBox textBox_FileName;
        private System.Windows.Forms.Button button_ComPortConfig;
    }
}

