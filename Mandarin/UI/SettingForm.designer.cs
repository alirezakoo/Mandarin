using System.Windows.Forms;

namespace Mandarin
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.cboLocalNet = new System.Windows.Forms.ComboBox();
            this.cboInternet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtProxyServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.butRef = new System.Windows.Forms.Button();
            this.butTerminate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboLocalNet
            // 
            this.cboLocalNet.FormattingEnabled = true;
            this.cboLocalNet.Location = new System.Drawing.Point(97, 9);
            this.cboLocalNet.MaxLength = 50;
            this.cboLocalNet.Name = "cboLocalNet";
            this.cboLocalNet.Size = new System.Drawing.Size(177, 21);
            this.cboLocalNet.TabIndex = 1;
            // 
            // cboInternet
            // 
            this.cboInternet.FormattingEnabled = true;
            this.cboInternet.Location = new System.Drawing.Point(97, 36);
            this.cboInternet.MaxLength = 50;
            this.cboInternet.Name = "cboInternet";
            this.cboInternet.Size = new System.Drawing.Size(177, 21);
            this.cboInternet.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Local Connection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Free Connection";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtProxyServer
            // 
            this.TxtProxyServer.Location = new System.Drawing.Point(97, 63);
            this.TxtProxyServer.MaxLength = 50;
            this.TxtProxyServer.Name = "TxtProxyServer";
            this.TxtProxyServer.Size = new System.Drawing.Size(177, 20);
            this.TxtProxyServer.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Proxy Server";
            // 
            // butRef
            // 
            this.butRef.Image = global::Mandarin.Properties.Resources.reload;
            this.butRef.Location = new System.Drawing.Point(12, 89);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(40, 40);
            this.butRef.TabIndex = 12;
            this.butRef.TabStop = false;
            this.butRef.UseVisualStyleBackColor = true;
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // butTerminate
            // 
            this.butTerminate.Image = ((System.Drawing.Image)(resources.GetObject("butTerminate.Image")));
            this.butTerminate.Location = new System.Drawing.Point(58, 89);
            this.butTerminate.Name = "butTerminate";
            this.butTerminate.Size = new System.Drawing.Size(40, 40);
            this.butTerminate.TabIndex = 18;
            this.butTerminate.TabStop = false;
            this.butTerminate.UseVisualStyleBackColor = true;
            this.butTerminate.Click += new System.EventHandler(this.butTerminate_Click);
            // 
            // SettingForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 140);
            this.ControlBox = false;
            this.Controls.Add(this.butTerminate);
            this.Controls.Add(this.butRef);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtProxyServer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboInternet);
            this.Controls.Add(this.cboLocalNet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Switch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboLocalNet;
        private System.Windows.Forms.ComboBox cboInternet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private TextBox TxtProxyServer;
        private Label label3;
        private Button butRef;
        private Button butTerminate;
    }
}

