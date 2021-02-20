
namespace RealEstates.WinFormsApp
{
    partial class CatalogForm
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
            this.dataGridProperties = new System.Windows.Forms.DataGridView();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Floors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.District = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelPageInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridProperties
            // 
            this.dataGridProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Price,
            this.Size,
            this.Floors,
            this.District});
            this.dataGridProperties.Location = new System.Drawing.Point(12, 12);
            this.dataGridProperties.Name = "dataGridProperties";
            this.dataGridProperties.RowTemplate.Height = 25;
            this.dataGridProperties.Size = new System.Drawing.Size(443, 127);
            this.dataGridProperties.TabIndex = 0;
            this.dataGridProperties.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProperties_CellContentClick);
            // 
            // Price
            // 
            this.Price.HeaderText = "Цена";
            this.Price.Name = "Price";
            // 
            // Size
            // 
            this.Size.HeaderText = "Площ";
            this.Size.Name = "Size";
            // 
            // Floors
            // 
            this.Floors.HeaderText = "Етажи";
            this.Floors.Name = "Floors";
            // 
            // District
            // 
            this.District.HeaderText = "Местоположение";
            this.District.Name = "District";
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonPrevious.Location = new System.Drawing.Point(3, 309);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(149, 70);
            this.buttonPrevious.TabIndex = 1;
            this.buttonPrevious.Text = "Предишна страница";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonNext.Location = new System.Drawing.Point(196, 308);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(154, 71);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "Следваща страница";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // labelPageInfo
            // 
            this.labelPageInfo.AutoSize = true;
            this.labelPageInfo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPageInfo.Location = new System.Drawing.Point(404, 327);
            this.labelPageInfo.Name = "labelPageInfo";
            this.labelPageInfo.Size = new System.Drawing.Size(21, 30);
            this.labelPageInfo.TabIndex = 3;
            this.labelPageInfo.Text = "-";
            // 
            // CatalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelPageInfo);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.dataGridProperties);
            this.Name = "CatalogForm";
            this.Text = "CatalogForm";
            this.Load += new System.EventHandler(this.CatalogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProperties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Floors;
        private System.Windows.Forms.DataGridViewTextBoxColumn District;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelPageInfo;
    }
}