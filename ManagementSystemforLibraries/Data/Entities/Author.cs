using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystemforLibraries.Data.Entities
{
    [Table("Authors")]
    public class Author
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(60)]
        [MinLength(3)]
        public string Name { get; set; }
        public ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}
