using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class RefreshToken
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Token { get; set; } = string.Empty;

        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public DateTime Expires { get; set; }

        [Required]
        public int CredentialId { get; set; }

        public virtual Credential? Credential { get; set; } // NAV
    }
}
