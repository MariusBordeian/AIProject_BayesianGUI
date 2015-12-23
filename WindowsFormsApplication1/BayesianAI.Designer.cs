namespace WindowsFormsApplication1
{
    partial class BayesianAI
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.textBoxInfo = new System.Windows.Forms.RichTextBox();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.datasetTextBox = new System.Windows.Forms.RichTextBox();
            this.tabPageGraph = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.classIndex = new System.Windows.Forms.NumericUpDown();
            this.excludedIndexes = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.radioPrecizie = new System.Windows.Forms.RadioButton();
            this.radioLaplace = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCalc = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.tabPageGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 67);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1287, 0);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageInfo);
            this.tabControl1.Controls.Add(this.tabPageData);
            this.tabControl1.Controls.Add(this.tabPageGraph);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1287, 652);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.textBoxInfo);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(1279, 626);
            this.tabPageInfo.TabIndex = 1;
            this.tabPageInfo.Text = "Info";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInfo.Location = new System.Drawing.Point(3, 3);
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ReadOnly = true;
            this.textBoxInfo.Size = new System.Drawing.Size(1273, 620);
            this.textBoxInfo.TabIndex = 0;
            this.textBoxInfo.Text = "";
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.datasetTextBox);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Size = new System.Drawing.Size(1279, 626);
            this.tabPageData.TabIndex = 2;
            this.tabPageData.Text = "Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // datasetTextBox
            // 
            this.datasetTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datasetTextBox.Location = new System.Drawing.Point(0, 0);
            this.datasetTextBox.Name = "datasetTextBox";
            this.datasetTextBox.Size = new System.Drawing.Size(1279, 626);
            this.datasetTextBox.TabIndex = 18;
            this.datasetTextBox.Text = "";
            // 
            // tabPageGraph
            // 
            this.tabPageGraph.Controls.Add(this.pictureBox1);
            this.tabPageGraph.Location = new System.Drawing.Point(4, 22);
            this.tabPageGraph.Name = "tabPageGraph";
            this.tabPageGraph.Size = new System.Drawing.Size(1279, 626);
            this.tabPageGraph.TabIndex = 3;
            this.tabPageGraph.Text = "Graph";
            this.tabPageGraph.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1279, 626);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouse_D);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouse_M);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.classIndex);
            this.panel1.Controls.Add(this.excludedIndexes);
            this.panel1.Controls.Add(this.buttonLoad);
            this.panel1.Controls.Add(this.radioPrecizie);
            this.panel1.Controls.Add(this.radioLaplace);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonCalc);
            this.panel1.Controls.Add(this.resultTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1287, 67);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(231, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "(0-based)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "(nu si indexul clasei, despartitor folosit este \"virgula\")";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Indexul clasei";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Indecsi irelevanti";
            // 
            // classIndex
            // 
            this.classIndex.Location = new System.Drawing.Point(105, 7);
            this.classIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.classIndex.Name = "classIndex";
            this.classIndex.Size = new System.Drawing.Size(120, 20);
            this.classIndex.TabIndex = 4;
            // 
            // excludedIndexes
            // 
            this.excludedIndexes.Location = new System.Drawing.Point(105, 36);
            this.excludedIndexes.Name = "excludedIndexes";
            this.excludedIndexes.Size = new System.Drawing.Size(120, 20);
            this.excludedIndexes.TabIndex = 5;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(710, 7);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 30;
            this.buttonLoad.Text = "Load Data";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.loadData_Click);
            // 
            // radioPrecizie
            // 
            this.radioPrecizie.AutoSize = true;
            this.radioPrecizie.Location = new System.Drawing.Point(852, 35);
            this.radioPrecizie.Name = "radioPrecizie";
            this.radioPrecizie.Size = new System.Drawing.Size(93, 17);
            this.radioPrecizie.TabIndex = 29;
            this.radioPrecizie.TabStop = true;
            this.radioPrecizie.Text = "Precizie calcul";
            this.radioPrecizie.UseVisualStyleBackColor = true;
            // 
            // radioLaplace
            // 
            this.radioLaplace.AutoSize = true;
            this.radioLaplace.Checked = true;
            this.radioLaplace.Location = new System.Drawing.Point(852, 10);
            this.radioLaplace.Name = "radioLaplace";
            this.radioLaplace.Size = new System.Drawing.Size(105, 17);
            this.radioLaplace.TabIndex = 28;
            this.radioLaplace.TabStop = true;
            this.radioLaplace.Text = "Corectie Laplace";
            this.radioLaplace.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1121, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Result";
            // 
            // buttonCalc
            // 
            this.buttonCalc.Enabled = false;
            this.buttonCalc.Location = new System.Drawing.Point(710, 35);
            this.buttonCalc.Name = "buttonCalc";
            this.buttonCalc.Size = new System.Drawing.Size(75, 23);
            this.buttonCalc.TabIndex = 26;
            this.buttonCalc.Text = "Calculeaza";
            this.buttonCalc.UseVisualStyleBackColor = true;
            this.buttonCalc.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(1175, 10);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(100, 20);
            this.resultTextBox.TabIndex = 0;
            // 
            // BayesianAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 719);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "BayesianAI";
            this.Text = "Bayesian AI GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.tabPageGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.RichTextBox datasetTextBox;
        private System.Windows.Forms.TabPage tabPageGraph;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown classIndex;
        private System.Windows.Forms.TextBox excludedIndexes;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.RadioButton radioPrecizie;
        private System.Windows.Forms.RadioButton radioLaplace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCalc;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.RichTextBox textBoxInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

