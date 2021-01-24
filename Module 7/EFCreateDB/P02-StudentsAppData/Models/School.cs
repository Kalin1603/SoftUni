using System;
using System.Collections.Generic;
using System.Text;

namespace P02_StudentsAppData.Models
{
   public class School
    {
        public School()
        {
            this.Students = new HashSet<Student>();            
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
