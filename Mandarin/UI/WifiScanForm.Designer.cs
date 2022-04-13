namespace Mandarin
{
    partial class WifiScanForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WifiScanForm));
            this.WifilistBox = new System.Windows.Forms.ListBox();
            this.scanbutton1 = new System.Windows.Forms.Button();
            this.okbutton = new System.Windows.Forms.Button();
            this.Cancelbut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WifilistBox
            // 
            this.WifilistBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.WifilistBox.FormattingEnabled = true;
            this.WifilistBox.Location = new System.Drawing.Point(0, 0);
            this.WifilistBox.Name = "WifilistBox";
            this.WifilistBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.WifilistBox.Size = new System.Drawing.Size(275, 316);
            this.WifilistBox.TabIndex = 0;
            // 
            // scanbutton1
            // 
            this.scanbutton1.Location = new System.Drawing.Point(107, 322);
            this.scanbutton1.Name = "scanbutton1";
            this.scanbutton1.Size = new System.Drawing.Size(75, 23);
            this.scanbutton1.TabIndex = 1;
            this.scanbutton1.TabStop = false;
            this.scanbutton1.Text = "Scan";
            this.scanbutton1.UseVisualStyleBackColor = true;
            this.scanbutton1.Click += new System.EventHandler(this.scanbutton1_Click);
            // 
            // okbutton
            // 
            this.okbutton.Location = new System.Drawing.Point(188, 322);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(75, 23);
            this.okbutton.TabIndex = 0;
            this.okbutton.Text = "OK";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // Cancelbut
            // 
            this.Cancelbut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelbut.Location = new System.Drawing.Point(12, 322);
            this.Cancelbut.Name = "Cancelbut";
            this.Cancelbut.Size = new System.Drawing.Size(75, 23);
            this.Cancelbut.TabIndex = 3;
            this.Cancelbut.Text = "Cancel";
            this.Cancelbut.UseVisualStyleBackColor = true;
            this.Cancelbut.Click += new System.EventHandler(this.Cancelbut_Click);
            // 
            // WifiScanForm
            // 
            this.AcceptButton = this.okbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancelbut;
            this.ClientSize = new System.Drawing.Size(275, 351);
            this.ControlBox = false;
            this.Controls.Add(this.Cancelbut);
            this.Controls.Add(this.okbutton);
            this.Controls.Add(this.scanbutton1);
            this.Controls.Add(this.WifilistBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WifiScanForm";
            this.Text = "WifiScanForm";
            this.Load += new System.EventHandler(this.WifiScanForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox WifilistBox;
        private System.Windows.Forms.Button scanbutton1;
        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.Button Cancelbut;
    }
}