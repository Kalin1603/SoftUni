using RealEstates.Data;
using RealEstates.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstates.WinFormsApp
{
    public partial class Main : Form
    {
        private readonly ApplicationDbContext dbContext;
        private readonly PropertiesService propertiesService;
        private readonly WindowsFormService windowsFormService;

        public Main()
        {
            InitializeComponent();
            this.dbContext = new ApplicationDbContext();
            this.propertiesService = new PropertiesService(this.dbContext);
            this.windowsFormService = new WindowsFormService(this.dbContext);
        }

        private void CreateProperty_Click(object sender, EventArgs e)
        {
            CreatePropertyForm createForm = new CreatePropertyForm(this.propertiesService,this.windowsFormService);
            createForm.Show();
        }

        private void buttonCatalog_Click(object sender, EventArgs e)
        {
            CatalogForm form = new CatalogForm(this.propertiesService);
            form.Show();
        }
    }
}
