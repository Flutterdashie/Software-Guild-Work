﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DvdLibraryAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DvdLibraryEntities : DbContext
    {
        public DvdLibraryEntities()
            : base("name=DvdLibraryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dvd> Dvds { get; set; }
    
        public virtual int CreateDvd(string title, string realeaseYear, string director, string rating, string notes)
        {
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var realeaseYearParameter = realeaseYear != null ?
                new ObjectParameter("realeaseYear", realeaseYear) :
                new ObjectParameter("realeaseYear", typeof(string));
    
            var directorParameter = director != null ?
                new ObjectParameter("director", director) :
                new ObjectParameter("director", typeof(string));
    
            var ratingParameter = rating != null ?
                new ObjectParameter("rating", rating) :
                new ObjectParameter("rating", typeof(string));
    
            var notesParameter = notes != null ?
                new ObjectParameter("notes", notes) :
                new ObjectParameter("notes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateDvd", titleParameter, realeaseYearParameter, directorParameter, ratingParameter, notesParameter);
        }
    
        public virtual int DeleteByID(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteByID", idParameter);
        }
    
        public virtual ObjectResult<GetByDirector_Result> GetByDirector(string search)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByDirector_Result>("GetByDirector", searchParameter);
        }
    
        public virtual ObjectResult<GetByID_Result> GetByID(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByID_Result>("GetByID", idParameter);
        }
    
        public virtual ObjectResult<GetByRating_Result> GetByRating(string search)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByRating_Result>("GetByRating", searchParameter);
        }
    
        public virtual ObjectResult<GetByTitle_Result> GetByTitle(string search)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByTitle_Result>("GetByTitle", searchParameter);
        }
    
        public virtual ObjectResult<GetByYear_Result> GetByYear(string search)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByYear_Result>("GetByYear", searchParameter);
        }
    
        public virtual int UpdateByID(Nullable<int> dvdId, string title, string realeaseYear, string director, string rating, string notes)
        {
            var dvdIdParameter = dvdId.HasValue ?
                new ObjectParameter("dvdId", dvdId) :
                new ObjectParameter("dvdId", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var realeaseYearParameter = realeaseYear != null ?
                new ObjectParameter("realeaseYear", realeaseYear) :
                new ObjectParameter("realeaseYear", typeof(string));
    
            var directorParameter = director != null ?
                new ObjectParameter("director", director) :
                new ObjectParameter("director", typeof(string));
    
            var ratingParameter = rating != null ?
                new ObjectParameter("rating", rating) :
                new ObjectParameter("rating", typeof(string));
    
            var notesParameter = notes != null ?
                new ObjectParameter("notes", notes) :
                new ObjectParameter("notes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateByID", dvdIdParameter, titleParameter, realeaseYearParameter, directorParameter, ratingParameter, notesParameter);
        }
    
        public virtual ObjectResult<GetAll_Result> GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAll_Result>("GetAll");
        }
    }
}
