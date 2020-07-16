using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystemforLibraries.Data.Entities
{
    [Table("Books")]
    public class Book
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(120)]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        public int YearOfPublication { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public Guid PublishingCompanyId { get; set; }
        public PublishingCompany PublishingCompany { get; set; }

        public ICollection<AuthorBook> AuthorBooks { get; set; }

        public ICollection<Copy> Copies { get; set; }
    }
}
