namespace Sales_Database.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Customer
    {
        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }

        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(80)]
        public string Email { get; set; }

        [MaxLength(80)]
        public string CreditCardNumber { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
