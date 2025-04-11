using System.ComponentModel.DataAnnotations;

namespace DockerPublish.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
