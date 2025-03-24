namespace MoreFeature
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.programMost = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.jsonList = new System.Windows.Forms.ComboBox();
            this.programAdmin = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.startAdmin = new System.Windows.Forms.CheckBox();
            this.startMost = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // programMost
            // 
            this.programMost.AutoSize = true;
            this.programMost.Location = new System.Drawing.Point(6, 22);
            this.programMost.Name = "programMost";
            this.programMost.Size = new System.Drawing.Size(75, 19);
            this.programMost.TabIndex = 1;
            this.programMost.Text = "Top most";
            this.toolTip1.SetToolTip(this.programMost, "MoreFeature runs top most if checked.");
            this.programMost.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.jsonList);
            this.groupBox1.Controls.Add(this.programAdmin);
            this.groupBox1.Controls.Add(this.programMost);
            this.groupBox1.Location = new System.Drawing.Point(17, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 126);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MoreFeature settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Default file list:";
            // 
            // jsonList
            // 
            this.jsonList.FormattingEnabled = true;
            this.jsonList.Location = new System.Drawing.Point(6, 87);
            this.jsonList.Name = "jsonList";
            this.jsonList.Size = new System.Drawing.Size(345, 23);
            this.jsonList.TabIndex = 3;
            this.jsonList.Text = "default.json";
            this.toolTip1.SetToolTip(this.jsonList, "MoreFeature loads selected file list at startup.");
            // 
            // programAdmin
            // 
            this.programAdmin.AutoSize = true;
            this.programAdmin.Location = new System.Drawing.Point(6, 47);
            this.programAdmin.Name = "programAdmin";
            this.programAdmin.Size = new System.Drawing.Size(98, 19);
            this.programAdmin.TabIndex = 2;
            this.programAdmin.Text = "Run as admin";
            this.toolTip1.SetToolTip(this.programAdmin, "MoreFeature runs as admin if checked ( and programs )");
            this.programAdmin.UseVisualStyleBackColor = true;
            this.programAdmin.CheckedChanged += new System.EventHandler(this.programAdmin_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.startAdmin);
            this.groupBox2.Controls.Add(this.startMost);
            this.groupBox2.Location = new System.Drawing.Point(17, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 135);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Program starting settings";
            // 
            // startAdmin
            // 
            this.startAdmin.AutoSize = true;
            this.startAdmin.Location = new System.Drawing.Point(6, 47);
            this.startAdmin.Name = "startAdmin";
            this.startAdmin.Size = new System.Drawing.Size(335, 19);
            this.startAdmin.TabIndex = 3;
            this.startAdmin.Text = "Run as admin ( checked if MoreFeature running as admin )";
            this.toolTip1.SetToolTip(this.startAdmin, "MoreFeature starting program as admin if checked ( checked if MoreFeature running" +
        " as admin )");
            this.startAdmin.UseVisualStyleBackColor = true;
            this.startAdmin.CheckedChanged += new System.EventHandler(this.startAdmin_CheckedChanged);
            // 
            // startMost
            // 
            this.startMost.AutoSize = true;
            this.startMost.Location = new System.Drawing.Point(6, 22);
            this.startMost.Name = "startMost";
            this.startMost.Size = new System.Drawing.Size(75, 19);
            this.startMost.TabIndex = 2;
            this.startMost.Text = "Top most";
            this.toolTip1.SetToolTip(this.startMost, "MoreFeature starting program top most if checked.");
            this.startMost.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(299, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(218, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(386, 359);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox programMost;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox programAdmin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox startAdmin;
        private System.Windows.Forms.CheckBox startMost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox jsonList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}