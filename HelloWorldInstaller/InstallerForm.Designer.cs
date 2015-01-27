namespace HelloWorldInstaller
{
    partial class InstallerForm
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
            this.consoleTextBox = new System.Windows.Forms.RichTextBox();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Location = new System.Drawing.Point(18, 94);
            this.consoleTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.Size = new System.Drawing.Size(295, 176);
            this.consoleTextBox.TabIndex = 10;
            this.consoleTextBox.Text = "";
            // 
            // btnInitialize
            // 
            this.btnInitialize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInitialize.Location = new System.Drawing.Point(18, 22);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(133, 34);
            this.btnInitialize.TabIndex = 9;
            this.btnInitialize.Text = "Initialize";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstall.Location = new System.Drawing.Point(179, 22);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(133, 34);
            this.btnInstall.TabIndex = 8;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // InstallerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 296);
            this.Controls.Add(this.consoleTextBox);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.btnInstall);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstallerForm";
            this.Text = "HelloWorld Installer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox consoleTextBox;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Button btnInstall;
    }
}

