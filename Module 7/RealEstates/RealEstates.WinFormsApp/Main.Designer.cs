
namespace RealEstates.WinFormsApp
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.CreateProperty = new System.Windows.Forms.Button();
            this.buttonCatalog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(254, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Real Estates";
            // 
            // CreateProperty
            // 
            this.CreateProperty.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateProperty.Location = new System.Drawing.Point(38, 131);
            this.CreateProperty.Name = "CreateProperty";
            this.CreateProperty.Size = new System.Drawing.Size(142, 84);
            this.CreateProperty.TabIndex = 1;
            this.CreateProperty.Text = "Добави";
            this.CreateProperty.UseVisualStyleBackColor = true;
            this.CreateProperty.Click += new System.EventHandler(this.CreateProperty_Click);
            // 
            // buttonCatalog
            // 
            this.buttonCatalog.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCatalog.Location = new System.Drawing.Point(233, 131);
            this.buttonCatalog.Name = "buttonCatalog";
            this.buttonCatalog.Size = new System.Drawing.Size(154, 85);
            this.buttonCatalog.TabIndex = 2;
            this.buttonCatalog.Text = "Каталог";
            this.buttonCatalog.UseVisualStyleBackColor = true;
            this.buttonCatalog.Click += new System.EventHandler(this.buttonCatalog_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCatalog);
            this.Controls.Add(this.CreateProperty);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CreateProperty;
        private System.Windows.Forms.Button buttonCatalog;
    }
}

