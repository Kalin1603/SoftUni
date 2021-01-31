namespace P01__OneToOne
{
    using System.ComponentModel.DataAnnotations;

    public class Passport
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        public virtual Person Person { get; set; }
    }
}