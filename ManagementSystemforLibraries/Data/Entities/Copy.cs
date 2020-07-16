using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystemforLibraries.Data.Entities
{
    [Table("Copies")]
    public class Copy
    {
        public Guid Id { get; set; }

        [Required]
        public string Code { get; set; }
        public bool Availability { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
