﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystemforLibraries.Data.Entities
{
    [Table("AuthorBooks")]
    public class AuthorBook
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
