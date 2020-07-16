using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystemforLibraries.Data.Entities
{
    [Table("Loans")]
    public class Loan
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime LoanDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        public Guid CopyId { get; set; }
        public Copy Copy { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
