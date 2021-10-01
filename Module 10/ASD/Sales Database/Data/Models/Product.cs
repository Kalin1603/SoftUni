namespace Sales_Database.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }

        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public double Quantity { get; set; }

        public int Price { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
