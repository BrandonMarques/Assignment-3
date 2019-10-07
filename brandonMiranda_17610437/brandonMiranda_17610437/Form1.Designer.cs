namespace brandonMiranda_17610437
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
            this.btnStartPause = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMap = new System.Windows.Forms.Label();
            this.tbxUnitInfo = new System.Windows.Forms.RichTextBox();
            this.lblRound = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.rtbBuildingsInfo = new System.Windows.Forms.RichTextBox();
            this.lblUnits = new System.Windows.Forms.Label();
            this.lblBuildings = new System.Windows.Forms.Label();
            this.txtXLength = new System.Windows.Forms.TextBox();
            this.txtYLength = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartPause
            // 
            this.btnStartPause.Location = new System.Drawing.Point(654, 250);
            this.btnStartPause.Name = "btnStartPause";
            this.btnStartPause.Size = new System.Drawing.Size(75, 23);
            this.btnStartPause.TabIndex = 0;
            this.btnStartPause.Text = "Start";
            this.btnStartPause.UseVisualStyleBackColor = true;
            this.btnStartPause.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(654, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMap.Location = new System.Drawing.Point(0, 0);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(46, 17);
            this.lblMap.TabIndex = 2;
            this.lblMap.Text = "label1";
            // 
            // tbxUnitInfo
            // 
            this.tbxUnitInfo.Location = new System.Drawing.Point(39, 269);
            this.tbxUnitInfo.Name = "tbxUnitInfo";
            this.tbxUnitInfo.Size = new System.Drawing.Size(169, 169);
            this.tbxUnitInfo.TabIndex = 3;
            this.tbxUnitInfo.Text = "";
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Location = new System.Drawing.Point(654, 95);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(46, 17);
            this.lblRound.TabIndex = 4;
            this.lblRound.Text = "label2";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(654, 309);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // rtbBuildingsInfo
            // 
            this.rtbBuildingsInfo.Location = new System.Drawing.Point(236, 269);
            this.rtbBuildingsInfo.Name = "rtbBuildingsInfo";
            this.rtbBuildingsInfo.Size = new System.Drawing.Size(177, 169);
            this.rtbBuildingsInfo.TabIndex = 6;
            this.rtbBuildingsInfo.Text = "";
            this.rtbBuildingsInfo.TextChanged += new System.EventHandler(this.rtbBuildingsInfo_TextChanged);
            // 
            // lblUnits
            // 
            this.lblUnits.AutoSize = true;
            this.lblUnits.Location = new System.Drawing.Point(509, 269);
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Size = new System.Drawing.Size(46, 17);
            this.lblUnits.TabIndex = 7;
            this.lblUnits.Text = "label1";
            // 
            // lblBuildings
            // 
            this.lblBuildings.AutoSize = true;
            this.lblBuildings.Location = new System.Drawing.Point(509, 366);
            this.lblBuildings.Name = "lblBuildings";
            this.lblBuildings.Size = new System.Drawing.Size(46, 17);
            this.lblBuildings.TabIndex = 8;
            this.lblBuildings.Text = "label2";
            // 
            // txtXLength
            // 
            this.txtXLength.Location = new System.Drawing.Point(654, 348);
            this.txtXLength.Name = "txtXLength";
            this.txtXLength.Size = new System.Drawing.Size(100, 22);
            this.txtXLength.TabIndex = 9;
            this.txtXLength.TextChanged += new System.EventHandler(this.txtXLength_TextChanged);
            // 
            // txtYLength
            // 
            this.txtYLength.Location = new System.Drawing.Point(654, 377);
            this.txtYLength.Name = "txtYLength";
            this.txtYLength.Size = new System.Drawing.Size(100, 22);
            this.txtYLength.TabIndex = 10;
            this.txtYLength.TextChanged += new System.EventHandler(this.txtYLength_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtYLength);
            this.Controls.Add(this.txtXLength);
            this.Controls.Add(this.lblBuildings);
            this.Controls.Add(this.lblUnits);
            this.Controls.Add(this.rtbBuildingsInfo);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.tbxUnitInfo);
            this.Controls.Add(this.lblMap);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnStartPause);
            this.Name = "Form1";
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartPause;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.RichTextBox tbxUnitInfo;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.RichTextBox rtbBuildingsInfo;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.Label lblBuildings;
        private System.Windows.Forms.TextBox txtXLength;
        private System.Windows.Forms.TextBox txtYLength;
    }
}

