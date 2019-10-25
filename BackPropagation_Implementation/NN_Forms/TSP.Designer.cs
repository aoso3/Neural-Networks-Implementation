namespace BackPropagation_Implementation.NN_Forms
{
    partial class TSP
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox7 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox6 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox5 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox2 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBox3 = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBox4 = new Telerik.WinControls.UI.RadTextBox();
            this.Button_Draw = new Telerik.WinControls.UI.RadButton();
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Draw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.IsMarksNextToAxis = false;
            chartArea2.AxisX.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MajorGrid.Interval = 0D;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chart1.Location = new System.Drawing.Point(171, 1);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(819, 500);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // radButton3
            // 
            this.radButton3.Location = new System.Drawing.Point(36, 441);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(100, 24);
            this.radButton3.TabIndex = 6;
            this.radButton3.Text = "Back";
            this.radButton3.ThemeName = "VisualStudio2012Dark";
            this.radButton3.Click += new System.EventHandler(this.radButton_Exit_Click);
            // 
            // radButton4
            // 
            this.radButton4.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            this.radButton4.Location = new System.Drawing.Point(33, 221);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(100, 24);
            this.radButton4.TabIndex = 6;
            this.radButton4.Text = "Go";
            this.radButton4.ThemeName = "VisualStudio2012Dark";
            this.radButton4.Click += new System.EventHandler(this.radButton_Go_Click);
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.Transparent;
            this.radPanel1.Controls.Add(this.radLabel8);
            this.radPanel1.Controls.Add(this.radLabel7);
            this.radPanel1.Controls.Add(this.radTextBox7);
            this.radPanel1.Controls.Add(this.radLabel5);
            this.radPanel1.Controls.Add(this.radTextBox6);
            this.radPanel1.Controls.Add(this.radLabel4);
            this.radPanel1.Controls.Add(this.radTextBox5);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.radTextBox2);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.radTextBox1);
            this.radPanel1.Controls.Add(this.radTextBox3);
            this.radPanel1.Controls.Add(this.radTextBox4);
            this.radPanel1.Controls.Add(this.Button_Draw);
            this.radPanel1.Controls.Add(this.radButton4);
            this.radPanel1.Controls.Add(this.radButton3);
            this.radPanel1.Location = new System.Drawing.Point(-3, 1);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(174, 500);
            this.radPanel1.TabIndex = 13;
            this.radPanel1.ThemeName = "VisualStudio2012Dark";
            // 
            // radLabel8
            // 
            this.radLabel8.ForeColor = System.Drawing.Color.White;
            this.radLabel8.Location = new System.Drawing.Point(15, 170);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(55, 18);
            this.radLabel8.TabIndex = 22;
            this.radLabel8.Text = "Stop Cost";
            // 
            // radLabel7
            // 
            this.radLabel7.ForeColor = System.Drawing.Color.White;
            this.radLabel7.Location = new System.Drawing.Point(15, 134);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(47, 18);
            this.radLabel7.TabIndex = 22;
            this.radLabel7.Text = "Max Iter";
            // 
            // radTextBox7
            // 
            this.radTextBox7.Location = new System.Drawing.Point(89, 170);
            this.radTextBox7.Name = "radTextBox7";
            this.radTextBox7.Size = new System.Drawing.Size(53, 21);
            this.radTextBox7.TabIndex = 21;
            this.radTextBox7.ThemeName = "VisualStudio2012Dark";
            // 
            // radLabel5
            // 
            this.radLabel5.ForeColor = System.Drawing.Color.White;
            this.radLabel5.Location = new System.Drawing.Point(59, 330);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(53, 18);
            this.radLabel5.TabIndex = 23;
            this.radLabel5.Text = "Cost Way";
            // 
            // radTextBox6
            // 
            this.radTextBox6.Location = new System.Drawing.Point(89, 134);
            this.radTextBox6.Name = "radTextBox6";
            this.radTextBox6.Size = new System.Drawing.Size(53, 21);
            this.radTextBox6.TabIndex = 21;
            this.radTextBox6.ThemeName = "VisualStudio2012Dark";
            // 
            // radLabel4
            // 
            this.radLabel4.ForeColor = System.Drawing.Color.White;
            this.radLabel4.Location = new System.Drawing.Point(71, 385);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(30, 18);
            this.radLabel4.TabIndex = 22;
            this.radLabel4.Text = "Error";
            // 
            // radTextBox5
            // 
            this.radTextBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.radTextBox5.Enabled = false;
            this.radTextBox5.ForeColor = System.Drawing.Color.White;
            this.radTextBox5.Location = new System.Drawing.Point(41, 408);
            this.radTextBox5.Name = "radTextBox5";
            this.radTextBox5.Size = new System.Drawing.Size(99, 21);
            this.radTextBox5.TabIndex = 21;
            this.radTextBox5.ThemeName = "VisualStudio2012Dark";
            // 
            // radLabel3
            // 
            this.radLabel3.ForeColor = System.Drawing.Color.White;
            this.radLabel3.Location = new System.Drawing.Point(15, 97);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(65, 18);
            this.radLabel3.TabIndex = 20;
            this.radLabel3.Text = "Tempruture";
            // 
            // radLabel2
            // 
            this.radLabel2.ForeColor = System.Drawing.Color.White;
            this.radLabel2.Location = new System.Drawing.Point(15, 61);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(65, 18);
            this.radLabel2.TabIndex = 20;
            this.radLabel2.Text = "Cooling Fac";
            // 
            // radTextBox2
            // 
            this.radTextBox2.Location = new System.Drawing.Point(89, 97);
            this.radTextBox2.Name = "radTextBox2";
            this.radTextBox2.Size = new System.Drawing.Size(53, 21);
            this.radTextBox2.TabIndex = 19;
            this.radTextBox2.ThemeName = "VisualStudio2012Dark";
            // 
            // radLabel1
            // 
            this.radLabel1.ForeColor = System.Drawing.Color.White;
            this.radLabel1.Location = new System.Drawing.Point(15, 25);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(53, 18);
            this.radLabel1.TabIndex = 18;
            this.radLabel1.Text = "City Num";
            // 
            // radTextBox1
            // 
            this.radTextBox1.Location = new System.Drawing.Point(89, 61);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(53, 21);
            this.radTextBox1.TabIndex = 19;
            this.radTextBox1.ThemeName = "VisualStudio2012Dark";
            // 
            // radTextBox3
            // 
            this.radTextBox3.Location = new System.Drawing.Point(89, 25);
            this.radTextBox3.Name = "radTextBox3";
            this.radTextBox3.Size = new System.Drawing.Size(53, 21);
            this.radTextBox3.TabIndex = 17;
            this.radTextBox3.ThemeName = "VisualStudio2012Dark";
            // 
            // radTextBox4
            // 
            this.radTextBox4.BackColor = System.Drawing.Color.Orange;
            this.radTextBox4.Enabled = false;
            this.radTextBox4.ForeColor = System.Drawing.Color.White;
            this.radTextBox4.Location = new System.Drawing.Point(39, 361);
            this.radTextBox4.Name = "radTextBox4";
            this.radTextBox4.Size = new System.Drawing.Size(99, 21);
            this.radTextBox4.TabIndex = 5;
            this.radTextBox4.ThemeName = "VisualStudio2012Dark";
            // 
            // Button_Draw
            // 
            this.Button_Draw.Location = new System.Drawing.Point(36, 296);
            this.Button_Draw.Name = "Button_Draw";
            this.Button_Draw.Size = new System.Drawing.Size(99, 24);
            this.Button_Draw.TabIndex = 2;
            this.Button_Draw.Text = "Drow";
            this.Button_Draw.ThemeName = "VisualStudio2012Dark";
            this.Button_Draw.Click += new System.EventHandler(this.Button_Draw_Click);
            // 
            // TSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 466);
            this.ControlBox = false;
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Segoe Print", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TSP";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.ThemeName = "VisualStudio2012Dark";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Draw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadButton radButton4;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadTextBox radTextBox3;
        private Telerik.WinControls.UI.RadButton Button_Draw;
        private Telerik.WinControls.UI.RadTextBox radTextBox4;
        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox radTextBox2;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadTextBox radTextBox5;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadTextBox radTextBox7;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox radTextBox6;
        private Telerik.WinControls.UI.RadLabel radLabel4;
    }
}
