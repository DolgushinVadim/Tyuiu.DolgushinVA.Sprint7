
namespace Tyuiu.DolgushinVA.Sprint7.Project.V12
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.labelInfo_DVA = new System.Windows.Forms.Label();
            this.buttonOK_DVA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelInfo_DVA
            // 
            this.labelInfo_DVA.AutoSize = true;
            this.labelInfo_DVA.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo_DVA.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.labelInfo_DVA.Location = new System.Drawing.Point(12, 21);
            this.labelInfo_DVA.Name = "labelInfo_DVA";
            this.labelInfo_DVA.Size = new System.Drawing.Size(429, 230);
            this.labelInfo_DVA.TabIndex = 0;
            this.labelInfo_DVA.Text = resources.GetString("labelInfo_DVA.Text");
            // 
            // buttonOK_DVA
            // 
            this.buttonOK_DVA.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F);
            this.buttonOK_DVA.Location = new System.Drawing.Point(434, 267);
            this.buttonOK_DVA.Name = "buttonOK_DVA";
            this.buttonOK_DVA.Size = new System.Drawing.Size(88, 35);
            this.buttonOK_DVA.TabIndex = 1;
            this.buttonOK_DVA.Text = "OK";
            this.buttonOK_DVA.UseVisualStyleBackColor = true;
            this.buttonOK_DVA.Click += new System.EventHandler(this.buttonOK_DVA_Click);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Tyuiu.DolgushinVA.Sprint7.Project.V12.Properties.Resources.backgroundinfo;
            this.ClientSize = new System.Drawing.Size(534, 321);
            this.Controls.Add(this.buttonOK_DVA);
            this.Controls.Add(this.labelInfo_DVA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo_DVA;
        private System.Windows.Forms.Button buttonOK_DVA;
    }
}