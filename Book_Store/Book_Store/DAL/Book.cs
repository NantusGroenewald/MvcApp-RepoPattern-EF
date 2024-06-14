//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Book_Store.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public Nullable<int> GenreId { get; set; }
        public string PublicationYear { get; set; }
        public Nullable<int> AuthorId { get; set; }
        public Nullable<int> PublisherId { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
