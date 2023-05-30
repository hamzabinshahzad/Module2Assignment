﻿using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class EmployeeAddress
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = @"Street address must be between {0} and {1} of length!")]
        public string SteetAddress { get; set; }

        [Required]
        [RegularExpression(@"[^0-9]", ErrorMessage = "City Name cannot contain any numeric digits!")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = @"City name length must be between {0} and {1} characters long!")]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"[^0-9]", ErrorMessage = "State Name cannot contain any numeric digits!")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = @"State name length must be between {0} and {1} characters long!")]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"[^0-9]", ErrorMessage = "Country Name cannot contain any numeric digits!")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = @"Country name length must be between {0} and {1} characters long!")]
        public string Country { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = @"Employee ID must be between {0} and {1}")]
        public int EmployeeId { get; set; } // FK
    }
}
