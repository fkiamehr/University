using System.ComponentModel.DataAnnotations;

namespace University.DataLayer.Entities
{
    public class StudentLevel
    {
        
        [Key]
        public int LevelId { get; set; }

        [MaxLength(15)]
        public string LevelTitle { get; set; }

        public List<Student>? Students { get; set; }
    }
}
