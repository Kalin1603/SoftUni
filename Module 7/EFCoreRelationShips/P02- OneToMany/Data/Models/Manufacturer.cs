using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P02__OneToMany.Data.Models
{
   public class Manufacturer
    {
        public Manufacturer()
        {
            this.Models = new HashSet<Model>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? EstablishedOn { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
