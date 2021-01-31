using System.ComponentModel.DataAnnotations.Schema;

namespace P03__ManyToMany.Data.Models
{
    public class StudentExam
    {

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [ForeignKey(nameof(Exam))]
        public int ExamId { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
