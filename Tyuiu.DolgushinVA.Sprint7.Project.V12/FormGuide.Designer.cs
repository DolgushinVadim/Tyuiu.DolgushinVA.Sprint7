
namespace Tyuiu.DolgushinVA.Sprint7.Project.V12
{
    partial class FormGuide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGuide));
            this.labelGuide_DVA = new System.Windows.Forms.Label();
            this.buttonCloseGuide_DVA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelGuide_DVA
            // 
            this.labelGuide_DVA.AutoSize = true;
            this.labelGuide_DVA.BackColor = System.Drawing.Color.Transparent;
            this.labelGuide_DVA.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.labelGuide_DVA.Location = new System.Drawing.Point(12, 9);
            this.labelGuide_DVA.Name = "labelGuide_DVA";
            this.labelGuide_DVA.Size = new System.Drawing.Size(918, 736);
            this.labelGuide_DVA.TabIndex = 0;
            this.labelGuide_DVA.Text = resources.GetString("labelGuide_DVA.Text");
            // 
            // buttonCloseGuide_DVA
            // 
            this.buttonCloseGuide_DVA.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.buttonCloseGuide_DVA.Location = new System.Drawing.Point(768, 12);
            this.buttonCloseGuide_DVA.Name = "buttonCloseGuide_DVA";
            this.buttonCloseGuide_DVA.Size = new System.Drawing.Size(224, 44);
            this.buttonCloseGuide_DVA.TabIndex = 1;
            this.buttonCloseGuide_DVA.Text = "Закрыть руководство";
            this.buttonCloseGuide_DVA.UseVisualStyleBackColor = true;
            this.buttonCloseGuide_DVA.Click += new System.EventHandler(this.buttonCloseGuide_DVA_Click);
            // 
            // FormGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tyuiu.DolgushinVA.Sprint7.Project.V12.Properties.Resources.backgroundinfo;
            this.ClientSize = new System.Drawing.Size(1004, 760);
            this.Controls.Add(this.buttonCloseGuide_DVA);
            this.Controls.Add(this.labelGuide_DVA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormGuide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Руководство";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGuide_DVA;
        private System.Windows.Forms.Button buttonCloseGuide_DVA;
    }
}