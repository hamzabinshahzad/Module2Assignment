using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class Designation
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z ]*$")]
        public string DesignationName { get; set; }
    }
}
