namespace GraphicsPackage.Forms
{
    partial class DrawingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.drawPanel = new System.Windows.Forms.Panel();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtX0 = new System.Windows.Forms.TextBox();
            this.txtYcE = new System.Windows.Forms.TextBox();
            this.txtXcC = new System.Windows.Forms.TextBox();
            this.txtYcC = new System.Windows.Forms.TextBox();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.txtXcE = new System.Windows.Forms.TextBox();
            this.txtYEnd = new System.Windows.Forms.TextBox();
            this.txtXEnd = new System.Windows.Forms.TextBox();
            this.txtY0 = new System.Windows.Forms.TextBox();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnColour = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRx = new System.Windows.Forms.TextBox();
            this.txtRy = new System.Windows.Forms.TextBox();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.inputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawPanel
            // 
            this.drawPanel.Location = new System.Drawing.Point(783, 23);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(625, 413);
            this.drawPanel.TabIndex = 2;
            // 
            // grid
            // 
            this.grid.AllowUserToOrderColumns = true;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Constantia", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "-";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column14,
            this.Column16,
            this.Column8,
            this.Column9,
            this.Column13});
            this.grid.Cursor = System.Windows.Forms.Cursors.No;
            this.grid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grid.Location = new System.Drawing.Point(0, 442);
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(1420, 280);
            this.grid.TabIndex = 0;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(188, 366);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(157, 35);
            this.btnDraw.TabIndex = 3;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(411, 366);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(157, 35);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtX0
            // 
            this.txtX0.Location = new System.Drawing.Point(199, 80);
            this.txtX0.Name = "txtX0";
            this.txtX0.Size = new System.Drawing.Size(146, 28);
            this.txtX0.TabIndex = 1;
            this.txtX0.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtYcE
            // 
            this.txtYcE.Location = new System.Drawing.Point(584, 286);
            this.txtYcE.Name = "txtYcE";
            this.txtYcE.Size = new System.Drawing.Size(147, 28);
            this.txtYcE.TabIndex = 2;
            // 
            // txtXcC
            // 
            this.txtXcC.Location = new System.Drawing.Point(199, 180);
            this.txtXcC.Name = "txtXcC";
            this.txtXcC.Size = new System.Drawing.Size(146, 28);
            this.txtXcC.TabIndex = 3;
            // 
            // txtYcC
            // 
            this.txtYcC.Location = new System.Drawing.Point(584, 180);
            this.txtYcC.Name = "txtYcC";
            this.txtYcC.Size = new System.Drawing.Size(147, 28);
            this.txtYcC.TabIndex = 4;
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(199, 217);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(146, 28);
            this.txtRadius.TabIndex = 5;
            // 
            // txtXcE
            // 
            this.txtXcE.Location = new System.Drawing.Point(199, 286);
            this.txtXcE.Name = "txtXcE";
            this.txtXcE.Size = new System.Drawing.Size(146, 28);
            this.txtXcE.TabIndex = 6;
            this.txtXcE.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // txtYEnd
            // 
            this.txtYEnd.Location = new System.Drawing.Point(584, 117);
            this.txtYEnd.Name = "txtYEnd";
            this.txtYEnd.Size = new System.Drawing.Size(147, 28);
            this.txtYEnd.TabIndex = 7;
            // 
            // txtXEnd
            // 
            this.txtXEnd.Location = new System.Drawing.Point(584, 80);
            this.txtXEnd.Name = "txtXEnd";
            this.txtXEnd.Size = new System.Drawing.Size(147, 28);
            this.txtXEnd.TabIndex = 8;
            // 
            // txtY0
            // 
            this.txtY0.Location = new System.Drawing.Point(199, 117);
            this.txtY0.Name = "txtY0";
            this.txtY0.Size = new System.Drawing.Size(146, 28);
            this.txtY0.TabIndex = 9;
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.btnSave);
            this.inputPanel.Controls.Add(this.btnColour);
            this.inputPanel.Controls.Add(this.label14);
            this.inputPanel.Controls.Add(this.label13);
            this.inputPanel.Controls.Add(this.label12);
            this.inputPanel.Controls.Add(this.label11);
            this.inputPanel.Controls.Add(this.label10);
            this.inputPanel.Controls.Add(this.label9);
            this.inputPanel.Controls.Add(this.label8);
            this.inputPanel.Controls.Add(this.label7);
            this.inputPanel.Controls.Add(this.label6);
            this.inputPanel.Controls.Add(this.label5);
            this.inputPanel.Controls.Add(this.label4);
            this.inputPanel.Controls.Add(this.label3);
            this.inputPanel.Controls.Add(this.label2);
            this.inputPanel.Controls.Add(this.label1);
            this.inputPanel.Controls.Add(this.btnClear);
            this.inputPanel.Controls.Add(this.txtRx);
            this.inputPanel.Controls.Add(this.txtRy);
            this.inputPanel.Controls.Add(this.txtY0);
            this.inputPanel.Controls.Add(this.btnDraw);
            this.inputPanel.Controls.Add(this.txtXEnd);
            this.inputPanel.Controls.Add(this.txtYEnd);
            this.inputPanel.Controls.Add(this.txtXcE);
            this.inputPanel.Controls.Add(this.txtRadius);
            this.inputPanel.Controls.Add(this.txtYcC);
            this.inputPanel.Controls.Add(this.txtXcC);
            this.inputPanel.Controls.Add(this.txtYcE);
            this.inputPanel.Controls.Add(this.txtX0);
            this.inputPanel.Controls.Add(this.cmbAlgorithm);
            this.inputPanel.Font = new System.Drawing.Font("Constantia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputPanel.Location = new System.Drawing.Point(12, 23);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(752, 413);
            this.inputPanel.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(574, 366);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(157, 35);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnColour
            // 
            this.btnColour.Location = new System.Drawing.Point(25, 366);
            this.btnColour.Name = "btnColour";
            this.btnColour.Size = new System.Drawing.Size(157, 35);
            this.btnColour.TabIndex = 26;
            this.btnColour.Text = "Select Colour";
            this.btnColour.UseVisualStyleBackColor = true;
            this.btnColour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(39, 154);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 24);
            this.label14.TabIndex = 25;
            this.label14.Text = "CIRCLE:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(39, 259);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 24);
            this.label13.TabIndex = 24;
            this.label13.Text = "ELLIPSE:";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(39, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 24);
            this.label12.TabIndex = 23;
            this.label12.Text = "LINE:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 333);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 21);
            this.label11.TabIndex = 22;
            this.label11.Text = "Rx:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 21);
            this.label10.TabIndex = 21;
            this.label10.Text = "Xc:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(468, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 21);
            this.label9.TabIndex = 20;
            this.label9.Text = "Ry:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(468, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 21);
            this.label8.TabIndex = 19;
            this.label8.Text = "Yc:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 21);
            this.label7.TabIndex = 18;
            this.label7.Text = "Xc:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "Radius:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(469, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 21);
            this.label5.TabIndex = 16;
            this.label5.Text = "XEnd:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "Y0:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(469, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "YEnd:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(469, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Yc:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "X0:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtRx
            // 
            this.txtRx.Location = new System.Drawing.Point(199, 326);
            this.txtRx.Name = "txtRx";
            this.txtRx.Size = new System.Drawing.Size(146, 28);
            this.txtRx.TabIndex = 11;
            this.txtRx.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            // 
            // txtRy
            // 
            this.txtRy.Location = new System.Drawing.Point(584, 326);
            this.txtRy.Name = "txtRy";
            this.txtRy.Size = new System.Drawing.Size(147, 28);
            this.txtRy.TabIndex = 10;
            // 
            // cmbAlgorithm
            // 
            this.cmbAlgorithm.FormattingEnabled = true;
            this.cmbAlgorithm.Items.AddRange(new object[] {
            "Line DDA",
            "Line Bresenham",
            "Circle Bresenham",
            "Ellipse Bresenham"});
            this.cmbAlgorithm.Location = new System.Drawing.Point(21, 14);
            this.cmbAlgorithm.Name = "cmbAlgorithm";
            this.cmbAlgorithm.Size = new System.Drawing.Size(710, 29);
            this.cmbAlgorithm.TabIndex = 0;
            this.cmbAlgorithm.Text = "Choose Algorithm";
            this.cmbAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cmbAlgorithm_SelectedIndexChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "K";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Pk";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "X";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Y";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "(X,Y)";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "2X";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "2Y";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 80;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "P1k";
            this.Column14.MinimumWidth = 6;
            this.Column14.Name = "Column14";
            this.Column14.Width = 80;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "P2k";
            this.Column16.MinimumWidth = 6;
            this.Column16.Name = "Column16";
            this.Column16.Width = 80;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "2Rx^2Yk+1";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "2Ry^2Xk+1";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Region";
            this.Column13.MinimumWidth = 6;
            this.Column13.Name = "Column13";
            this.Column13.Width = 80;
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 722);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.inputPanel);
            this.Name = "DrawingForm";
            this.Text = "DrawingForm";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtX0;
        private System.Windows.Forms.TextBox txtYcE;
        private System.Windows.Forms.TextBox txtXcC;
        private System.Windows.Forms.TextBox txtYcC;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.TextBox txtXcE;
        private System.Windows.Forms.TextBox txtYEnd;
        private System.Windows.Forms.TextBox txtXEnd;
        private System.Windows.Forms.TextBox txtY0;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.TextBox txtRx;
        private System.Windows.Forms.TextBox txtRy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAlgorithm;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnColour;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
    }
}