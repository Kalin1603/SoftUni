using RealEstates.Services;
using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RealEstates.WinFormsApp
{
    public partial class CatalogForm : Form
    {
        private readonly PropertiesService propertiesService;
        private PropertiesViewModel model;

        public CatalogForm(PropertiesService propertiesService)
        {
            InitializeComponent();
            this.propertiesService = propertiesService;
        }

        private void CatalogForm_Load(object sender, EventArgs e)
        {
            model = propertiesService.GetProperties();
            FillDataGrid();
            dataGridProperties.AutoResizeColumns();
            dataGridProperties.AutoSize = true;
        }

        private void FillDataGrid()
        {
            dataGridProperties.Rows.Clear();

            foreach (var property in model.Properties)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridProperties.Rows[0].Clone();
                
                row.Cells[0].Value = property.Price;
                row.Cells[0].Value = property.Size;
                row.Cells[0].Value = property.Floor;
                row.Cells[0].Value = property.District;
                this.dataGridProperties.Rows.Add(row);
            }
            labelPageInfo.Text = $"Страница: {model.PageNumber} / {model.PagesCount}\nИмоти: {model.ElementsCount}";
        }

        private void dataGridProperties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (model.HasNextPage)
            {
                model = propertiesService.GetProperties(model.NextPageNumber);
                FillDataGrid();
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (model.HasPreviousPage)
            {
                model = propertiesService.GetProperties(model.PreviousPageNumber);
                FillDataGrid();
            }
        }
    }
}
